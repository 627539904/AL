using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AL.ControlLib.Hooks
{
    /// <summary>
    /// 键盘钩子
    /// </summary>
    public class KeyboardHook
    {
        // 引入必要的Windows API函数和常量
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

        private LowLevelKeyboardProc _proc;
        private static IntPtr _hookID = IntPtr.Zero;

        public KeyboardHook()
        {
            _proc = HookCallback;
        }

        // 定义键盘钩子回调函数的委托
        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        // 导入SetWindowsHookEx函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        // 导入CallNextHookEx函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        // 导入UnhookWindowsHookEx函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        // 导入GetModuleHandle函数来获取当前进程的模块句柄
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        // 钩子回调函数
        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var vkCode = Marshal.ReadInt32(lParam);
                var shift = Convert.ToBoolean(Marshal.ReadInt32(lParam, 24) & 0x00010000);
                var ctrl = Convert.ToBoolean(Marshal.ReadInt32(lParam, 24) & 0x00000001);
                var alt = Convert.ToBoolean(Marshal.ReadInt32(lParam, 24) & 0x00000002);

                // 这里可以添加您的按键处理逻辑
                // 示例：将按键信息显示在窗体上的TextBox中（需要一种机制来访问该TextBox）

                // 由于我们不能直接访问WinForms控件，我们可以使用事件来传递按键信息
                bool isKeyDown = (wParam == WM_KEYDOWN);
                if(isKeyDown)
                    OnKeyPressed(new KeyPressedEventArgs((Keys)vkCode, wParam.ToInt32() == WM_KEYDOWN, shift, ctrl, alt));
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        // 安装钩子
        public void InstallHook()
        {
            _hookID = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);

            if (_hookID == IntPtr.Zero)
            {
                throw new Exception("Failed to install keyboard hook.");
            }
        }

        // 卸载钩子
        public void UninstallHook()
        {
            UnhookWindowsHookEx(_hookID);
        }

        // 按键事件
        public event EventHandler<KeyPressedEventArgs> KeyPressed;
        protected virtual void OnKeyPressed(KeyPressedEventArgs e)
        {
            KeyPressed?.Invoke(this, e);
        }

        // 按键事件参数类
        public class KeyPressedEventArgs : EventArgs
        {
            public Keys Key { get; }
            public bool IsKeyDown { get; }
            public bool ShiftPressed { get; }
            public bool CtrlPressed { get; }
            public bool AltPressed { get; }

            public KeyPressedEventArgs(Keys key, bool isKeyDown, bool shiftPressed, bool ctrlPressed, bool altPressed)
            {
                Key = key;
                IsKeyDown = isKeyDown;
                ShiftPressed = shiftPressed;
                CtrlPressed = ctrlPressed;
                AltPressed = altPressed;
            }
        }
    }

    
}
