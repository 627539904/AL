using AL.ControlLib;
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

            this.lbName.AddClickEvent_CopyText();
            this.lbInstallLoc.AddClickEvent_CopyText();
            this.lbStartPath.AddClickEvent_CopyText();
            this.lbUninstallPath.AddClickEvent_CopyText();
        }
    }
}
