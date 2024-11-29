using System;
using System.Windows.Forms;

namespace AL.BrowserTool
{
    public partial class frmBrowser : Form
    {
        public frmBrowser()
        {
            InitializeComponent();
            this.txtUrl.Text= "https://www.baidu.com";
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await CreateWebView2Async(panel1);
        }

        private async Task CreateWebView2Async(Control parent)
        {
            var webView = new Microsoft.Web.WebView2.WinForms.WebView2
            {
                Dock = DockStyle.Fill
            };

            parent.Controls.Add(webView);

            await webView.EnsureCoreWebView2Async(null);

            webView.CoreWebView2.Navigate(this.txtUrl.Text);
        }
    }
}
