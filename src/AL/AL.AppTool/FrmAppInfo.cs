using AL.ControlLib;
using AL.PC.Models;
using Arvin.Extensions;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace AL.AppTool
{
    public partial class frmAppInfo : Form
    {
        public frmAppInfo()
        {
            InitializeComponent();
        }

        string path_appType = $"{PCPath.DocumentsPath}\\AL\\AppInfo\\{nameof(dicAppType)}.txt";
        string Icon_Def = $"{Application.StartupPath}\\default.png";
        private void frmAppInfo_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Icon_Def))
                "未知".TextToImage(Icon_Def, new Size(50, 50));
            this.lbTipAppType.Text = $"应用分类提示：可以在[{path_appType}]中直接进行修改，以控制顺序";
            tcApp.TabPages.Clear();
            dicAppType.LoadFromFile(path_appType);
            LoadAppTypes();
            LoadDictionary();
        }

        Dictionary<string, string> dicAppType = new Dictionary<string, string>()
            {
                {"常用","" },
                {"Music","Music,音乐,Video" },
                {"Game","Game,游戏,米哈游,MHY,崩坏,原神" },
                {"NetDisk","网盘" }
            };
        void PrintList(List<AppInfo> apps, string key = "Default")
        {
            var tpDefault = new TabPage($"{key}({apps.Count()})");
            if (dicAppType.ContainsKey(key))
                tpDefault.Name = $"tp{dicAppType.Keys.ToList().IndexOf(key)}";
            else if (key == "Error")
            {
                tpDefault.Name = $"tpError";
                tpDefault.Text = $"无法识别({apps.Count()})";
            }
            //else if (key == "System")
            //{
            //    tpDefault.Name = $"tpSystem";
            //    tpDefault.Text = $"系统({apps.Count()})";
            //}
            else
            {
                tpDefault.Name = $"tpDefault";
                tpDefault.Text = $"其他({apps.Count()})";
            }
            tcApp.TabPages.Add(tpDefault);

            tpDefault.Fill(apps, item =>
            {
                Image btnIcon;
                if (!string.IsNullOrEmpty(item.StartPath) && File.Exists(item.StartPath))
                    btnIcon = Icon.ExtractAssociatedIcon(item.StartPath).ToBitmap();
                else
                    btnIcon = Image.FromFile(Icon_Def);//默认Icon
                var btn = new Button();
                btn.Size = new System.Drawing.Size(50, 50);
                btn.Image = btnIcon;
                //btn.Text = item.DisplayName;
                btn.Tag = item;//轻量级数据绑定
                btn.Click += (sender, e) =>
                {
                    if (item.IsNullOrEmpty())
                    {
                        FrmAppDetail frm = new FrmAppDetail();
                        frm.AppInfo = btn.Tag as AppInfo;
                        frm.ShowDialog();
                    }
                    else
                    {
                        item.Start();
                    }
                };
                //btn.ContextMenuStrip= contextMenuStrip;
                btn.ContextMenuStrip = new ContextMenuStrip();
                btn.ContextMenuStrip.Items.Add(new ToolStripMenuItem("属性", null,
                    (sender, e) =>
                    {
                        FrmAppDetail frm = new FrmAppDetail();
                        frm.AppInfo = btn.Tag as AppInfo;
                        frm.ShowDialog();
                    }));
                return btn;
            });

            //Button fisrtButton=tpDefault.Controls.FirstControl(p=>p.GetType()==typeof(Button)) as Button;
            //MessageBox.Show(fisrtButton.Size.ToString());
        }

        void LoadAppTypes()
        {
            var apps = WindowsInfo.GetInstalledAppInfos();
            var infoErrorApps = apps.Where(p => p.IsNullOrEmpty()).ToList();//无法识别（无名字无安装路径）
            apps = apps.Except(infoErrorApps).ToList();
            //var sysApps = apps.Where(p => p.IsSystemApp()).ToList();//排除非exe启动路径的应用
            //apps = apps.Except(sysApps).ToList();
            Func<IEnumerable<string>, IEnumerable<string>> dataEnhanced = (list) => list.Select(p => p.ToUpper());
            Func<string, AppInfo, bool> isContains = (key, app) =>
            {
                var value= dicAppType[key];
                if (value.IsNullOrEmpty())
                    return false;
                var matchList = value.Split(',').ToList();
                string target = app.ToString().Replace("---Code:", "");
                return target.IsContainsAny(matchList);
            };
            List<AppInfo> classedApps = new List<AppInfo>();//分类后的软件
            foreach (var item in dicAppType)
            {
                var Apps = apps.Where(p => isContains(item.Key, p)).ToList();
                PrintList(Apps, item.Key);
                classedApps.AddRange(Apps);
            }
            var otherApps = apps.Except(classedApps)
                .ToList();
            PrintList(otherApps);
            //if(sysApps.Count>0)
            //    PrintList(sysApps, "System");
            if (infoErrorApps.Count > 0)
                PrintList(infoErrorApps, "Error");
        }

        #region dicType
        private BindingList<DictionaryEntry> dictionaryList;
        private void LoadDictionary()
        {
            //dgvAppType.Dock = DockStyle.Fill;
            //初始化DataGridView
            dgvAppType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvAppType.AllowUserToAddRows = true;
            //dgvAppType.RowTemplate.Height = 50; // 设置行高以便按钮显示            
            //dgvAppType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;// 确保FullRowSelect属性为true，以便点击行中的任意单元格都会选中整行

            var tempList = dicAppType.ToIList(kvp => new DictionaryEntry(kvp.Key, kvp.Value));
            dictionaryList = new BindingList<DictionaryEntry>(tempList);
            dgvAppType.DataSource = dictionaryList;
            dgvAppType.Columns[0].HeaderText = "分类";
            dgvAppType.Columns[1].HeaderText = "Value";

            dgvAppType.ReadOnly = true;

            // 处理按钮点击事件
            //dgvAppType.CellContentClick += dgvAppType_CellContentClick;
            //dgvAppType.CellClick += new DataGridViewCellEventHandler(dgvAppType_CellClick);
            dgvAppType.AddCellClickEvent(row =>
            {
                this.txtTypeKey.Text = row.Cells["Key"].Value.ToString();
                this.txtTypeValue.Text = row.Cells["Value"].Value.ToString();
            },isRowSelected:true);
        }

        //private void dgvAppType_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    // 检查点击的是否是有效的行和列
        //    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        //    {
        //        // 获取点击的行
        //        DataGridViewRow clickedRow = dgvAppType.Rows[e.RowIndex];

        //        // 检查该行是否已被选中（在FullRowSelect为true时，点击任意单元格都会选中整行）
        //        if (clickedRow.Selected)
        //        {
        //            // 这里可以添加处理选中行的代码
        //            this.txtTypeKey.Text = clickedRow.Cells["Key"].Value.ToString();
        //            this.txtTypeValue.Text = clickedRow.Cells["Value"].Value.ToString();
        //        }
        //    }
        //}
        private void btnAddType_Click(object sender, EventArgs e)
        {
            string key = this.txtTypeKey.Text;
            string value = this.txtTypeValue.Text.TrimEnd(',');
            if (key.IsNullOrEmpty())
            {
                MessageBox.Show("请输入Key");
                return;
            }
            if (value.IsNullOrEmpty())
            {
                MessageBox.Show("请输入Value");
            }

            if (dicAppType.ContainsKey(key))
            {
                var dicEntry = dictionaryList.FirstOrDefault(x => (string)x.Key == key);
                dicEntry.Value = value;
                dicAppType.AddOrUpdate(key, value, path_appType);
                LoadDictionary();//刷新列表
                MessageBox.Show("修改成功");
            }
            else
            {
                // 添加行到DataTable
                dictionaryList.Add(new DictionaryEntry(key, value));
                dicAppType.AddOrUpdate(key, value, path_appType);
                MessageBox.Show("添加成功");
            }

        }
        private void btnDelType_Click(object sender, EventArgs e)
        {
            string key = this.txtTypeKey.Text;
            if (key.IsNullOrEmpty())
            {
                MessageBox.Show("请输入Key");
                return;
            }
            if (dicAppType.ContainsKey(key))
            {
                dicAppType.Remove(key, path_appType);
                dictionaryList.RemoveBy(x => (string)x.Key == key);
            }
        }
        #endregion

        private void btnReloadApp_Click(object sender, EventArgs e)
        {
            frmAppInfo_Load(sender, e);
        }

        private void txtTypeValue_KeyDown(object sender, KeyEventArgs e)
        {
            // 检查是否按下了回车键（Keys.Enter）
            if (e.KeyCode == Keys.Enter)
            {
                // 阻止“叮咚”声
                e.SuppressKeyPress = true;

                // 执行确认输入的动作
                btnAddType_Click(sender, e);
            }
        }

        private void txtTypeValue_TextChanged(object sender, EventArgs e)
        {
            this.txtTypeValue.Text = this.txtTypeValue.Text.Replace("，", ",");
        }
    }

}
