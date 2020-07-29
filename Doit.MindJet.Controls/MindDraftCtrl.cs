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
            MindShape mindShape1 = MindShapeFactory.Create(MindShapeCategory.Rect, new PointF(100f, 100f));

            mindShape1.Text = "测试的矩形";
            mindShape1.Status = GlyphStatus.Current;

            mindShape1.Draw(e.Graphics);

            MindShape mindShape2 = MindShapeFactory.Create(MindShapeCategory.Rect, new PointF(300f, 300f));

            mindShape2.Text = "测试的矩形";
            mindShape2.Status = GlyphStatus.Selected;

            mindShape2.Draw(e.Graphics);

            MindShape mindShape3 = MindShapeFactory.Create(MindShapeCategory.Rect, new PointF(300f, 100f));

            mindShape3.Text = "测试的矩形";
            mindShape3.Status = GlyphStatus.Normal;

            mindShape3.Draw(e.Graphics);

        }
    }
}
