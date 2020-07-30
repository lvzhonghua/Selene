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
using Doit.MindJet.Linkers;
using Doit.MindJet.MindFlows;

namespace Doit.MindJet.Controls
{
    public partial class MindDraftCtrl : UserControl
    {
        private MindDraft mindDraft = new MindDraft();

        public MindDraft MindDraft { get { return this.mindDraft; } }

        private Point mousePosition;
        private MindShape currentMindShape = null;

        public MindDraftCtrl()
        {
            InitializeComponent();
        }

        private void panMindDraft_Paint(object sender, PaintEventArgs e)
        {
            this.mindDraft.Draw(e.Graphics);
        }

        private void MindDraftCtrl_Load(object sender, EventArgs e)
        {
            MindShape rectShape1 = MindShapeFactory.Create(MindShapeCategory.Rect, new PointF(100f, 100f));
            rectShape1.Text = "测试的矩形";
            rectShape1.Status = GlyphStatus.Current;
            this.mindDraft.AddShape(rectShape1);

            MindShape rectShape2 = MindShapeFactory.Create(MindShapeCategory.Rect, new PointF(300f, 300f));
            rectShape2.Text = "测试的矩形";
            rectShape2.Status = GlyphStatus.Selected;
            this.mindDraft.AddShape(rectShape2);

            MindShape rectShape3 = MindShapeFactory.Create(MindShapeCategory.Rect, new PointF(300f, 100f));
            rectShape3.Text = "测试的矩形";
            rectShape3.Status = GlyphStatus.Normal;
            this.mindDraft.AddShape(rectShape3);

            MindShape rhombShape1 = MindShapeFactory.Create(MindShapeCategory.Rhomb, new PointF(500f, 100f));
            rhombShape1.Text = "测试的菱形";
            rhombShape1.Status = GlyphStatus.Current;
            this.mindDraft.AddShape(rhombShape1);

            MindShape rhombShape2 = MindShapeFactory.Create(MindShapeCategory.Rhomb, new PointF(200f, 100f));
            rhombShape2.Text = "测试的菱形";
            rhombShape2.Status = GlyphStatus.Selected;
            this.mindDraft.AddShape(rhombShape2);

            MindShape rhombShape3 = MindShapeFactory.Create(MindShapeCategory.Rhomb, new PointF(400f, 200f));
            rhombShape3.Text = "测试的菱形";
            rhombShape3.Status = GlyphStatus.Normal;
            this.mindDraft.AddShape(rhombShape3);

            MindShapeConnection connection1 = new MindShapeConnection() { From = rectShape1, To = rhombShape1 };
            this.mindDraft.AddConnection(connection1);

            MindShapeConnection connection2 = new MindShapeConnection() { From = rectShape2, To = rhombShape2 };
            this.mindDraft.AddConnection(connection2);

            MindShapeConnection connection3 = new MindShapeConnection() { From = rectShape3, To = rhombShape3 };
            this.mindDraft.AddConnection(connection3);

        }

        private void panMindDraft_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    Glyph glyph = this.mindDraft.HitTest(e.Location);
                    if (glyph is MindShape)
                    {
                        this.mousePosition = Control.MousePosition;
                        this.currentMindShape = glyph as MindShape;
                    }
                    if (glyph is MindShapeLinker)
                    {
                        MindShapeLinker linker = glyph as MindShapeLinker;
                        if (this.mindDraft.TempConnection == null) this.mindDraft.TempConnection = new MindShapeConnection();
                        if (this.mindDraft.TempConnection.From == null)
                        {
                            this.mindDraft.TempConnection.From = linker.Parent as MindShape;
                            MindShape tempShape = MindShapeFactory.Create(MindShapeCategory.Temp, e.Location);
                            this.mindDraft.TempConnection.To = tempShape;
                        }
                        else
                        {
                            this.mindDraft.TempConnection.To = linker.Parent as MindShape;
                        }

                    }
                    break;
                case MouseButtons.Right:
                    break;

            }
        }

        private void panMindDraft_MouseUp(object sender, MouseEventArgs e)
        {
            this.currentMindShape = null;

            if (this.mindDraft.TempConnection != null &&
                this.mindDraft.TempConnection.From != null &&
                this.mindDraft.TempConnection.To is TempShape)
            {
                Glyph glyph = this.mindDraft.HitTest(e.Location);

                if (glyph is MindShapeLinker)
                {
                    MindShapeLinker linker = glyph as MindShapeLinker;
                    if (linker.Parent != this.mindDraft.TempConnection.From)
                    {
                        this.mindDraft.TempConnection.To = linker.Parent as MindShape;
                        this.mindDraft.TempConnection.Status = GlyphStatus.Normal;
                        this.mindDraft.AddConnection(this.mindDraft.TempConnection);
                    }
                   
                }
            }

            this.mindDraft.TempConnection = null;
            this.panMindDraft.Refresh();
        }

        private void panMindDraft_MouseMove(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (this.currentMindShape != null)
                    {
                        PointF offset = new PointF(Control.MousePosition.X - this.mousePosition.X,
                                                               Control.MousePosition.Y - this.mousePosition.Y);
                        PointF oldLocation = this.currentMindShape.Location;
                        this.currentMindShape.Location = new PointF(oldLocation.X + offset.X, oldLocation.Y + offset.Y);
                        this.mousePosition = Control.MousePosition;
                        this.panMindDraft.Refresh();
                    }

                    if (this.mindDraft.TempConnection != null &&
                        this.mindDraft.TempConnection.From != null &&
                        this.mindDraft.TempConnection.To is TempShape)
                    {
                        this.mindDraft.TempConnection.To.Location = e.Location;
                        this.mindDraft.TempConnection.Status = GlyphStatus.Selected;
                        this.panMindDraft.Refresh();
                    }

                    break;
                case MouseButtons.Right:
                    break;

            }
        }
    }
}
