using Selene.Draw.CalcStruct;
using Selene.Draw.Enums;
using Selene.Logical;
using Selene.Logical.Utils;
using Selene.Manage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Draw
{
    public class LineageMapDraw
    {
        //页边距离宽度
        static float pageMarginWidth = 50f;
        //页码的高度
        static float pageNumberHeight = 30;
        //边框线的粗细
        static float pageLineThick = 3f;

        //左边世数距离左边的距离
        static float leftLineageWidth = 20f;
        //世数的宽/高/线条粗细
        static float lineageWidth = 30f;
        static float lineageHeight = 85f;
        static float lineageBorderThick = 2f;

        //世系图框框的margin
        static Margin treeMapMargin = new Margin(10, 10, 10, 10);

        //名字框的相关属性
        static float nameBlockWidth = 25f;
        static float namePageNumberSpace = 5f;
        static float nameLineSpace = 5f;
        static float nameHorLineSpace = 5f;
        static float nameOfNameSpace = 20f;
        

        public static List<WaitPrintPage> Draw(DrawModelData lineageMapData)
        {
            var clansmanList = lineageMapData.ClansmanList;
            var genealogy = lineageMapData.Genealogy;


            List<WaitPrintPage> waitPrintPages = new List<WaitPrintPage>();
            WaitPrintPage wpp = CreateTemplatePage(lineageMapData);
            waitPrintPages.Add(wpp);

            //lineageMapData.CurrentPageIndex = ++wpp.PageIndex;
            //wpp = CreateTemplatePage(lineageMapData);
            //waitPrintPages.Add(wpp);

            CreateContentBlock(wpp);

            CreateLeftLineage(wpp, lineageMapData);

            CreateTreeMapBlock(wpp);

            return waitPrintPages;
        }

        private static void CreateTreeMapList(WaitPrintPage wpp, DrawModelData lineageMapData)
        {
            //计算处每个人的矩阵左边
        }

        private static void CreateTreeMapBlock(WaitPrintPage wpp)
        {
            BlockContainer lineageBlock = wpp.GetCtrl<BlockContainer>("lineageBlock");
            BlockContainer treeMapBlock = new BlockContainer();
            treeMapBlock.Name = "treeMapBlock";
            treeMapBlock.Parent = lineageBlock;
            treeMapBlock.Location = new PointF(leftLineageWidth + lineageWidth + treeMapMargin.Left, treeMapMargin.Top);
            treeMapBlock.SizeF = new SizeF(lineageBlock.Width - leftLineageWidth - lineageWidth - treeMapMargin.Left - treeMapMargin.Right, lineageBlock.Height - treeMapMargin.Top - treeMapMargin.Bottom);
            treeMapBlock.DrawAreaLine = true;

            wpp.AddCtrl(treeMapBlock);
        }

        private static void CreateLeftLineage(WaitPrintPage wpp, DrawModelData lineageMapData)
        {
            BlockContainer lineageBlock = wpp.GetCtrl<BlockContainer>("lineageBlock");
            var genealogy = lineageMapData.Genealogy;


            //实际高度要加上顶部和底部的边框，还要考虑从第二个开始底部边框和顶部边框会重叠的情况
            float realityLineageHeight = lineageHeight + lineageBorderThick * 2;

            int lineageCount = lineageMapData.Genealogy.WorldImageManageNumber;

            //空余的高度
            float remainingHeight = (lineageBlock.Height - (realityLineageHeight * lineageCount) + lineageBorderThick * (lineageCount - 1)) / 2;

            for (int i = 0; i < lineageCount; i++)
            {
                Block worldNumberBlock = new Block();
                //worldNumberBlock.DrawAreaLine = true;
                worldNumberBlock.Parent = lineageBlock;
                if (i == 0)
                {
                    worldNumberBlock.Location = new PointF(leftLineageWidth, remainingHeight + i * lineageHeight);
                }
                else
                {
                    worldNumberBlock.Location = new PointF(leftLineageWidth, remainingHeight + i * lineageHeight + i * lineageBorderThick);
                }
                worldNumberBlock.SizeF = new SizeF(lineageWidth, lineageHeight);
                worldNumberBlock.Text = CommonUtil.Number2Char(genealogy.AncestorWorldNumber + i) + "世";
                worldNumberBlock.TextDirection = Direction.Vertical;
                worldNumberBlock.Border = new Border(lineageBorderThick, lineageBorderThick, lineageBorderThick, lineageBorderThick);

                wpp.AddCtrl(worldNumberBlock);
            }
        }

        private static void CreateContentBlock(WaitPrintPage wpp)
        {
            BlockContainer rootBlock = wpp.GetCtrl<BlockContainer>("rootBlock");

            BlockContainer contentBlock = new BlockContainer();
            contentBlock.Name = "contentBlock";
            contentBlock.DrawAreaLine = true;
            contentBlock.Parent = rootBlock;
            if (wpp.PageIndex % 2 == 0)
            {
                contentBlock.Location = new PointF(pageMarginWidth, pageNumberHeight + pageLineThick);
            }
            else
            {
                contentBlock.Location = new PointF(0, pageNumberHeight + pageLineThick);
            }
            
            contentBlock.SizeF = new SizeF(rootBlock.Width - pageMarginWidth, rootBlock.Height - pageNumberHeight - pageLineThick);
            wpp.AddCtrl(contentBlock);

            CreateTitleBlock(contentBlock);
            wpp.AddRangeCtrl(contentBlock.Childrens);
        }

        private static void CreateTitleBlock(BlockContainer contentBlock)
        {
            Block titleBlock = new Block();
            titleBlock.Parent = contentBlock;
            titleBlock.Text = "仲先公二房惟隆脉下衍琛公七房世系图";
            titleBlock.Font = new Font("黑体", 16, FontStyle.Bold);
            titleBlock.TextAlign = Align.CenterMiddle;
            titleBlock.Width = contentBlock.Width;
            titleBlock.CalcSize();   //主动计算得到高度
            titleBlock.Height += 10;
            //titleBlock.DrawAreaLine = true;

            Block seqBlock = new Block();
            seqBlock.Parent = contentBlock;
            seqBlock.TextAlign = Align.CenterMiddle;
            seqBlock.Font = titleBlock.Font;
            seqBlock.Text = "(一)";
            seqBlock.Width = contentBlock.Width;
            seqBlock.CalcSize();
            seqBlock.Location = new PointF(0, titleBlock.Height);

            float titleSeqHeight = titleBlock.Height + seqBlock.Height;
            BlockContainer lineageBlock = new BlockContainer();
            lineageBlock.DrawAreaLine = true;
            lineageBlock.Parent = contentBlock;
            lineageBlock.Name = "lineageBlock";
            lineageBlock.SizeF = new SizeF(contentBlock.Width, contentBlock.Height - titleSeqHeight);
            lineageBlock.DrawAreaLine = true;
            lineageBlock.Location = new PointF(0, titleSeqHeight);

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
            //rootBlock.DrawAreaLine = true;
            rootBlock.Graphics = graphics;
            rootBlock.Name = "rootBlock";

            return rootBlock;
        }

        private static BlockContainer DrawPageBlock(BlockContainer rootBlock, int pageIndex)
        {
            BlockContainer pageBlockContainer = new BlockContainer();
            pageBlockContainer.Name = "pageBlockContainer";
            //pageBlockContainer.DrawAreaLine = true;
            pageBlockContainer.Parent = rootBlock;
            pageBlockContainer.Location = new PointF(0, 0);
            pageBlockContainer.SizeF = new SizeF(rootBlock.Width, pageNumberHeight);

            Block pageBlock = new Block();
            pageBlock.Text = pageIndex.ToString();
            pageBlock.Font = new Font("黑体", 13f, FontStyle.Bold);
            pageBlock.TextAlign = Align.CenterMiddle;
            pageBlock.SizeF = new SizeF(pageMarginWidth, pageBlockContainer.Height);
            pageBlock.Parent = pageBlockContainer;

            //画一个横线
            BlockContainer hrBlock = new BlockContainer();
            hrBlock.Parent = pageBlockContainer;
            float hrWidth = pageBlockContainer.Width * 0.3f;
            hrBlock.SizeF = new SizeF(pageBlockContainer.Width - hrWidth, 0f);
            hrBlock.Border = new Border(pageLineThick);

            //画一个竖线
            BlockContainer verBlock = new BlockContainer();
            verBlock.Parent = pageBlockContainer;
            verBlock.Background = Color.Black;

            verBlock.SizeF = new SizeF(pageLineThick, rootBlock.Height);

            if (pageIndex % 2 == 0)
            {
                pageBlock.Align = Align.LeftMiddle;
                hrBlock.Location = new PointF(0, pageBlockContainer.Height);
                verBlock.Location = new PointF(pageMarginWidth - pageLineThick, 0);
            }
            else
            {
                pageBlock.Align = Align.RightMiddle;
                hrBlock.Location = new PointF(hrWidth, pageBlockContainer.Height);
                verBlock.Location = new PointF(rootBlock.Width - pageBlock.Width, 0);
            }

            return pageBlockContainer;
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
            //pageMarginBlock.DrawAreaLine = true;

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
