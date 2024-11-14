using AL.SysTool.VModels;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;

namespace AL.SysTool
{
    public partial class FrmSysTool : Form
    {
        public FrmSysTool()
        {
            InitializeComponent();
        }

        RAM ram = new RAM();
        GPUVM gpu = new GPUVM();
        private void FrmSysTool_Load(object sender, EventArgs e)
        {
            //窗体信息
            this.lbFormLoc.Text = $"[{this.Location.X},{this.Location.Y}]";

            //绑定系统信息
            SysInfoVM sysInfo = new SysInfoVM();
            sysInfo.Init();
            this.lbPCName.Text = sysInfo.PCName;
            this.lbCPU.Text = sysInfo.CPU;
            this.lbOSName.Text = sysInfo.OSName;
            this.lbOSArchitecture.Text = sysInfo.OSArch;

            //绑定内存信息
            ram.Init();
            this.lbTotalRAM.Text = ram.Total.ToString();
            this.lbFreeRAM.DataBindings.Add("Text", ram, nameof(ram.Free), false, DataSourceUpdateMode.OnPropertyChanged);
            this.lbUsedRAM.DataBindings.Add("Text", ram, nameof(ram.Used), false, DataSourceUpdateMode.OnPropertyChanged);

            //绑定显示器信息
            ScreenVM screen = new ScreenVM();
            screen.Init();
            this.lbResolution.Text = screen.Resolution;
            this.lbScreenSize.Text = screen.Size;
            this.lbScreenInch.Text = screen.SizeInch;
            this.lbScreenNum.Text = screen.ScreenCount.ToString();

            //绑定GPU信息
            gpu.Init();
            this.lbTotalRAM_GPU.Text = gpu.Total.ToString();
            this.lbFreeRAM_GPU.DataBindings.Add("Text", gpu, nameof(gpu.Free), false, DataSourceUpdateMode.OnPropertyChanged);
            this.lbUsedRAM_GPU.DataBindings.Add("Text", gpu, nameof(gpu.Used), false, DataSourceUpdateMode.OnPropertyChanged);
            this.lbGPUName.Text = gpu.Name;
            this.lbGPUDriverVersion.Text = gpu.DriverVersion;

            // 设置定时器(正常)，刷新速度不高
            timer1.Interval = 1000; // 每秒触发一次
            timer1.Start();
            // 设置定时器（快速），刷新速度快，注意不要使用耗时操作
            this.timerQuick.Interval = 50;
            this.timerQuick.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ram.Refresh();
            gpu.Refresh();
        }

        private void timerQuick_Tick(object sender, EventArgs e)
        {
            var loc = Control.MousePosition;
            this.lbMouseLoc.Text = $"[{loc.X},{loc.Y}]";
        }

        #region 窗体移动

        private void FrmSysTool_LocationChanged(object sender, EventArgs e)
        {
            this.lbFormLoc.Text = $"[{this.Location.X},{this.Location.Y}]";
            ResumeTimer();
        }
        private void FrmSysTool_Move(object sender, EventArgs e)
        {
            PauseTimer();
        }
        private void PauseTimer()
        {
            this.timer1.Stop();
            this.timerQuick.Stop();
        }
        private void ResumeTimer()
        {
            timer1.Start();
            this.timerQuick.Start();
        }
        #endregion
    }
}
