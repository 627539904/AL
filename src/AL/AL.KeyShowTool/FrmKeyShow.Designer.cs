namespace AL.KeyShowTool
{
    partial class FrmKeyShow
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
            SuspendLayout();
            // 
            // FrmKeyShow
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "FrmKeyShow";
            Text = "按键显示";
            FormClosing += FrmKeyShow_FormClosing;
            Load += FrmKeyShow_Load;
            MouseDown += FrmKeyShow_MouseDown;
            MouseMove += FrmKeyShow_MouseMove;
            MouseUp += FrmKeyShow_MouseUp;
            ResumeLayout(false);
        }

        #endregion
    }
}
