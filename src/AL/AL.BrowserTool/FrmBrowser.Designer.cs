namespace AL.BrowserTool
{
    partial class frmBrowser
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            wvBrowser = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel1 = new Panel();
            plTop = new Panel();
            txtUrl = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)wvBrowser).BeginInit();
            panel1.SuspendLayout();
            plTop.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // wvBrowser
            // 
            wvBrowser.AllowExternalDrop = true;
            wvBrowser.CreationProperties = null;
            wvBrowser.DefaultBackgroundColor = Color.White;
            wvBrowser.Dock = DockStyle.Fill;
            wvBrowser.Location = new Point(0, 0);
            wvBrowser.Name = "wvBrowser";
            wvBrowser.Size = new Size(1394, 733);
            wvBrowser.TabIndex = 0;
            wvBrowser.ZoomFactor = 1D;
            // 
            // panel1
            // 
            panel1.Controls.Add(wvBrowser);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(1394, 733);
            panel1.TabIndex = 1;
            // 
            // plTop
            // 
            plTop.Controls.Add(txtUrl);
            plTop.Dock = DockStyle.Fill;
            plTop.Location = new Point(3, 3);
            plTop.Name = "plTop";
            plTop.Size = new Size(1394, 31);
            plTop.TabIndex = 2;
            // 
            // txtUrl
            // 
            txtUrl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtUrl.Location = new Point(23, 4);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(1355, 23);
            txtUrl.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(plTop, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 4.768041F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 95.23196F));
            tableLayoutPanel1.Size = new Size(1400, 776);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // frmBrowser
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 776);
            Controls.Add(tableLayoutPanel1);
            Name = "frmBrowser";
            Text = "浏览器工具";
            ((System.ComponentModel.ISupportInitialize)wvBrowser).EndInit();
            panel1.ResumeLayout(false);
            plTop.ResumeLayout(false);
            plTop.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 wvBrowser;
        private Panel panel1;
        private Panel plTop;
        private TextBox txtUrl;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
