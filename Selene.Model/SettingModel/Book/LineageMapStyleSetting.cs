using Selene.Model.Enums;
using Selene.Model.Enums.Lineage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Selene.Model.SettingModel.Book
{
    public class LineageMapStyleSetting
    {
        /// <summary>
        /// 世系图类型
        /// </summary>
        public LineageMapStyle LMStyle { get; set; }

        /// <summary>
        /// 线条粗细
        /// </summary>
        public LinellaeThicknessStyle LinellaeThickness { get; set; }

        /// <summary>
        /// 线条颜色
        /// </summary>
        public Color LinellaeColor { get; set; }

        /// <summary>
        /// 世表所在页码
        /// </summary>
        public string LiftAtPageNumber { get; set; }

        /// <summary>
        /// 世系图说明
        /// </summary>
        public string LineageMapNote { get; set; }




        /// <summary>
        /// 标题字体
        /// </summary>
        public string TitleFont { get; set; }

        /// <summary>
        /// 世系说明字体
        /// </summary>
        public string LineageNoteFont { get; set; }

        /// <summary>
        /// 世数字体
        /// </summary>
        public string WorldNumberFont { get; set; }

        /// <summary>
        /// 谱名字体
        /// </summary>
        public string ClansmanName { get; set; }

        /// <summary>
        /// 标注字体
        /// </summary>
        public string AnnotationFont { get; set; }

        public LineageMapStyleSetting()
        {
            this.LinellaeColor = Color.Black;
        }
    }
}
