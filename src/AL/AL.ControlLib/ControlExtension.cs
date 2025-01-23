using AL.ControlLib.AControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace AL.ControlLib
{
    /// <summary>
    /// 控制扩展类
    /// </summary>
    public static class ControlExtension
    {
        public static void Fill<T>(this TabPage container, List<T> items, Func<T, Control> itemToControl = null)
        {
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill; // 使面板填充整个 TabPage
            panel.AutoScroll = true; // 启用自动滚动
            container.Controls.Add(panel);
            FillPanel fillPanel = new FillPanel(panel,null);
            fillPanel.Fill(items, itemToControl);
        }

        public static void Fill<T>(this TabControl container, List<T> items,Func<T, Control> itemToControl = null)
        {
            container.TabPages.Clear();
            var tpDefault = new TabPage("默认");
            tpDefault.Name = "tpDefault";
            container.TabPages.Add(tpDefault);

            tpDefault.Fill(items, itemToControl);
        }

        #region Controls
        public static Control FirstControl(this ControlCollection controls, Func<Control, bool> predicate)
        {
            return controls.Cast<Control>().FirstOrDefault(predicate);
        }
        #endregion


        #region DataGridView
        /// <summary>
        /// DataGridView 单元格点击事件
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="action"></param>
        /// <param name="isRowSelected">是否设置为行点击：即任意单元格选中均为选中整行</param>
        public static void AddCellClickEvent(this DataGridView dataGridView, Action<DataGridViewRow> action,bool isRowSelected=true)
        {
            if(isRowSelected)
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.CellClick += (sender, e) => {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // 获取点击的行
                    DataGridViewRow clickedRow = dataGridView.Rows[e.RowIndex];

                    // 检查该行是否已被选中（在FullRowSelect为true时，点击任意单元格都会选中整行）
                    if (clickedRow.Selected)
                    {
                        action(clickedRow);
                    }
                }
            };
        }
        public static void BindList<T>(this DataGridView dgv, IList<T> list)
        {
            var res = new BindingList<T>(list);
            dgv.DataSource = res;
        }
        #endregion


        #region Button
        #endregion

        #region Label
        public static void AddClickEvent_CopyText(this Label lb)
        {
            lb.Click += (sender,e)=> {
                Label control = (Label)sender;
                if (string.IsNullOrEmpty(control.Text))
                    return;
                Clipboard.SetText(control.Text);
                MessageBox.Show("文本已复制到剪贴板！");
            };
        }
        #endregion


        #region 隐藏图标
        public static NotifyIconRightMenu<T> CreateMenu_NotifyIcon<T>(this T frm, NotifyIcon notifyIcon = null)
            where T : Form
        {
            return new NotifyIconRightMenu<T>(frm).Init(notifyIcon);
        }
        #endregion
    }

    
}
