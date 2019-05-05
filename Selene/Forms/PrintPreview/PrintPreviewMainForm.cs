using Selene.Draw;
using Selene.Logical;
using Selene.Model;
using Selene.Providers.Control;
using Selene.UIUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Selene.Manage;
using Selene.Draw.Message;

namespace Selene.Forms.PrintPreview
{
    public partial class PrintPreviewMainForm : Form
    {

        public PrintPreviewMainForm()
        {
            InitializeComponent();

            this.clansmanBLL = new ClansmanBLL();
            this.genealogyBLL = new GenealogyBLL();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private ClansmanBLL clansmanBLL;
        private GenealogyBLL genealogyBLL;

        private int currPageCount = 0;

        private List<Clansman> clansmanList;
        private Genealogy genealogy;

        private void PrintPreviewMainForm_Load(object sender, EventArgs e)
        {
            InitZoomScale();

            this.cboPageCount.SelectedIndex = 0;

            this.clansmanList = clansmanBLL.GetAllList();
            this.genealogy = genealogyBLL.GetGenealogy();
        }

        private void InitZoomScale()
        {
            this.cboZoomScale.DisplayMember = "Text";
            this.cboZoomScale.ValueMember = "Value";
            this.cboZoomScale.DataSource = new ZoomScaleProvider().GetDataList();

            this.cboZoomScale.SelectedIndex = 0;

            this.ppcPrintMain.AutoZoom = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            currPageCount = 0;
            this.oneLoad = true;
            this.pdMainDocument.Print();

        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            ppcPrintMain.StartPage++;
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (ppcPrintMain.StartPage > 0)
            {
                ppcPrintMain.StartPage--;
            }
        }
        private bool oneLoad = true;
        private List<WaitPrintPage> waitPrintPageList = new List<WaitPrintPage>();
        private void pdMainDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.BurlyWood, e.MarginBounds);
            e.Graphics.DrawRectangle(Pens.Black, e.PageBounds);

            if (oneLoad)
            {
                LoadAllData(e.Graphics, e.PageSettings);
                oneLoad = false;
            }
            if (currPageCount < waitPrintPageList.Count)
            {
                //DrawReferenceLine(e);

                var wp = waitPrintPageList[currPageCount];

                wp.DoDraw(e.Graphics);

                e.HasMorePages = true;
                currPageCount++;
                if (currPageCount == waitPrintPageList.Count)
                {
                    e.HasMorePages = false;
                }
            }

        }

        private void ppcPrintMain_StartPageChanged(object sender, EventArgs e)
        {
            this.numSkip.Text = "" + (ppcPrintMain.StartPage + 1);
        }

        private void cboZoomScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zoomScale = this.cboZoomScale.SelectedValue.ToString();
            if ("auto".Equals(zoomScale))
            {
                this.ppcPrintMain.AutoZoom = true;
            }
            else
            {
                this.ppcPrintMain.AutoZoom = false;
                this.ppcPrintMain.Zoom = double.Parse(zoomScale);
            }

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = this.pdMainDocument;
            DialogResult dialogResult = printDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.currPageCount = 0;
                this.oneLoad = true;
                this.ppcPrintMain.InvalidatePreview();
            }


        }

        private void DrawReferenceLine(PrintPageEventArgs e)
        {
            int horizontalSpace = 50;
            int verticalSpace = 50;

            Rectangle pageRect = e.PageSettings.Bounds;

            //水平数量
            int hcount = pageRect.Height / verticalSpace;
            //垂直数量
            int vcount = pageRect.Width / horizontalSpace;

            Pen pen = new Pen(Brushes.Red, 0.5f);
            pen.DashStyle = DashStyle.DashDot;

            for (int i = 0; i <= hcount; i++)
            {
                e.Graphics.DrawLine(pen, 0, i * horizontalSpace, pageRect.Width, i * horizontalSpace);
                e.Graphics.DrawString((i * horizontalSpace).ToString(), this.Font, Brushes.Blue, new PointF(0, i * horizontalSpace));
            }
            for (int i = 0; i <= vcount; i++)
            {
                e.Graphics.DrawRectangle(pen, i * verticalSpace, 0, i * verticalSpace, pageRect.Height);
                e.Graphics.DrawString((i * verticalSpace).ToString(), this.Font, Brushes.Blue, new PointF(i * verticalSpace, 0));
            }

            e.Graphics.DrawRectangle(Pens.Yellow, e.MarginBounds);
            e.Graphics.DrawRectangle(Pens.Black, e.PageBounds);


        }

        private void cboPageCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currPageCount = int.Parse(this.cboPageCount.SelectedItem.ToString());

            if (currPageCount == 2 || currPageCount == 4)
            {
                this.ppcPrintMain.Columns = 2;
                this.ppcPrintMain.Rows = currPageCount / 2;
            }
            else if (currPageCount == 6 || currPageCount == 8)
            {
                this.ppcPrintMain.Columns = currPageCount / 2;
                this.ppcPrintMain.Rows = 2;
            }
            else
            {
                this.ppcPrintMain.Columns = 1;
                this.ppcPrintMain.Rows = 1;
            }
        }

        private void pdMainDocument_BeginPrint(object sender, PrintEventArgs e)
        {

        }

        private void LoadAllData(Graphics graphics, PageSettings pageSettings)
        {
            this.waitPrintPageList.Clear();

            //开始前，先在内存里面画出来
            DrawModelData drawModelData = new DrawModelData();
            drawModelData.PageSettings = pageSettings;
            drawModelData.ClansmanList = this.clansmanList;
            drawModelData.Genealogy = this.genealogy;
            drawModelData.Graphics = graphics;

            //drawModelData.CurrentPageIndex = this.waitPrintPageList.Count + 1;
            //this.waitPrintPageList.AddRange(CheatSheetsDraw.Draw(drawModelData));

            //重新开始一页
            drawModelData.CurrentPageIndex = this.waitPrintPageList.Count + 1;
            this.waitPrintPageList.AddRange(LineageMapDraw.Draw(drawModelData));

            //重新开始一页
            //drawModelData.CurrentPageIndex = this.waitPrintPageList.Count + 1;
            //this.waitPrintPageList.AddRange(GenealogyDraw.Draw(drawModelData));

            this.Text += string.Format("【共{0}页】",this.waitPrintPageList.Count);
        }

        private void btnPageSetting_Click(object sender, EventArgs e)
        {

            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.EnableMetric = true;
            pageSetupDialog.Document = this.pdMainDocument;
            DialogResult dialogResult = pageSetupDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                this.currPageCount = 0;
                this.oneLoad = true;
                this.ppcPrintMain.InvalidatePreview();
            }
        }
    }
}
