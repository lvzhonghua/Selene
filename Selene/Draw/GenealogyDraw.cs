using Selene.Draw.CalcStruct;
using Selene.Draw.Enums;
using Selene.Manage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Draw
{
    public class GenealogyDraw
    {
        //页边距离宽度
        static float pageMarginWidth = 50f;
        //页码的高度
        static float pageNumberHeight = 30;
        //边框线的粗细
        static float pageLineThick = 3f;

        public static List<WaitPrintPage> Draw(DrawModelData lineagePlanData)
        {
            var clansmanList = lineagePlanData.ClansmanList;
            var genealogy = lineagePlanData.Genealogy;


            List<WaitPrintPage> waitPrintPages = new List<WaitPrintPage>();
            WaitPrintPage wpp = CreateTemplatePage(lineagePlanData);
            waitPrintPages.Add(wpp);

            lineagePlanData.CurrentPageIndex = ++wpp.PageIndex;
            wpp = CreateTemplatePage(lineagePlanData);
            waitPrintPages.Add(wpp);


            return waitPrintPages;
        }

        private static WaitPrintPage CreateTemplatePage(DrawModelData drawModelData)
        {
            WaitPrintPage page = new WaitPrintPage();
            page.PageIndex = drawModelData.CurrentPageIndex;

            #region 创建rootBlock
            BlockContainer rootBlock = DrawRootBlock(drawModelData);
            page.AddCtrl(rootBlock);
            #endregion

            #region 创建pageBlockContainer容器
            BlockContainer pageBlockContainer = DrawPageBlock(rootBlock, drawModelData.CurrentPageIndex);
            page.AddCtrl(pageBlockContainer);
            page.AddRangeCtrl(pageBlockContainer.Childrens);
            #endregion

            BlockContainer frameBlockContainer = DrawFrameBlock(rootBlock, drawModelData.CurrentPageIndex);
            page.AddCtrl(frameBlockContainer);

            BlockContainer pageMarginBlock = DrawPageMargin(rootBlock, pageBlockContainer, drawModelData);
            page.AddCtrl(pageMarginBlock);
            page.AddRangeCtrl(pageMarginBlock.Childrens);


            return page;
        }

        private static BlockContainer DrawRootBlock(DrawModelData drawModelData)
        {
            var defaultPrintSettings = drawModelData.PageSettings.PrinterSettings.DefaultPageSettings;
            var bounds = defaultPrintSettings.Bounds;
            var graphics = drawModelData.Graphics;
            var margins = drawModelData.PageSettings.Margins;

            //先加入一个顶级容器进去
            //得到可编辑区域
            PointF editLocation = new PointF(bounds.Location.X + margins.Left, bounds.Location.Y + margins.Top);
            SizeF editSizeF = new SizeF(bounds.Size.Width - margins.Left - margins.Right, bounds.Size.Height - margins.Top - margins.Bottom);
            BlockContainer rootBlock = new BlockContainer(editLocation, editSizeF);
            rootBlock.DrawAreaLine = true;
            rootBlock.Graphics = graphics;
            rootBlock.Name = "rootBlock";

            return rootBlock;
        }

        private static BlockContainer DrawPageBlock(BlockContainer rootBlock, int pageIndex)
        {
            BlockContainer pageBlockContainer = new BlockContainer();
            pageBlockContainer.Name = "pageBlockContainer";
            pageBlockContainer.DrawAreaLine = true;
            pageBlockContainer.Parent = rootBlock;
            pageBlockContainer.Location = new PointF(0, 0);
            pageBlockContainer.SizeF = new SizeF(rootBlock.Width, pageNumberHeight);

            Block pageBlock = new Block();
            pageBlock.Text = pageIndex.ToString();
            pageBlock.Font = new Font("黑体", 13f, FontStyle.Bold);
            pageBlock.TextAlign = Align.CenterMiddle;
            pageBlock.SizeF = new SizeF(pageMarginWidth, pageBlockContainer.Height);
            pageBlock.Parent = pageBlockContainer;
            if (pageIndex % 2 == 0)
            {
                pageBlock.Align = Align.LeftMiddle;
            }
            else
            {
                pageBlock.Align = Align.RightMiddle;
            }
            return pageBlockContainer;
        }

        private static BlockContainer DrawFrameBlock(BlockContainer rootBlock,int pageIndex)
        {
            //画一个边框
            BlockContainer frameBlockContainer = new BlockContainer();
            frameBlockContainer.SizeF = new SizeF(rootBlock.Width - pageMarginWidth - pageLineThick, rootBlock.Height - pageNumberHeight - pageLineThick * 2);
            frameBlockContainer.Parent = rootBlock;
            frameBlockContainer.Border = new Border(pageLineThick, pageLineThick, pageLineThick, pageLineThick);

            if (pageIndex % 2 == 0)
            {
                frameBlockContainer.Location = new PointF(pageMarginWidth - pageLineThick, pageNumberHeight);
            }
            else
            {
                frameBlockContainer.Location = new PointF(0, pageNumberHeight);
            }
            return frameBlockContainer;
        }

        private static BlockContainer DrawPageMargin(BlockContainer rootBlock, BlockContainer pageBlockContainer, DrawModelData drawModelData)
        {
            int currentIndex = drawModelData.CurrentPageIndex;

            BlockContainer pageMarginBlock = new BlockContainer();
            pageMarginBlock.Parent = rootBlock;
            if (currentIndex % 2 == 0)
            {
                pageMarginBlock.Location = new PointF(0, pageBlockContainer.Height);
            }
            else
            {
                pageMarginBlock.Location = new PointF(rootBlock.Width - pageMarginWidth + pageLineThick, pageBlockContainer.Height);
            }
            pageMarginBlock.SizeF = new SizeF(pageMarginWidth - pageLineThick, rootBlock.Height - pageBlockContainer.Height);
            pageMarginBlock.DrawAreaLine = true;

            Font font = new Font("黑体", 13f, FontStyle.Bold);

            Block genealogyBlock = new Block();
            genealogyBlock.Parent = pageMarginBlock;
            genealogyBlock.Width = pageMarginBlock.Width;
            genealogyBlock.TextDirection = Direction.Vertical;
            genealogyBlock.Text = "李氏沙滩总祠族谱";
            genealogyBlock.Font = font;
            genealogyBlock.ForeColor = Color.White;
            genealogyBlock.Background = Color.Black;
            genealogyBlock.CalcSize();  //计算了才有高/宽度

            Block sumVolumeBlock = new Block();
            sumVolumeBlock.Parent = pageMarginBlock;
            sumVolumeBlock.Font = font;
            sumVolumeBlock.TextDirection = Direction.Vertical;
            sumVolumeBlock.Text = "全谱九十七卷";
            sumVolumeBlock.Location = new PointF(0, genealogyBlock.Height);
            sumVolumeBlock.Width = pageMarginBlock.Width;
            sumVolumeBlock.CalcSize();  //计算了才有高/宽度

            float sumCurrentSpace = 10f;
            Block currentVolumeBlock = new Block();
            currentVolumeBlock.Parent = pageMarginBlock;
            currentVolumeBlock.Font = font;
            currentVolumeBlock.TextDirection = Direction.Vertical;
            currentVolumeBlock.Text = "第四十七卷";
            currentVolumeBlock.Location = new PointF(0, sumVolumeBlock.Location.Y + sumVolumeBlock.Height + sumCurrentSpace);
            currentVolumeBlock.Width = pageMarginBlock.Width;
            currentVolumeBlock.CalcSize();  //计算了才有高度


            Block bottomBlock = new Block();
            bottomBlock.Parent = pageMarginBlock;
            bottomBlock.Font = font;
            bottomBlock.TextDirection = Direction.Vertical;
            bottomBlock.Background = Color.Black;
            bottomBlock.ForeColor = Color.White;
            if (currentIndex % 2 == 0)
            {
                bottomBlock.Text = "花萼堂";
            }
            else
            {
                bottomBlock.Text = "陇西堂";
            }
            bottomBlock.Width = pageMarginBlock.Width;
            bottomBlock.CalcSize();
            bottomBlock.Location = new PointF(0, pageMarginBlock.Height - bottomBlock.Height);

            Block lineageBlock = new Block();
            lineageBlock.Parent = pageMarginBlock;
            lineageBlock.Font = font;
            lineageBlock.TextDirection = Direction.Vertical;
            if (currentIndex % 2 == 0)
            {
                lineageBlock.Text = "二十三届族谱编委会公元二零一五年乙末续修";
            }
            else
            {
                lineageBlock.Text = "仲先公二房惟隆脉下衍琛公七房世系图";
            }
            float remainHeight = pageMarginBlock.Height - (currentVolumeBlock.Location.Y + currentVolumeBlock.Height + bottomBlock.Height);
            lineageBlock.Location = new PointF(0, currentVolumeBlock.Location.Y + currentVolumeBlock.Height);
            lineageBlock.SizeF = new SizeF(pageMarginBlock.Width, remainHeight);

            return pageMarginBlock;
        }
    }
}
