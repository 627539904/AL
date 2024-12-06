using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AL.ControlLib.AControls
{
    /// <summary>
    /// 隐藏图标的右键菜单
    /// </summary>
    public class NotifyIconRightMenu<T> 
        where T : Form
    {
        private T form;
        public NotifyIconRightMenu(T _form)
        {
            this.form = _form;
        }
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem closeMenuItem;
        private ToolStripMenuItem minimizeMenuItem;
        private ToolStripMenuItem maximizeMenuItem;
        private ToolStripMenuItem settingMenuItem;
        public NotifyIconRightMenu<T> Init(NotifyIcon iconControl=null)
        {
            if (iconControl == null)
            {
                // 初始化托盘图标
                notifyIcon = new NotifyIcon();
                notifyIcon.Icon = SystemIcons.Application;
                notifyIcon.Text = form.Text;
                notifyIcon.Visible = true; // 初始时不可见
            }
            else
            {
                notifyIcon = iconControl;
            }

            // 初始化右键菜单
            contextMenuStrip = new ContextMenuStrip();
            closeMenuItem = new ToolStripMenuItem("退出");
            minimizeMenuItem = new ToolStripMenuItem("隐藏");
            maximizeMenuItem = new ToolStripMenuItem("显示");
            

            closeMenuItem.Click += CloseMenuItem_Click;
            minimizeMenuItem.Click += MinimizeMenuItem_Click;
            maximizeMenuItem.Click += ShowMenuItem_Click;
            notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;
            

            contextMenuStrip.Items.Add(closeMenuItem);
            contextMenuStrip.Items.Add(minimizeMenuItem);
            contextMenuStrip.Items.Add(maximizeMenuItem);

            notifyIcon.ContextMenuStrip = contextMenuStrip;

            // 窗口最小化时隐藏窗口并显示托盘图标
            form.Resize += MainForm_Resize;
            return this;
        }

        /// <summary>
        /// 添加设置菜单项
        /// </summary>
        /// <param name="settingForm"></param>
        public NotifyIconRightMenu<T> AddSettingMenuItem(Form settingForm)
        {
            settingMenuItem = new ToolStripMenuItem("设置");
            settingMenuItem.Click += (sender, e) => { settingForm.Show(); };
            contextMenuStrip.Items.Add(settingMenuItem);
            return this;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (form.WindowState == FormWindowState.Minimized)
            {
                form.Hide();
                notifyIcon.Visible = true;
            }
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // 关闭应用程序
        }

        private void MinimizeMenuItem_Click(object sender, EventArgs e)
        {
            form.WindowState = FormWindowState.Minimized;
            form.Hide();
            notifyIcon.Visible = true;
        }

        private void ShowMenuItem_Click(object sender, EventArgs e)
        {            
            NotifyIcon_MouseDoubleClick(null,null);
        }

        // 双击托盘图标时显示窗口
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            form.Show();
            form.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = true;
        }

        public static void CreateMenu<T>(T frmKeyShow, NotifyIcon notifyIcon=null)
            where T : Form
        {
            new NotifyIconRightMenu<T>(frmKeyShow).Init(notifyIcon);
        }

        ~NotifyIconRightMenu()
        {
            notifyIcon.Dispose();
        }
    }
}
