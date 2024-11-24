namespace AL.AppTool
{
    partial class frmAppInfo
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
            tcApp = new TabControl();
            tpDefault = new TabPage();
            tabPage2 = new TabPage();
            dgvAppType = new DataGridView();
            btnAddType = new Button();
            label1 = new Label();
            txtTypeKey = new TextBox();
            label2 = new Label();
            txtTypeValue = new TextBox();
            btnDelType = new Button();
            btnReloadApp = new Button();
            lbTipAppType = new Label();
            tcApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppType).BeginInit();
            SuspendLayout();
            // 
            // tcApp
            // 
            tcApp.Controls.Add(tpDefault);
            tcApp.Controls.Add(tabPage2);
            tcApp.Location = new Point(48, 39);
            tcApp.Name = "tcApp";
            tcApp.SelectedIndex = 0;
            tcApp.Size = new Size(691, 368);
            tcApp.TabIndex = 0;
            // 
            // tpDefault
            // 
            tpDefault.Location = new Point(4, 26);
            tpDefault.Name = "tpDefault";
            tpDefault.Padding = new Padding(3);
            tpDefault.Size = new Size(683, 338);
            tpDefault.TabIndex = 0;
            tpDefault.Text = "应用";
            tpDefault.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(683, 338);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvAppType
            // 
            dgvAppType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAppType.Location = new Point(53, 447);
            dgvAppType.Name = "dgvAppType";
            dgvAppType.Size = new Size(682, 202);
            dgvAppType.TabIndex = 1;
            // 
            // btnAddType
            // 
            btnAddType.Location = new Point(589, 662);
            btnAddType.Name = "btnAddType";
            btnAddType.Size = new Size(86, 23);
            btnAddType.TabIndex = 2;
            btnAddType.Text = "添加/修改";
            btnAddType.UseVisualStyleBackColor = true;
            btnAddType.Click += btnAddType_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 662);
            label1.Name = "label1";
            label1.Size = new Size(32, 17);
            label1.TabIndex = 3;
            label1.Text = "Key:";
            // 
            // txtTypeKey
            // 
            txtTypeKey.Location = new Point(91, 659);
            txtTypeKey.Name = "txtTypeKey";
            txtTypeKey.Size = new Size(128, 23);
            txtTypeKey.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(236, 665);
            label2.Name = "label2";
            label2.Size = new Size(43, 17);
            label2.TabIndex = 3;
            label2.Text = "Value:";
            // 
            // txtTypeValue
            // 
            txtTypeValue.Location = new Point(285, 662);
            txtTypeValue.Name = "txtTypeValue";
            txtTypeValue.Size = new Size(298, 23);
            txtTypeValue.TabIndex = 4;
            txtTypeValue.TextChanged += txtTypeValue_TextChanged;
            txtTypeValue.KeyDown += txtTypeValue_KeyDown;
            // 
            // btnDelType
            // 
            btnDelType.Location = new Point(681, 662);
            btnDelType.Name = "btnDelType";
            btnDelType.Size = new Size(54, 23);
            btnDelType.TabIndex = 2;
            btnDelType.Text = "删除";
            btnDelType.UseVisualStyleBackColor = true;
            btnDelType.Click += btnDelType_Click;
            // 
            // btnReloadApp
            // 
            btnReloadApp.Location = new Point(54, 10);
            btnReloadApp.Name = "btnReloadApp";
            btnReloadApp.Size = new Size(165, 23);
            btnReloadApp.TabIndex = 5;
            btnReloadApp.Text = "重新加载应用列表";
            btnReloadApp.UseVisualStyleBackColor = true;
            btnReloadApp.Click += btnReloadApp_Click;
            // 
            // lbTipAppType
            // 
            lbTipAppType.AutoSize = true;
            lbTipAppType.Location = new Point(51, 418);
            lbTipAppType.Name = "lbTipAppType";
            lbTipAppType.Size = new Size(92, 17);
            lbTipAppType.TabIndex = 6;
            lbTipAppType.Text = "应用分类提示：";
            // 
            // frmAppInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 707);
            Controls.Add(lbTipAppType);
            Controls.Add(btnReloadApp);
            Controls.Add(txtTypeValue);
            Controls.Add(label2);
            Controls.Add(txtTypeKey);
            Controls.Add(label1);
            Controls.Add(btnDelType);
            Controls.Add(btnAddType);
            Controls.Add(dgvAppType);
            Controls.Add(tcApp);
            Name = "frmAppInfo";
            Text = "应用信息";
            Load += frmAppInfo_Load;
            tcApp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAppType).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tcApp;
        private TabPage tpDefault;
        private TabPage tabPage2;
        private DataGridView dgvAppType;
        private Button btnAddType;
        private Label label1;
        private TextBox txtTypeKey;
        private Label label2;
        private TextBox txtTypeValue;
        private Button btnDelType;
        private Button btnReloadApp;
        private Label lbTipAppType;
    }
}
