using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static void RemoveBy<T>(this IList<T> source, Func<T, bool> predicate)
        {
            source.Remove(source.FirstOrDefault(predicate));
        }
        public static void RemoveAll<T>(this IList<T> source, Func<T, bool> predicate)
        {
            var removeList = source.Where(predicate).ToList();
            foreach (var item in removeList)
            {
                source.Remove(item);
            }
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
    }
}
