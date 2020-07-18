﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Permissions;

namespace Doit.MindJet
{
    /// <summary>
    /// 抽象图元
    /// </summary>
    public abstract class Glyph : IHitable, IDrawable
    {
        /// <summary>
        /// 图元状态
        /// </summary>
        public GlyphStatus Status { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public PointF Location { get; set; }

        /// <summary>
        /// 边界
        /// </summary>
        public RectangleF Bounds { get; protected set; }

        /// <summary>
        /// 区域
        /// </summary>
        public Region Region { get; protected set; } = new Region();

        /// <summary>
        /// 绘图路径
        /// </summary>
        protected GraphicsPath GraphicsPath { get; set; } = new GraphicsPath(FillMode.Winding);


        public virtual Glyph HitTest(PointF point)
        {
            if (this.Region.IsVisible(point)) return this;

            return null;
        }

        public virtual void Draw(Graphics graphics)
        { 
        }

        public virtual void Measure(Graphics graphics)
        {
        }
    }
}
