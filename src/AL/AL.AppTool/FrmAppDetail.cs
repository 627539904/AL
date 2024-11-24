using AL.PC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AL.AppTool
{
    public partial class FrmAppDetail : Form
    {
        public FrmAppDetail()
        {
            InitializeComponent();
        }
        public AppInfo AppInfo { get; internal set; }

        private void FrmAppDetail_Load(object sender, EventArgs e)
        {
            this.lbName.Text = AppInfo.DisplayName;
            this.lbInstallLoc.Text = AppInfo.InstallLocation;
            this.lbStartPath.Text= AppInfo.StartPath;
            this.lbUninstallPath.Text = AppInfo.UninstallString;
        }

        private void lbInstallLoc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.lbInstallLoc.Text))
                return;
            Clipboard.SetText(this.lbInstallLoc.Text);
            MessageBox.Show("文本已复制到剪贴板！");
            //Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            //if (dialog.ShowDialog().GetValueOrDefault())
            //{
            //    Console.WriteLine("-----------" + dialog.FileName);
            //    Console.WriteLine("-----------" + dialog.SafeFileName);

            //    Console.WriteLine("------开始抽取图标-----");

            //    // 将选择的文件名,输入给ExtractAssociatedIcon方法
            //    Image img = System.Drawing.Icon.ExtractAssociatedIcon(dialog.FileName).ToBitmap();
            //    img.Save(@"D:\toolbar\icon\" + dialog.SafeFileName + ".PNG");
            //}
        }
    }
}
