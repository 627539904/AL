namespace AL.SysTool
{
    partial class FrmSysTool
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
            components = new System.ComponentModel.Container();
            gbSysInfo = new GroupBox();
            groupBox1 = new GroupBox();
            lbScreenNum = new Label();
            lbScreenInch = new Label();
            lbScreenSize = new Label();
            lbMouseLoc = new Label();
            lbResolution = new Label();
            label21 = new Label();
            label16 = new Label();
            lbScreenSizeaaa = new Label();
            label12 = new Label();
            label20 = new Label();
            gbGPU = new GroupBox();
            lbGPUDriverVersion = new Label();
            lbGPUName = new Label();
            lbUsedRAM_GPU = new Label();
            lbFreeRAM_GPU = new Label();
            lbTotalRAM_GPU = new Label();
            label6 = new Label();
            label4 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            gbRAM = new GroupBox();
            lbUsedRAM = new Label();
            lbFreeRAM = new Label();
            lbTotalRAM = new Label();
            label7 = new Label();
            label5 = new Label();
            label3 = new Label();
            lbOSArchitecture = new Label();
            lbOSName = new Label();
            lbCPU = new Label();
            lbPCName = new Label();
            label13 = new Label();
            label8 = new Label();
            label2 = new Label();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            timerQuick = new System.Windows.Forms.Timer(components);
            label15 = new Label();
            lbFormLoc = new Label();
            gbSysInfo.SuspendLayout();
            groupBox1.SuspendLayout();
            gbGPU.SuspendLayout();
            gbRAM.SuspendLayout();
            SuspendLayout();
            // 
            // gbSysInfo
            // 
            gbSysInfo.Controls.Add(groupBox1);
            gbSysInfo.Controls.Add(gbGPU);
            gbSysInfo.Controls.Add(gbRAM);
            gbSysInfo.Controls.Add(lbOSArchitecture);
            gbSysInfo.Controls.Add(lbOSName);
            gbSysInfo.Controls.Add(lbCPU);
            gbSysInfo.Controls.Add(lbPCName);
            gbSysInfo.Controls.Add(label13);
            gbSysInfo.Controls.Add(label8);
            gbSysInfo.Controls.Add(label2);
            gbSysInfo.Controls.Add(label1);
            gbSysInfo.Location = new Point(65, 61);
            gbSysInfo.Name = "gbSysInfo";
            gbSysInfo.Size = new Size(633, 307);
            gbSysInfo.TabIndex = 0;
            gbSysInfo.TabStop = false;
            gbSysInfo.Text = "系统信息";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbScreenNum);
            groupBox1.Controls.Add(lbScreenInch);
            groupBox1.Controls.Add(lbScreenSize);
            groupBox1.Controls.Add(lbMouseLoc);
            groupBox1.Controls.Add(lbResolution);
            groupBox1.Controls.Add(label21);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(lbScreenSizeaaa);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label20);
            groupBox1.Location = new Point(408, 152);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 119);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "显示器";
            // 
            // lbScreenNum
            // 
            lbScreenNum.AutoSize = true;
            lbScreenNum.Location = new Point(75, 69);
            lbScreenNum.Name = "lbScreenNum";
            lbScreenNum.Size = new Size(15, 17);
            lbScreenNum.TabIndex = 1;
            lbScreenNum.Text = "1";
            // 
            // lbScreenInch
            // 
            lbScreenInch.AutoSize = true;
            lbScreenInch.Location = new Point(121, 52);
            lbScreenInch.Name = "lbScreenInch";
            lbScreenInch.Size = new Size(43, 17);
            lbScreenInch.TabIndex = 1;
            lbScreenInch.Text = "label2";
            // 
            // lbScreenSize
            // 
            lbScreenSize.AutoSize = true;
            lbScreenSize.Location = new Point(121, 35);
            lbScreenSize.Name = "lbScreenSize";
            lbScreenSize.Size = new Size(31, 17);
            lbScreenSize.TabIndex = 1;
            lbScreenSize.Text = "0* 0";
            // 
            // lbMouseLoc
            // 
            lbMouseLoc.AutoSize = true;
            lbMouseLoc.ForeColor = Color.Red;
            lbMouseLoc.Location = new Point(74, 85);
            lbMouseLoc.Name = "lbMouseLoc";
            lbMouseLoc.Size = new Size(34, 17);
            lbMouseLoc.TabIndex = 1;
            lbMouseLoc.Text = "[X,Y]";
            // 
            // lbResolution
            // 
            lbResolution.AutoSize = true;
            lbResolution.Location = new Point(73, 18);
            lbResolution.Name = "lbResolution";
            lbResolution.Size = new Size(77, 17);
            lbResolution.TabIndex = 1;
            lbResolution.Text = "2560 * 1440";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(12, 69);
            label21.Name = "label21";
            label21.Size = new Size(68, 17);
            label21.TabIndex = 0;
            label21.Text = "屏幕数量：";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(12, 52);
            label16.Name = "label16";
            label16.Size = new Size(116, 17);
            label16.TabIndex = 0;
            label16.Text = "屏幕尺寸（英寸）：";
            // 
            // lbScreenSizeaaa
            // 
            lbScreenSizeaaa.AutoSize = true;
            lbScreenSizeaaa.Location = new Point(12, 35);
            lbScreenSizeaaa.Name = "lbScreenSizeaaa";
            lbScreenSizeaaa.Size = new Size(114, 17);
            lbScreenSizeaaa.TabIndex = 0;
            lbScreenSizeaaa.Text = "屏幕尺寸（mm）：";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(13, 85);
            label12.Name = "label12";
            label12.Size = new Size(68, 17);
            label12.TabIndex = 0;
            label12.Text = "鼠标位置：";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(12, 18);
            label20.Name = "label20";
            label20.Size = new Size(56, 17);
            label20.TabIndex = 0;
            label20.Text = "分辨率：";
            // 
            // gbGPU
            // 
            gbGPU.Controls.Add(lbGPUDriverVersion);
            gbGPU.Controls.Add(lbGPUName);
            gbGPU.Controls.Add(lbUsedRAM_GPU);
            gbGPU.Controls.Add(lbFreeRAM_GPU);
            gbGPU.Controls.Add(lbTotalRAM_GPU);
            gbGPU.Controls.Add(label6);
            gbGPU.Controls.Add(label4);
            gbGPU.Controls.Add(label9);
            gbGPU.Controls.Add(label10);
            gbGPU.Controls.Add(label11);
            gbGPU.Location = new Point(27, 161);
            gbGPU.Name = "gbGPU";
            gbGPU.Size = new Size(287, 110);
            gbGPU.TabIndex = 2;
            gbGPU.TabStop = false;
            gbGPU.Text = "显卡";
            // 
            // lbGPUDriverVersion
            // 
            lbGPUDriverVersion.AutoSize = true;
            lbGPUDriverVersion.Location = new Point(73, 86);
            lbGPUDriverVersion.Name = "lbGPUDriverVersion";
            lbGPUDriverVersion.Size = new Size(43, 17);
            lbGPUDriverVersion.TabIndex = 1;
            lbGPUDriverVersion.Text = "label2";
            // 
            // lbGPUName
            // 
            lbGPUName.AutoSize = true;
            lbGPUName.Location = new Point(49, 69);
            lbGPUName.Name = "lbGPUName";
            lbGPUName.Size = new Size(43, 17);
            lbGPUName.TabIndex = 1;
            lbGPUName.Text = "label2";
            // 
            // lbUsedRAM_GPU
            // 
            lbUsedRAM_GPU.AutoSize = true;
            lbUsedRAM_GPU.ForeColor = Color.Red;
            lbUsedRAM_GPU.Location = new Point(103, 53);
            lbUsedRAM_GPU.Name = "lbUsedRAM_GPU";
            lbUsedRAM_GPU.Size = new Size(43, 17);
            lbUsedRAM_GPU.TabIndex = 1;
            lbUsedRAM_GPU.Text = "label2";
            // 
            // lbFreeRAM_GPU
            // 
            lbFreeRAM_GPU.AutoSize = true;
            lbFreeRAM_GPU.ForeColor = Color.Red;
            lbFreeRAM_GPU.Location = new Point(103, 36);
            lbFreeRAM_GPU.Name = "lbFreeRAM_GPU";
            lbFreeRAM_GPU.Size = new Size(43, 17);
            lbFreeRAM_GPU.TabIndex = 1;
            lbFreeRAM_GPU.Text = "label2";
            // 
            // lbTotalRAM_GPU
            // 
            lbTotalRAM_GPU.AutoSize = true;
            lbTotalRAM_GPU.Location = new Point(103, 19);
            lbTotalRAM_GPU.Name = "lbTotalRAM_GPU";
            lbTotalRAM_GPU.Size = new Size(43, 17);
            lbTotalRAM_GPU.TabIndex = 1;
            lbTotalRAM_GPU.Text = "label2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 86);
            label6.Name = "label6";
            label6.Size = new Size(68, 17);
            label6.TabIndex = 0;
            label6.Text = "驱动版本：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 69);
            label4.Name = "label4";
            label4.Size = new Size(44, 17);
            label4.TabIndex = 0;
            label4.Text = "名称：";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(10, 52);
            label9.Name = "label9";
            label9.Size = new Size(97, 17);
            label9.TabIndex = 0;
            label9.Text = "已使用（GB）：";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(10, 35);
            label10.Name = "label10";
            label10.Size = new Size(85, 17);
            label10.TabIndex = 0;
            label10.Text = "可用（GB）：";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(10, 18);
            label11.Name = "label11";
            label11.Size = new Size(97, 17);
            label11.TabIndex = 0;
            label11.Text = "总显存（GB）：";
            // 
            // gbRAM
            // 
            gbRAM.Controls.Add(lbUsedRAM);
            gbRAM.Controls.Add(lbFreeRAM);
            gbRAM.Controls.Add(lbTotalRAM);
            gbRAM.Controls.Add(label7);
            gbRAM.Controls.Add(label5);
            gbRAM.Controls.Add(label3);
            gbRAM.Location = new Point(408, 22);
            gbRAM.Name = "gbRAM";
            gbRAM.Size = new Size(200, 82);
            gbRAM.TabIndex = 2;
            gbRAM.TabStop = false;
            gbRAM.Text = "内存";
            // 
            // lbUsedRAM
            // 
            lbUsedRAM.AutoSize = true;
            lbUsedRAM.ForeColor = Color.Red;
            lbUsedRAM.Location = new Point(103, 53);
            lbUsedRAM.Name = "lbUsedRAM";
            lbUsedRAM.Size = new Size(43, 17);
            lbUsedRAM.TabIndex = 1;
            lbUsedRAM.Text = "label2";
            // 
            // lbFreeRAM
            // 
            lbFreeRAM.AutoSize = true;
            lbFreeRAM.ForeColor = Color.Red;
            lbFreeRAM.Location = new Point(103, 36);
            lbFreeRAM.Name = "lbFreeRAM";
            lbFreeRAM.Size = new Size(43, 17);
            lbFreeRAM.TabIndex = 1;
            lbFreeRAM.Text = "label2";
            // 
            // lbTotalRAM
            // 
            lbTotalRAM.AutoSize = true;
            lbTotalRAM.Location = new Point(103, 19);
            lbTotalRAM.Name = "lbTotalRAM";
            lbTotalRAM.Size = new Size(43, 17);
            lbTotalRAM.TabIndex = 1;
            lbTotalRAM.Text = "label2";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 52);
            label7.Name = "label7";
            label7.Size = new Size(97, 17);
            label7.TabIndex = 0;
            label7.Text = "已使用（GB）：";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 35);
            label5.Name = "label5";
            label5.Size = new Size(85, 17);
            label5.TabIndex = 0;
            label5.Text = "可用（GB）：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 18);
            label3.Name = "label3";
            label3.Size = new Size(97, 17);
            label3.TabIndex = 0;
            label3.Text = "总内存（GB）：";
            // 
            // lbOSArchitecture
            // 
            lbOSArchitecture.AutoSize = true;
            lbOSArchitecture.Location = new Point(105, 86);
            lbOSArchitecture.Name = "lbOSArchitecture";
            lbOSArchitecture.Size = new Size(43, 17);
            lbOSArchitecture.TabIndex = 1;
            lbOSArchitecture.Text = "label2";
            // 
            // lbOSName
            // 
            lbOSName.AutoSize = true;
            lbOSName.Location = new Point(105, 69);
            lbOSName.Name = "lbOSName";
            lbOSName.Size = new Size(43, 17);
            lbOSName.TabIndex = 1;
            lbOSName.Text = "label2";
            // 
            // lbCPU
            // 
            lbCPU.AutoSize = true;
            lbCPU.Location = new Point(80, 53);
            lbCPU.Name = "lbCPU";
            lbCPU.Size = new Size(43, 17);
            lbCPU.TabIndex = 1;
            lbCPU.Text = "label2";
            // 
            // lbPCName
            // 
            lbPCName.AutoSize = true;
            lbPCName.Location = new Point(80, 35);
            lbPCName.Name = "lbPCName";
            lbPCName.Size = new Size(43, 17);
            lbPCName.TabIndex = 1;
            lbPCName.Text = "label2";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(27, 86);
            label13.Name = "label13";
            label13.Size = new Size(92, 17);
            label13.TabIndex = 0;
            label13.Text = "操作系统架构：";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(27, 69);
            label8.Name = "label8";
            label8.Size = new Size(92, 17);
            label8.TabIndex = 0;
            label8.Text = "操作系统名称：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 52);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 0;
            label2.Text = "CPU：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 34);
            label1.Name = "label1";
            label1.Size = new Size(59, 17);
            label1.TabIndex = 0;
            label1.Text = "PC名称：";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // timerQuick
            // 
            timerQuick.Tick += timerQuick_Tick;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(12, 9);
            label15.Name = "label15";
            label15.Size = new Size(40, 17);
            label15.TabIndex = 0;
            label15.Text = "Loc：";
            // 
            // lbFormLoc
            // 
            lbFormLoc.AutoSize = true;
            lbFormLoc.ForeColor = Color.Red;
            lbFormLoc.Location = new Point(58, 9);
            lbFormLoc.Name = "lbFormLoc";
            lbFormLoc.Size = new Size(34, 17);
            lbFormLoc.TabIndex = 1;
            lbFormLoc.Text = "[X,Y]";
            // 
            // FrmSysTool
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gbSysInfo);
            Controls.Add(label15);
            Controls.Add(lbFormLoc);
            Name = "FrmSysTool";
            Text = "系统工具";
            Load += FrmSysTool_Load;
            LocationChanged += FrmSysTool_LocationChanged;
            Move += FrmSysTool_Move;
            gbSysInfo.ResumeLayout(false);
            gbSysInfo.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbGPU.ResumeLayout(false);
            gbGPU.PerformLayout();
            gbRAM.ResumeLayout(false);
            gbRAM.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbSysInfo;
        private Label lbPCName;
        private Label label1;
        private Label lbCPU;
        private Label label2;
        private GroupBox gbRAM;
        private Label lbUsedRAM;
        private Label lbFreeRAM;
        private Label lbTotalRAM;
        private Label label7;
        private Label label5;
        private Label label3;
        private GroupBox gbGPU;
        private Label lbUsedRAM_GPU;
        private Label lbFreeRAM_GPU;
        private Label lbTotalRAM_GPU;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label lbGPUName;
        private Label label4;
        private Label lbGPUDriverVersion;
        private Label label6;
        private GroupBox groupBox1;
        private Label lbScreenInch;
        private Label lbScreenSize;
        private Label label14;
        private Label lbResolution;
        private Label label16;
        private Label lbScreenSizeaaa;
        private Label label19;
        private Label label20;
        private Label lbScreenNum;
        private Label label21;
        private Label lbOSArchitecture;
        private Label lbOSName;
        private Label label13;
        private Label label8;
        private System.Windows.Forms.Timer timer1;
        private Label lbMouseLoc;
        private Label label12;
        private System.Windows.Forms.Timer timerQuick;
        private Label label15;
        private Label lbFormLoc;
    }
}
