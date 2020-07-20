using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Doit.MindJet
{
    /// <summary>
    /// 样式
    /// </summary>
    public class StyleSchema
    {
        /// <summary>
        /// 水平间隙（默认：4f）
        /// </summary>
        [DisplayName("水平间隙"), Description("水平方向的间隙")]
        public float HorizontalSpace { get; set; } = 4f;

        /// <summary>
        /// 垂直间隙（默认：4f）
        /// </summary>
        [DisplayName("垂直间隙"), Description("垂直方向的间隙")]
        public float VerticalSpace { get; set; } = 4f;

        /// <summary>
        /// 文字字体（默认：宋体，12f）
        /// </summary>
        [DisplayName("文本字体"),Description("显示文本所使用的字体")]
        public Font TextFont { get; set; } = new Font("宋体",10f);

        /// <summary>
        /// 正常状态的文字的颜色（默认：黑色）
        /// </summary>
        [DisplayName("正常文本颜色"), Description("文本正常状态的颜色")]
        public Color TextColor_Normal { get; set; } = Color.Black;

        /// <summary>
        /// 选中状态的文字的颜色（默认：红色）
        /// </summary>
        [DisplayName("选中文本颜色"), Description("文本选中状态的颜色")]
        public Color TextColor_Selected { get; set; } = Color.Red;

        /// <summary>
        /// 位于当前状态的文字的颜色（默认：蓝色）
        /// </summary>
        [DisplayName("当前文本颜色"), Description("文本当前状态的颜色")]
        public Color TextColor_Current { get; set; } = Color.Blue;

        /// <summary>
        /// 正常状态边框的粗细
        /// </summary>
        [DisplayName("正常边框宽度"), Description("正常状态边框的粗细")]
        public float FrameWidth_Normal { get; set; } = 1f;

        /// <summary>
        /// 选择状态边框的粗细
        /// </summary>
        [DisplayName("选中边框宽度"), Description("选中状态边框的粗细")]
        public float FrameWidth_Selected { get; set; } = 2f;

        /// <summary>
        /// 位于当前状态边框的粗细
        /// </summary>
        [DisplayName("当前边框宽度"), Description("当前状态边框的粗细")]
        public float FrameWidth_Current { get; set; } = 2f;

        /// <summary>
        /// 正常状态的边框的颜色（默认：蓝色）
        /// </summary>
        [DisplayName("正常边框颜色"), Description("正常状态边框的颜色")]
        public Color FrameColor_Normal { get; set; } = Color.Blue;

        /// <summary>
        /// 选状态的边框的颜色（默认：红色）
        /// </summary>
        [DisplayName("选中边框颜色"), Description("选中状态边框的颜色")]
        public Color FrameColor_Selected { get; set; } = Color.Red;

        /// <summary>
        /// 位于当前状态的边框的颜色（默认：绿色）
        /// </summary>
        [DisplayName("当前边框颜色"), Description("当前状态边框的颜色")]
        public Color FrameColor_Current { get; set; } = Color.Green;

        /// <summary>
        /// 边框的线型
        /// </summary>
        [DisplayName("边框线型"), Description("边框的线型")]
        public DashStyle FrameDashStyle { get; set; } = DashStyle.Solid;

        /// <summary>
        /// 连接线的粗细
        /// </summary>
        [DisplayName("连接线粗细"), Description("连接线的粗细")]
        public float LinkLineWidth { get; set; } = 1f;

        /// <summary>
        /// 正常连接线的颜色（默认：蓝色）
        /// </summary>
        [DisplayName("正常连接线颜色"), Description("正常连接线的颜色")]
        public Color LinkLineColor_Normal { get; set; } = Color.Blue;

        /// <summary>
        /// 选择状态的连接线的颜色（默认：红色）
        /// </summary>
        [DisplayName("选择状态的连接线颜色"), Description("选择状态的连接线的颜色")]
        public Color LinkLineColor_Selected { get; set; } = Color.Red;

        /// <summary>
        /// 位于当前状态的连接线的颜色（默认：绿色）
        /// </summary>
        [DisplayName("当前状态连接线颜色"), Description("位于当前状态的连接线的颜色")]
        public Color LinkLineColor_Current { get; set; } = Color.Green;

        /// <summary>
        /// 连接点的半径（默认：5f）
        /// </summary>
        [DisplayName("连接点半径"), Description("连接点的半径")]
        public float LinkerRadius { get; set; } = 5f;

        /// <summary>
        /// 连接线的线型
        /// </summary>
        [DisplayName("连接线线型"), Description("连接线的线型")]
        public DashStyle LinkLineDashStyle { get; set; } = DashStyle.Dash;

        private StyleSchema() {}

        private static StyleSchema currentSchema = new StyleSchema();
        
        /// <summary>
        /// 样式的单例
        /// </summary>
        public static StyleSchema CurrentSchema 
        {
            get { return currentSchema; }
        }

        private static Pen framePen_Normal = null;
        private static Pen framePen_Selected = null;
        private static Pen framePen_Current = null;

        private static Pen GetFramePen_Normal()
        {
            if (framePen_Normal == null) framePen_Normal = new Pen(currentSchema.FrameColor_Normal, currentSchema.FrameWidth_Normal);

            if (framePen_Normal.Color != currentSchema.FrameColor_Normal) framePen_Normal.Color = currentSchema.FrameColor_Normal;
            if (framePen_Normal.Width != currentSchema.FrameWidth_Normal) framePen_Normal.Width = currentSchema.FrameWidth_Normal;
            if (framePen_Normal.DashStyle != currentSchema.FrameDashStyle) framePen_Normal.DashStyle = currentSchema.FrameDashStyle;

            return framePen_Normal;
        }

        private static Pen GetFramePen_Selected()
        {
            if (framePen_Selected == null) framePen_Selected = new Pen(currentSchema.FrameColor_Selected, currentSchema.FrameWidth_Selected);

            if (framePen_Selected.Color != currentSchema.FrameColor_Selected) framePen_Selected.Color = currentSchema.FrameColor_Selected;
            if (framePen_Selected.Width != currentSchema.FrameWidth_Selected) framePen_Selected.Width = currentSchema.FrameWidth_Selected;
            if (framePen_Selected.DashStyle != currentSchema.FrameDashStyle) framePen_Selected.DashStyle = currentSchema.FrameDashStyle;

            return framePen_Selected;
        }

        private static Pen GetFramePen_Current()
        {
            if (framePen_Current == null) framePen_Current = new Pen(currentSchema.FrameColor_Current, currentSchema.FrameWidth_Current);

            if (framePen_Current.Color != currentSchema.FrameColor_Current) framePen_Current.Color = currentSchema.FrameColor_Current;
            if (framePen_Current.Width != currentSchema.FrameWidth_Current) framePen_Current.Width = currentSchema.FrameWidth_Current;
            if (framePen_Current.DashStyle != currentSchema.FrameDashStyle) framePen_Current.DashStyle = currentSchema.FrameDashStyle;

            return framePen_Current;
        }

        /// <summary>
        /// 获得绘制边框的画笔
        /// </summary>
        /// <returns>画笔</returns>
        public static Pen GetFramePen(GlyphStatus status)
        {
            Pen pen = null;
            switch (status)
            {
                case GlyphStatus.Normal:
                case GlyphStatus.Unknown:
                default:
                    pen = GetFramePen_Normal();
                    break;
                case GlyphStatus.Selected:
                    pen = GetFramePen_Selected();
                    break;
                case GlyphStatus.Current:
                    pen = GetFramePen_Current();
                    break;
            }
            
            return pen;
        }

        private static Pen linkLinePen_Normal = null;
        private static Pen linkLinePen_Selected = null;
        private static Pen linkLinePen_Current = null;

        private static Pen GetLinkLinePen_Normal()
        {
            if (linkLinePen_Normal == null) linkLinePen_Normal = new Pen(currentSchema.LinkLineColor_Normal, currentSchema.LinkLineWidth);

            if (linkLinePen_Normal.Color != currentSchema.LinkLineColor_Normal) linkLinePen_Normal.Color = currentSchema.LinkLineColor_Normal;
            if (linkLinePen_Normal.Width != currentSchema.LinkLineWidth) linkLinePen_Normal.Width = currentSchema.LinkLineWidth;
            if (linkLinePen_Normal.DashStyle != currentSchema.LinkLineDashStyle) linkLinePen_Normal.DashStyle = currentSchema.LinkLineDashStyle;

            return linkLinePen_Normal;
        }

        private static Pen GetLinkLinePen_Selected()
        {
            if (linkLinePen_Selected == null) linkLinePen_Selected = new Pen(currentSchema.LinkLineColor_Selected, currentSchema.LinkLineWidth);

            if (linkLinePen_Selected.Color != currentSchema.LinkLineColor_Selected) linkLinePen_Selected.Color = currentSchema.LinkLineColor_Selected;
            if (linkLinePen_Selected.Width != currentSchema.LinkLineWidth) linkLinePen_Selected.Width = currentSchema.LinkLineWidth;
            if (linkLinePen_Selected.DashStyle != currentSchema.LinkLineDashStyle) linkLinePen_Selected.DashStyle = currentSchema.LinkLineDashStyle;

            return linkLinePen_Selected;
        }

        private static Pen GetLinkLinePen_Current()
        {
            if (linkLinePen_Current == null) linkLinePen_Current = new Pen(currentSchema.LinkLineColor_Current, currentSchema.LinkLineWidth);

            if (linkLinePen_Current.Color != currentSchema.LinkLineColor_Current) linkLinePen_Current.Color = currentSchema.LinkLineColor_Current;
            if (linkLinePen_Current.Width != currentSchema.LinkLineWidth) linkLinePen_Current.Width = currentSchema.LinkLineWidth;
            if (linkLinePen_Current.DashStyle != currentSchema.LinkLineDashStyle) linkLinePen_Current.DashStyle = currentSchema.LinkLineDashStyle;

            return linkLinePen_Current;
        }

        /// <summary>
        /// 获得绘制连线的画笔
        /// </summary>
        /// <returns>画笔</returns>
        public static Pen GetLinkLinePen(GlyphStatus status)
        {
            Pen pen = null;
            switch (status)
            {
                case GlyphStatus.Normal:
                case GlyphStatus.Unknown:
                default:
                    pen = GetLinkLinePen_Normal();
                    break;
                case GlyphStatus.Selected:
                    pen = GetLinkLinePen_Selected();
                    break;
                case GlyphStatus.Current:
                    pen = GetLinkLinePen_Current();
                    break;
            }

            return pen;
        }

        private static SolidBrush textBrush_Normal = null;
        private static SolidBrush textBrush_Selected = null;
        private static SolidBrush textBrush_Current = null;

        private static Brush GetTextBrush_Normal()
        {
            if (textBrush_Normal == null) textBrush_Normal = new SolidBrush(currentSchema.TextColor_Normal);

            if (textBrush_Normal.Color != currentSchema.TextColor_Normal) textBrush_Normal.Color = currentSchema.TextColor_Normal;

            return textBrush_Normal;
        }

        private static Brush GetTextBrush_Selected()
        {
            if (textBrush_Selected == null) textBrush_Selected = new SolidBrush(currentSchema.TextColor_Selected);

            if (textBrush_Selected.Color != currentSchema.TextColor_Selected) textBrush_Selected.Color = currentSchema.TextColor_Selected;

            return textBrush_Selected;
        }

        private static Brush GetTextBrush_Current()
        {
            if (textBrush_Current == null) textBrush_Current = new SolidBrush(currentSchema.TextColor_Current);

            if (textBrush_Current.Color != currentSchema.TextColor_Current) textBrush_Current.Color = currentSchema.TextColor_Current;

            return textBrush_Current;
        }

        /// <summary>
        /// 获得绘制文字的画刷
        /// </summary>
        /// <returns>画刷</returns>
        public static Brush GetTextBrush(GlyphStatus status)
        {
            Brush brush = null;
            switch (status)
            {
                case GlyphStatus.Normal:
                case GlyphStatus.Unknown:
                default:
                    brush = GetTextBrush_Normal();
                    break;
                case GlyphStatus.Selected:
                    brush = GetTextBrush_Selected();
                    break;
                case GlyphStatus.Current:
                    brush = GetTextBrush_Current();
                    break;
            }

            return brush;
        }

        private static SolidBrush frameBrush_Normal = null;
        private static SolidBrush frameBrush_Selected = null;
        private static SolidBrush frameBrush_Current = null;

        private static Brush GetFrameBrush_Normal()
        {
            if (frameBrush_Normal == null) frameBrush_Normal = new SolidBrush(currentSchema.FrameColor_Normal);

            if (frameBrush_Normal.Color != currentSchema.FrameColor_Normal) frameBrush_Normal.Color = currentSchema.FrameColor_Normal;

            return frameBrush_Normal;
        }

        private static Brush GetFrameBrush_Selected()
        {
            if (frameBrush_Selected == null) frameBrush_Selected = new SolidBrush(currentSchema.FrameColor_Selected);

            if (frameBrush_Selected.Color != currentSchema.FrameColor_Selected) frameBrush_Selected.Color = currentSchema.FrameColor_Selected;

            return frameBrush_Selected;
        }

        private static Brush GetFrameBrush_Current()
        {
            if (frameBrush_Current == null) frameBrush_Current = new SolidBrush(currentSchema.FrameColor_Current);

            if (frameBrush_Current.Color != currentSchema.FrameColor_Current) frameBrush_Current.Color = currentSchema.FrameColor_Current;

            return frameBrush_Current;
        }

        /// <summary>
        /// 获得绘制边框的画刷
        /// </summary>
        /// <returns>画刷</returns>
        public static Brush GetFrameBrush(GlyphStatus status)
        {
            Brush brush = null;
            switch (status)
            {
                case GlyphStatus.Normal:
                case GlyphStatus.Unknown:
                default:
                    brush = GetFrameBrush_Normal();
                    break;
                case GlyphStatus.Selected:
                    brush = GetFrameBrush_Selected();
                    break;
                case GlyphStatus.Current:
                    brush = GetFrameBrush_Current();
                    break;
            }

            return brush;
        }
    }
}
