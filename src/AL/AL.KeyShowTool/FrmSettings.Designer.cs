namespace AL.KeyShowTool
{
    partial class FrmSettings
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
            cbxTopMost = new CheckBox();
            SuspendLayout();
            // 
            // cbxTopMost
            // 
            cbxTopMost.AutoSize = true;
            cbxTopMost.Checked = true;
            cbxTopMost.CheckState = CheckState.Checked;
            cbxTopMost.Location = new Point(93, 35);
            cbxTopMost.Name = "cbxTopMost";
            cbxTopMost.Size = new Size(99, 21);
            cbxTopMost.TabIndex = 0;
            cbxTopMost.Tag = "";
            cbxTopMost.Text = "固定在最上层";
            cbxTopMost.UseVisualStyleBackColor = true;
            cbxTopMost.CheckedChanged += cbxTopMost_CheckedChanged;
            // 
            // FrmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbxTopMost);
            Name = "FrmSettings";
            Text = "设置";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cbxTopMost;
    }
}