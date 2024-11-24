namespace AL.AppTool
{
    partial class FrmAppDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbName = new Label();
            label1 = new Label();
            label2 = new Label();
            lbInstallLoc = new Label();
            lbStartPath = new Label();
            lb33 = new Label();
            lbUninstallPath = new Label();
            lb3 = new Label();
            SuspendLayout();
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(124, 41);
            lbName.Name = "lbName";
            lbName.Size = new Size(43, 17);
            lbName.TabIndex = 0;
            lbName.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 41);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 1;
            label1.Text = "应用名称：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 67);
            label2.Name = "label2";
            label2.Size = new Size(68, 17);
            label2.TabIndex = 1;
            label2.Text = "安装目录：";
            // 
            // lbInstallLoc
            // 
            lbInstallLoc.AutoSize = true;
            lbInstallLoc.Location = new Point(124, 67);
            lbInstallLoc.Name = "lbInstallLoc";
            lbInstallLoc.Size = new Size(28, 17);
            lbInstallLoc.TabIndex = 0;
            lbInstallLoc.Text = "Loc";
            lbInstallLoc.Click += lbInstallLoc_Click;
            // 
            // lbStartPath
            // 
            lbStartPath.AutoSize = true;
            lbStartPath.Location = new Point(124, 93);
            lbStartPath.Name = "lbStartPath";
            lbStartPath.Size = new Size(50, 17);
            lbStartPath.TabIndex = 0;
            lbStartPath.Text = "Startup";
            lbStartPath.Click += lbInstallLoc_Click;
            // 
            // lb33
            // 
            lb33.AutoSize = true;
            lb33.Location = new Point(50, 93);
            lb33.Name = "lb33";
            lb33.Size = new Size(68, 17);
            lb33.TabIndex = 1;
            lb33.Text = "启动路径：";
            // 
            // lbUninstallPath
            // 
            lbUninstallPath.AutoSize = true;
            lbUninstallPath.Location = new Point(124, 120);
            lbUninstallPath.Name = "lbUninstallPath";
            lbUninstallPath.Size = new Size(57, 17);
            lbUninstallPath.TabIndex = 0;
            lbUninstallPath.Text = "Uninstall";
            lbUninstallPath.Click += lbInstallLoc_Click;
            // 
            // lb3
            // 
            lb3.AutoSize = true;
            lb3.Location = new Point(50, 120);
            lb3.Name = "lb3";
            lb3.Size = new Size(68, 17);
            lb3.TabIndex = 1;
            lb3.Text = "卸载路径：";
            // 
            // FrmAppDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lb3);
            Controls.Add(lb33);
            Controls.Add(lbUninstallPath);
            Controls.Add(label2);
            Controls.Add(lbStartPath);
            Controls.Add(label1);
            Controls.Add(lbInstallLoc);
            Controls.Add(lbName);
            Name = "FrmAppDetail";
            Text = "FrmAppDetail";
            Load += FrmAppDetail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbName;
        private Label label1;
        private Label label2;
        private Label lbInstallLoc;
        private Label lbStartPath;
        private Label lb33;
        private Label lbUninstallPath;
        private Label lb3;
    }
}