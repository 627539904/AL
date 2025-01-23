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
                "δ֪".TextToImage(Icon_Def, new Size(50, 50));
            this.lbTipAppType.Text = $"Ӧ�÷�����ʾ��������[{path_appType}]��ֱ�ӽ����޸ģ��Կ���˳��";
            tcApp.TabPages.Clear();
            dicAppType.LoadFromFile(path_appType);
            LoadAppTypes();
            LoadDictionary();
        }

        Dictionary<string, string> dicAppType = new Dictionary<string, string>()
            {
                {"����","" },
                {"Music","Music,����,Video" },
                {"Game","Game,��Ϸ,�׹���,MHY,����,ԭ��" },
                {"NetDisk","����" }
            };
        void PrintList(List<AppInfo> apps, string key = "Default")
        {
            var tpDefault = new TabPage($"{key}({apps.Count()})");
            if (dicAppType.ContainsKey(key))
                tpDefault.Name = $"tp{dicAppType.Keys.ToList().IndexOf(key)}";
            else if (key == "Error")
            {
                tpDefault.Name = $"tpError";
                tpDefault.Text = $"�޷�ʶ��({apps.Count()})";
            }
            //else if (key == "System")
            //{
            //    tpDefault.Name = $"tpSystem";
            //    tpDefault.Text = $"ϵͳ({apps.Count()})";
            //}
            else
            {
                tpDefault.Name = $"tpDefault";
                tpDefault.Text = $"����({apps.Count()})";
            }
            tcApp.TabPages.Add(tpDefault);

            tpDefault.Fill(apps, item =>
            {
                Image btnIcon;
                if (!string.IsNullOrEmpty(item.StartPath) && File.Exists(item.StartPath))
                    btnIcon = Icon.ExtractAssociatedIcon(item.StartPath).ToBitmap();
                else
                    btnIcon = Image.FromFile(Icon_Def);//Ĭ��Icon
                var btn = new Button();
                btn.Size = new System.Drawing.Size(50, 50);
                btn.Image = btnIcon;
                //btn.Text = item.DisplayName;
                btn.Tag = item;//���������ݰ�
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
                btn.ContextMenuStrip.Items.Add(new ToolStripMenuItem("����", null,
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
            var infoErrorApps = apps.Where(p => p.IsNullOrEmpty()).ToList();//�޷�ʶ���������ް�װ·����
            apps = apps.Except(infoErrorApps).ToList();
            //var sysApps = apps.Where(p => p.IsSystemApp()).ToList();//�ų���exe����·����Ӧ��
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
            List<AppInfo> classedApps = new List<AppInfo>();//���������
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
            //��ʼ��DataGridView
            dgvAppType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvAppType.AllowUserToAddRows = true;
            //dgvAppType.RowTemplate.Height = 50; // �����и��Ա㰴ť��ʾ            
            //dgvAppType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;// ȷ��FullRowSelect����Ϊtrue���Ա������е����ⵥԪ�񶼻�ѡ������

            var tempList = dicAppType.ToIList(kvp => new DictionaryEntry(kvp.Key, kvp.Value));
            dictionaryList = new BindingList<DictionaryEntry>(tempList);
            dgvAppType.DataSource = dictionaryList;
            dgvAppType.Columns[0].HeaderText = "����";
            dgvAppType.Columns[1].HeaderText = "Value";

            dgvAppType.ReadOnly = true;

            // ����ť����¼�
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
        //    // ��������Ƿ�����Ч���к���
        //    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        //    {
        //        // ��ȡ�������
        //        DataGridViewRow clickedRow = dgvAppType.Rows[e.RowIndex];

        //        // �������Ƿ��ѱ�ѡ�У���FullRowSelectΪtrueʱ��������ⵥԪ�񶼻�ѡ�����У�
        //        if (clickedRow.Selected)
        //        {
        //            // ���������Ӵ���ѡ���еĴ���
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
                MessageBox.Show("������Key");
                return;
            }
            if (value.IsNullOrEmpty())
            {
                MessageBox.Show("������Value");
            }

            if (dicAppType.ContainsKey(key))
            {
                var dicEntry = dictionaryList.FirstOrDefault(x => (string)x.Key == key);
                dicEntry.Value = value;
                dicAppType.AddOrUpdate(key, value, path_appType);
                LoadDictionary();//ˢ���б�
                MessageBox.Show("�޸ĳɹ�");
            }
            else
            {
                // ����е�DataTable
                dictionaryList.Add(new DictionaryEntry(key, value));
                dicAppType.AddOrUpdate(key, value, path_appType);
                MessageBox.Show("��ӳɹ�");
            }

        }
        private void btnDelType_Click(object sender, EventArgs e)
        {
            string key = this.txtTypeKey.Text;
            if (key.IsNullOrEmpty())
            {
                MessageBox.Show("������Key");
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
            // ����Ƿ����˻س�����Keys.Enter��
            if (e.KeyCode == Keys.Enter)
            {
                // ��ֹ�����ˡ���
                e.SuppressKeyPress = true;

                // ִ��ȷ������Ķ���
                btnAddType_Click(sender, e);
            }
        }

        private void txtTypeValue_TextChanged(object sender, EventArgs e)
        {
            this.txtTypeValue.Text = this.txtTypeValue.Text.Replace("��", ",");
        }
    }

}
