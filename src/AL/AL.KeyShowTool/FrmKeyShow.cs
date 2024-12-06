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

            // ʵ����KeyboardHook������KeyPressed�¼�
            _keyboardHook = new KeyboardHook();
            _keyboardHook.KeyPressed += KeyboardHook_KeyPressed;
            // ��װ����
            _keyboardHook.InstallHook();
        }

        List<string> keyLogList = new List<string>();
        // �������¼�
        private void KeyboardHook_KeyPressed(object sender, KeyboardHook.KeyPressedEventArgs e)
        {
            // �����ﴦ�����¼������罫������Ϣ��ӵ�TextBox��
            // ע�⣺��������ȫ�ֹ��ӣ������������Ҫ�����̰߳�ȫ��
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
            //    displayText = $"{lastItem}��{lastCount}";
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
        Font font = new Font("Arial", 24, FontStyle.Bold);// ��������
        private void FrmKeyShow_Load(object sender, EventArgs e)
        {
            // ���ز���ʾͼƬ�����֣�����������Ϊ����
            this.Paint += (s, pe) =>
            {
                Color outlineColor = Color.Black; // ��ɫ�߿�ͨ����Ӱģ�⣩
                // �����ı�����Ӱ��ģ��߿�Ч����
                float x=10,y=10;
                var startLoc = RightAlignLoc(x, y);
                x= startLoc.X;
                pe.Graphics.DrawString(displayText, font, new SolidBrush(outlineColor), new PointF(x + 5, y + 5)); // ƫ��1������
                pe.Graphics.DrawString(displayText, font, Brushes.White, new PointF(x, y));
            };

            // ���������С��λ��
            this.Width = 1000;
            this.Height = 100;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width - 10, Screen.PrimaryScreen.Bounds.Height - this.Height - 10);


            // ���ô�������
            this.ShowInTaskbar = false;//����ʾ��������
            this.DoubleBuffered = true;//˫����,��ֹ��˸
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.BackColor = Color.Magenta;
            this.TransparencyKey = Color.Magenta; // ͸����������Ϊ͸������ɫ�Ĳ��ֽ�͸�������Կ���������������

            // ��ʼ������ͼ��
            //notifyIcon = new NotifyIcon();
            //notifyIcon.Icon = SystemIcons.Application; // ʹ��ϵͳͼ�꣬������滻Ϊ�Լ���ͼ��
            //notifyIcon.Text =this.Text;
            //notifyIcon.Visible = true; // ��ʼ��ʱ����������ͼ��
            //NotifyIconRightMenu<FrmKeyShow>.CreateMenu(this);
            this.CreateMenu_NotifyIcon()
                .AddSettingMenuItem(new FrmSettings() { Parent = this });
        }

        // �����ı����Ҷ�����ƿ�ʼλ��
        PointF RightAlignLoc(float x, float y)
        {
            // �����ı��Ŀ��
            SizeF textSize = TextRenderer.MeasureText(displayText, font);

            // �����Ҷ������ʼX���꣨ע��Ҫ��ȥ�ı��Ŀ�Ⱥ�һ�����ڱ߾ࣩ
            x = this.ClientSize.Width - textSize.Width - 10; // ����10���ص��ڱ߾�
            //float y = textRect.Y + (textRect.Height - font.GetHeight()) / 2; // ��ֱ����
            return new PointF(x, y);
        }

        private void MyForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black); // �������Ϊ��ɫ

            // �����ı��ı������Σ���ѡ�����ڸ��õع۲��Ҷ���Ч����
            Rectangle textRect = new Rectangle(0, 10, this.ClientSize.Width - 20, 30); // ����һЩ�߾�
            g.FillRectangle(Brushes.LightGray, textRect);

            // �����ı��Ŀ��
            SizeF textSize = TextRenderer.MeasureText(displayText, font);

            // �����Ҷ������ʼX���꣨ע��Ҫ��ȥ�ı��Ŀ�Ⱥ�һ�����ڱ߾ࣩ
            float x = this.ClientSize.Width - textSize.Width - 10; // ����10���ص��ڱ߾�
            float y = textRect.Y + (textRect.Height - font.GetHeight()) / 2; // ��ֱ����

            // �����ı�����ɫǰ��ɫ��
            g.DrawString(displayText, font, Brushes.White, new PointF(x, y));
        }

        #region �����ƶ�
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
            this.Invalidate();// �����ػ�
        }

        private void FrmKeyShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _keyboardHook.UninstallHook();
        }
    }
}
