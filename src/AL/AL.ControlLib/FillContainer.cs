using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.ControlLib
{
    public class FillContainer<T>
        where T:Control
    {

    }

    public class FillPanel:FillBase
    {
        /// <summary>
        /// 父容器
        /// </summary>
        public Panel Container { get; set; }
        public FillPanel(Panel container, Size? itemSize):base(container.Size,itemSize)
        {
            this.Container = container;
        }

        public void Fill<T>(List<T> items,Func<T,Control> itemToControl=null)
        {
            var itemCount = items.Count;

            Panel panel = this.Container;
            panel.Dock = DockStyle.Fill;
            panel.AutoScroll = true; // 启用自动滚动
            var container = panel;

            bool isNull= itemToControl == null;
            if (itemToControl == null)
                itemToControl = (item) => new Button();
            // 设置按钮大小和数量
            for (int i = 0; i < itemCount; i++)
            {
                var itemControl= itemToControl(items[i]);
                var loc = this.GetItemLoc(i);
                itemControl.Location = loc;
                if (isNull)
                {
                    itemControl.Size = this.ItemSize;
                    itemControl.Text = $"{loc.X},{loc.Y}";
                }
                container.Controls.Add(itemControl);
            }
        }
    }

    public class FillBase
    {
        public Size ParentSize { get; set; }
        public Size ItemSize { get; set; }
        public FillBox Box { get; set; }

        public FillBase(Size parentSize, Size? itemSize)
        {
            this.ParentSize = parentSize;
            if (itemSize == null)
                itemSize = new Size(100, 50);
            this.ItemSize = itemSize.Value;
            Init();
        }
        void Init()
        {
            var box = CalBox();
            this.Box = box;
        }

        FillBox CalBox()
        {
            FillBox box = new FillBox();
            Func<int, int, int, int> pandingFunc = (parentSize, itemSize, gridCount)
                => (parentSize - gridCount * itemSize) / gridCount;
            box.GridCount = (this.ParentSize.Width / this.ItemSize.Width, this.ParentSize.Height / this.ItemSize.Height);
            box.xPadding = pandingFunc(this.ParentSize.Width, this.ItemSize.Width, box.GridCount.xCount);
            box.yPadding = pandingFunc(this.ParentSize.Height, this.ItemSize.Height, box.GridCount.yCount);
            box.wSpan = this.ItemSize.Width + box.xPadding;
            box.hSpan = this.ItemSize.Height + box.yPadding;
            box.xFirstPadding = 0;// box.xPadding / 2;//两侧间隔计算需要考虑容器边界值，暂时不处理
            box.yFirstPadding = 0;// box.yPadding / 2;
            return box;
        }

        //index:在items矩阵中的索引位置
        public Point GetItemLoc(int index)
        {
            var i = index;
            var locX = (i % this.Box.GridCount.xCount) * this.Box.wSpan + this.Box.xFirstPadding;
            var locY = (i / this.Box.GridCount.xCount) * this.Box.hSpan + this.Box.yFirstPadding;
            var point = new Point(locX, locY);
            return point;
        }
    }

    public struct FillBox
    {
        public (int xCount, int yCount) GridCount { get; set; }
        /// <summary>
        /// x轴方向格子间填充间隔
        /// </summary>
        public int xPadding { get; set; }
        /// <summary>
        /// y轴方向格子间填充间隔
        /// </summary>
        public int yPadding { get; set; }
        public int xFirstPadding { get; set; }
        public int yFirstPadding { get; set; }
        /// <summary>
        /// x轴方向每个格子宽度
        /// </summary>
        public int wSpan { get; set; }
        /// <summary>
        /// y轴方向每个格子高度
        /// </summary>
        public int hSpan { get; set; }
    }
}
