using AL.ControlLib;
using AL.ControlLib.AControls;
using AL.ControlLib.Converts;
using AL.ControlLib.Hooks;
using System.Windows.Forms;

namespace AL.KeyShowTool
{
    public partial class FrmKeyShow : Form
    {
        private KeyboardHook _keyboardHook;
        public FrmKeyShow()
        {
            InitializeComponent();

            // 实例化KeyboardHook并订阅KeyPressed事件
            _keyboardHook = new KeyboardHook();
            _keyboardHook.KeyPressed += KeyboardHook_KeyPressed;
            // 安装钩子
            _keyboardHook.InstallHook();
        }

        List<string> keyLogList = new List<string>();
        // 处理按键事件
        private void KeyboardHook_KeyPressed(object sender, KeyboardHook.KeyPressedEventArgs e)
        {
            // 在这里处理按键事件，例如将按键信息添加到TextBox中
            // 注意：由于这是全局钩子，因此您可能需要考虑线程安全性
            if (InvokeRequired)
            {
                BeginInvoke(new Action<object, KeyboardHook.KeyPressedEventArgs>(KeyboardHook_KeyPressed), sender, e);
                return;
            }
            string keyString = KeysMapping.KeyString(e.Key);
            keyLogList.Add(keyString);
            //int lastCount = LastItemCount(keyLogList);
            //var lastItem = keyLogList.LastOrDefault();
            //if (lastCount > 1)
            //    displayText = $"{lastItem}×{lastCount}";
            //else
            //    displayText = lastItem;
            if(keyLogList.Count > 50)
            {
                keyLogList.RemoveRange(0, 40);
            }
            var printList= keyLogList.TakeLast(10).ToList();
            displayText = string.Join(" ", printList);
            RePaintText(displayText);
        }

        private NotifyIcon notifyIcon;
        string displayText = "Press a key...";
        Font font = new Font("Arial", 24, FontStyle.Bold);// 字体设置
        private void FrmKeyShow_Load(object sender, EventArgs e)
        {
            // 加载并显示图片或文字（这里以文字为例）
            this.Paint += (s, pe) =>
            {
                Color outlineColor = Color.Black; // 黑色边框（通过阴影模拟）
                // 绘制文本的阴影（模拟边框效果）
                float x=10,y=10;
                var startLoc = RightAlignLoc(x, y);
                x= startLoc.X;
                pe.Graphics.DrawString(displayText, font, new SolidBrush(outlineColor), new PointF(x + 5, y + 5)); // 偏移1个像素
                pe.Graphics.DrawString(displayText, font, Brushes.White, new PointF(x, y));
            };

            // 调整窗体大小和位置
            this.Width = 1000;
            this.Height = 100;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width - 10, Screen.PrimaryScreen.Bounds.Height - this.Height - 10);


            // 设置窗体属性
            this.ShowInTaskbar = false;//不显示在任务栏
            this.DoubleBuffered = true;//双缓冲,防止闪烁
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.BackColor = Color.Magenta;
            this.TransparencyKey = Color.Magenta; // 透明键，设置为透明键颜色的部分将透明，可以看到窗体后面的内容

            // 初始化托盘图标
            //notifyIcon = new NotifyIcon();
            //notifyIcon.Icon = SystemIcons.Application; // 使用系统图标，你可以替换为自己的图标
            //notifyIcon.Text =this.Text;
            //notifyIcon.Visible = true; // 初始化时不隐藏托盘图标
            //NotifyIconRightMenu<FrmKeyShow>.CreateMenu(this);
            this.CreateMenu_NotifyIcon()
                .AddSettingMenuItem(new FrmSettings() { Parent = this });
        }

        // 计算文本的右对齐绘制开始位置
        PointF RightAlignLoc(float x, float y)
        {
            // 计算文本的宽度
            SizeF textSize = TextRenderer.MeasureText(displayText, font);

            // 计算右对齐的起始X坐标（注意要减去文本的宽度和一定的内边距）
            x = this.ClientSize.Width - textSize.Width - 10; // 留出10像素的内边距
            //float y = textRect.Y + (textRect.Height - font.GetHeight()) / 2; // 垂直居中
            return new PointF(x, y);
        }

        private void MyForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black); // 清除背景为黑色

            // 绘制文本的背景矩形（可选，用于更好地观察右对齐效果）
            Rectangle textRect = new Rectangle(0, 10, this.ClientSize.Width - 20, 30); // 留出一些边距
            g.FillRectangle(Brushes.LightGray, textRect);

            // 计算文本的宽度
            SizeF textSize = TextRenderer.MeasureText(displayText, font);

            // 计算右对齐的起始X坐标（注意要减去文本的宽度和一定的内边距）
            float x = this.ClientSize.Width - textSize.Width - 10; // 留出10像素的内边距
            float y = textRect.Y + (textRect.Height - font.GetHeight()) / 2; // 垂直居中

            // 绘制文本（白色前景色）
            g.DrawString(displayText, font, Brushes.White, new PointF(x, y));
        }

        #region 窗体移动
        private bool _isDragging = false;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;

        private void FrmKeyShow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _dragCursorPoint = Cursor.Position;
                _dragFormPoint = this.Location;
            }
        }

        private void FrmKeyShow_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
                this.Location = Point.Add(_dragFormPoint, new Size(diff));
            }
        }

        private void FrmKeyShow_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = false;
            }
        }
        #endregion

        public int LastItemCount(List<string> list)
        {
            var lastItem = keyLogList.LastOrDefault();
            var listCopy = new List<string>(list);
            listCopy.Reverse();
            var firstOtherItem = listCopy.FirstOrDefault(p => p != lastItem);
            var firstOtherIndex = listCopy.IndexOf(firstOtherItem);
            int count = firstOtherIndex;
            return count;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] == lastItem)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }

        void RePaintText(string text)
        {
            displayText = text;
            this.Invalidate();// 触发重绘
        }

        private void FrmKeyShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _keyboardHook.UninstallHook();
        }
    }
}
