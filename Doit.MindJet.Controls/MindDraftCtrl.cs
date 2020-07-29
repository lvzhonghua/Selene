using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Doit.MindJet.MindDrafts;

namespace Doit.MindJet.Controls
{
    public partial class MindDraftCtrl : UserControl
    {
        public MindDraftCtrl()
        {
            InitializeComponent();
        }

        private void panMindDraft_Paint(object sender, PaintEventArgs e)
        {
            MindShape rectShape1 = MindShapeFactory.Create(MindShapeCategory.Rect, new PointF(100f, 100f));

            rectShape1.Text = "测试的矩形";
            rectShape1.Status = GlyphStatus.Current;

            rectShape1.Draw(e.Graphics);

            MindShape rectShape2 = MindShapeFactory.Create(MindShapeCategory.Rect, new PointF(300f, 300f));

            rectShape2.Text = "测试的矩形";
            rectShape2.Status = GlyphStatus.Selected;

            rectShape2.Draw(e.Graphics);

            MindShape rectShape3 = MindShapeFactory.Create(MindShapeCategory.Rect, new PointF(300f, 100f));

            rectShape3.Text = "测试的矩形";
            rectShape3.Status = GlyphStatus.Normal;

            rectShape3.Draw(e.Graphics);

            MindShape rhombShape1 = MindShapeFactory.Create(MindShapeCategory.Rhomb, new PointF(500f, 100f));

            rhombShape1.Text = "测试的菱形";
            rhombShape1.Status = GlyphStatus.Current;

            rhombShape1.Draw(e.Graphics);

            MindShape rhombShape2 = MindShapeFactory.Create(MindShapeCategory.Rhomb, new PointF(200f, 100f));

            rhombShape2.Text = "测试的菱形";
            rhombShape2.Status = GlyphStatus.Selected;

            rhombShape2.Draw(e.Graphics);

            MindShape rhombShape3 = MindShapeFactory.Create(MindShapeCategory.Rhomb, new PointF(400f, 200f));

            rhombShape3.Text = "测试的菱形";
            rhombShape3.Status = GlyphStatus.Normal;

            rhombShape3.Draw(e.Graphics);

            MindShapeConnection connection1 = new MindShapeConnection() { From = rectShape1, To = rhombShape1 };
            connection1.Draw(e.Graphics);

            MindShapeConnection connection2 = new MindShapeConnection() { From = rectShape2, To = rhombShape2};
            connection2.Draw(e.Graphics);

            MindShapeConnection connection3 = new MindShapeConnection() { From = rectShape3, To = rhombShape3 };
            connection3.Draw(e.Graphics);

        }
    }
}
