using Doit.Print.Holders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.Print
{
    /// <summary>
    /// 占位符布局管理器
    /// </summary>
    public class HolderLayoutManager
    {
        private Dictionary<string, IHolder> holders = new Dictionary<string, IHolder>();

        /// <summary>
        /// 占位符字典
        /// </summary>
        public Dictionary<string, IHolder> Holders
        {
            get { return this.holders; }
        }

        private float scale = 1.0f;

        /// <summary>
        /// 缩放倍数
        /// </summary>
        public float Scale
        {
            get { return this.scale; }
            set { this.scale = value; }
        }

        private PointF offset = PointF.Empty;

        /// <summary>
        /// 平移偏移量
        /// </summary>
        public PointF Offset
        {
            get { return this.offset; }
        }

        public Point LastMousePosition { get; set; }

        public Point CurrentMousePosition { get; set; }

        /// <summary>
        /// 添加占位符
        /// </summary>
        /// <param name="holder">占位符</param>
        public void Add(IHolder holder)
        {
            this.holders.Add(holder.GUID, holder);
        }

        /// <summary>
        /// 移除占位符
        /// </summary>
        /// <param name="guid">占位符标识</param>
        public void Remove(string guid)
        {
            this.holders.Remove(guid);
        }

        /// <summary>
        /// 移除占位符
        /// </summary>
        /// <param name="holder">占位符</param>
        public void Remove(IHolder holder)
        {
            this.Remove(holder.GUID);
        }

        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="graphics">绘图板</param>
        public void Draw(Graphics graphics)
        {
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            this.offset.X = this.CurrentMousePosition.X - this.LastMousePosition.X;
            this.offset.Y = this.CurrentMousePosition.Y - this.LastMousePosition.Y;

            graphics.Transform = new System.Drawing.Drawing2D.Matrix(this.scale, 0.0f, 0.0f, this.scale, this.offset.X, this.offset.Y);

            foreach (IHolder holder in this.holders.Values)
            {
                holder.Draw(graphics);
            }
        }

    }
}
