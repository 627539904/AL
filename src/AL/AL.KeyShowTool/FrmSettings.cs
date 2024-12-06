using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AL.KeyShowTool
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();

            AddTip();
        }
        /// <summary>
        /// 设置父窗体
        /// </summary>
        public object Parent { get; set; }

        void AddTip()
        {
            // 创建ToolTip控件实例（如果通过设计器没有添加的话）
            ToolTip toolTip = new ToolTip();

            // 设置ToolTip的显示时间（毫秒）
            toolTip.AutoPopDelay = 3000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;

            // 为CheckBox设置ToolTip文本
            toolTip.SetToolTip(this.cbxTopMost, "checed:始终在屏幕最前方");
        }

        private void cbxTopMost_CheckedChanged(object sender, EventArgs e)
        {
            if(Parent==null)
                return;
            if(Parent is FrmKeyShow)
            {
                ((FrmKeyShow)Parent).TopMost = cbxTopMost.Checked;
            }
        }
    }
}
