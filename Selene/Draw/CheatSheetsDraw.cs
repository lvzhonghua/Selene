using Selene.Draw.CalcStruct;
using Selene.Draw.Enums;
using Selene.Draw.Message;
using Selene.Logical;
using Selene.Logical.Utils;
using Selene.Manage;
using Selene.Model;
using Selene.Model.SettingModel;
using Selene.Model.SettingModel.Book;
using Selene.UIUtils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene.Draw
{
    public class CheatSheetsDraw
    {
        static float worldNumberHeight = 30;
        static float worldNumberWidth = 90;

        static float nameHeight = 25;
        static float nameWidth = 90;

        //空白列宽
        static float lineSpace = 20;
        //空白列宽中间的黑线
        static float lineSpaceWidth = 3;

        //世数循环控制
        static float worldNumberIndex = 0;
        //画世数时，上一个名字块的个数，便于画当前世数块的时候，要加上名字块的高度
        static float preBlockNameCount = 0;

        //x的距离
        static float startX = 0;

        //页码高度
        static float pageNumberHeight = 30;

        public static List<WaitPrintPage> Draw(DrawModelData drawModelData)
        {
            worldNumberIndex = 0;
            preBlockNameCount = 0;
            startX = 0;

            var clansmanList = drawModelData.ClansmanList;
            var genealogy = drawModelData.Genealogy;
            CheatSheetsSetting cheatSheetsSetting = new CommonSettingBLL().GetCheatSheetsSetting();

            List<WaitPrintPage> waitPrintPages = new List<WaitPrintPage>();
            WaitPrintPage wpp = CreateTemplagePage(drawModelData, cheatSheetsSetting);

            //先加入pages中
            waitPrintPages.Add(wpp);


            #region 循环世系

            //先按世数分个组
            var clansmanGroupWorldNumbers = clansmanList.OrderBy(clansman => clansman.RelativeWorldNumber)
                                                        .GroupBy(clansman => clansman.RelativeWorldNumber)
                                                        .Select(g => new ClansmanGroupWorldNumber { WorldNumber = g.Key + genealogy.AncestorWorldNumber, Count = g.Count(), ClansmanList = g.ToList() });

            foreach (var groupWorldNumbers in clansmanGroupWorldNumbers)
            {
                #region 画世数
                Block blockWorldNumber = DrawBlockWorldNumber(ref wpp, cheatSheetsSetting, groupWorldNumbers, waitPrintPages, drawModelData);
                wpp.AddCtrl(blockWorldNumber);
                #endregion

                #region 画名字
                DrawBlockName(ref wpp, cheatSheetsSetting, groupWorldNumbers, blockWorldNumber, waitPrintPages, drawModelData);
                #endregion

                worldNumberIndex++;

            }
            #endregion



            return waitPrintPages;
        }

        private static WaitPrintPage CreateTemplagePage(DrawModelData drawModelData, CheatSheetsSetting cheatSheetsSetting)
        {
            var genealogy = drawModelData.Genealogy;
            var defaultPrintSettings = drawModelData.PageSettings.PrinterSettings.DefaultPageSettings;
            var bounds = defaultPrintSettings.Bounds;
            var graphics = drawModelData.Graphics;
            var margins = drawModelData.PageSettings.Margins;

            WaitPrintPage page = new WaitPrintPage();
            page.PageIndex = drawModelData.CurrentPageIndex;

            #region 创建rootBlock
            BlockContainer rootBlock = DrawRootBlock(bounds, graphics, margins);
            page.AddCtrl(rootBlock);
            #endregion

            #region 画标题
            Block titleBlock = DrawTitleBlock(genealogy, cheatSheetsSetting, rootBlock);
            page.AddCtrl(titleBlock);
            #endregion

            #region 先画一个世系描述的框框
            BlockContainer worldNumberContainer = DrawWroldNumberContainer(rootBlock, titleBlock);
            page.AddCtrl(worldNumberContainer);
            #endregion

            #region 画页码部分
            Block pageBlock = DrawPageIndex(rootBlock, page.PageIndex);
            page.AddCtrl(pageBlock);
            #endregion

            return page;
        }

        private static void DrawBlockName(ref WaitPrintPage wpp, CheatSheetsSetting cheatSheetsSetting, ClansmanGroupWorldNumber groupWorldNumbers, Block blockWorldNumber, List<WaitPrintPage> waitPrintPages, DrawModelData drawModelData)
        {
            var parentY = blockWorldNumber.Location.Y;
            var parentHeight = blockWorldNumber.MarginRectF.Height;
            int nameIndex = 0;

            BlockContainer worldNumberContainer = wpp.GetCtrl<BlockContainer>("worldNumberContainer");

            foreach (var clansman in groupWorldNumbers.ClansmanList)
            {
                Block blockName = new Block();
                blockName.DrawAreaLine = true;
                blockName.Text = clansman.Name;
                blockName.SizeF = new SizeF(nameWidth, nameHeight);
                blockName.Parent = worldNumberContainer;
                blockName.Font = cheatSheetsSetting.GetContentFont();
                blockName.ForeColor = Color.Black;
                blockName.TextAlign = Align.LeftMiddle;
                blockName.Location = new PointF(startX, parentY + parentHeight + nameIndex * nameHeight);

                BlockContainer blockLine = null;
                if (blockName.IsRegionLegal(ContainsRegion.Bottom))
                {
                    PointF startPoint = new PointF(startX + nameWidth + (lineSpace - lineSpaceWidth) / 2, 0);
                    blockLine = new BlockContainer();
                    blockLine.Location = startPoint;
                    blockLine.Height = blockName.Location.Y;
                    blockLine.Parent = worldNumberContainer;
                    blockLine.Border = new Border() { Left = lineSpaceWidth };

                    startX += nameWidth + lineSpace;
                    worldNumberIndex = -1;
                    nameIndex = 0;
                    preBlockNameCount = 0;
                    parentY = 0;
                    parentHeight = 0;
                    blockName.Location = new PointF(startX, 0);
                }
                if (blockName.IsRegionLegal(ContainsRegion.Right))
                {
                    drawModelData.CurrentPageIndex = ++wpp.PageIndex;
                    wpp = CreateTemplagePage(drawModelData, cheatSheetsSetting);
                    waitPrintPages.Add(wpp);

                    worldNumberContainer = wpp.GetCtrl<BlockContainer>("worldNumberContainer");

                    startX = 0;
                    worldNumberIndex = -1;
                    nameIndex = 0;
                    preBlockNameCount = 0;
                    parentY = 0;
                    parentHeight = 0;

                    blockName.Location = new PointF(startX, 0);
                    blockName.Parent = worldNumberContainer;
                    blockLine = null;
                }

                Block blockNum = new Block();
                blockNum.Parent = blockName;
                blockNum.Align = Align.RightMiddle;
                blockNum.Text = "999";

                nameIndex++;
                preBlockNameCount++;

                wpp.AddCtrl(blockName);
                wpp.AddCtrl(blockNum);
                if (blockLine != null)
                {
                    wpp.AddCtrl(blockLine);
                }
            }
        }

        private static Block DrawBlockWorldNumber(ref WaitPrintPage wpp, CheatSheetsSetting cheatSheetsSetting, ClansmanGroupWorldNumber groupWorldNumbers, List<WaitPrintPage> waitPrintPages, DrawModelData drawModelData)
        {
            BlockContainer worldNumberContainer = wpp.GetCtrl<BlockContainer>("worldNumberContainer");

            Block blockWorldNumber = new Block();
            blockWorldNumber.Parent = worldNumberContainer;
            blockWorldNumber.Text = groupWorldNumbers.WorldNumber + "世";
            blockWorldNumber.SizeF = new SizeF(worldNumberWidth, worldNumberHeight);
            blockWorldNumber.Background = Color.Black;
            blockWorldNumber.ForeColor = Color.White;
            blockWorldNumber.Font = cheatSheetsSetting.GetContentFont();
            blockWorldNumber.Location = new PointF(startX, worldNumberIndex * worldNumberHeight + preBlockNameCount * nameHeight);

            if (groupWorldNumbers.WorldNumber == 36)
            {

            }

            BlockContainer blockLine = null;
            if (blockWorldNumber.IsRegionLegal(ContainsRegion.Bottom))
            {
                //如果超过，则要画一个竖线
                PointF startPoint = new PointF(startX + worldNumberWidth + (lineSpace - lineSpaceWidth) / 2, 0);
                blockLine = new BlockContainer();
                blockLine.Location = startPoint;
                blockLine.Height = blockWorldNumber.Location.Y;
                blockLine.Parent = worldNumberContainer;
                blockLine.Border = new Border() { Left = lineSpaceWidth };

                startX += worldNumberWidth + lineSpace;
                worldNumberIndex = 0;
                preBlockNameCount = 0;
                blockWorldNumber.Location = new PointF(startX, 0);
            }
            if (blockWorldNumber.IsRegionLegal(ContainsRegion.Right))
            {
                drawModelData.CurrentPageIndex = ++wpp.PageIndex;
                wpp = CreateTemplagePage(drawModelData, cheatSheetsSetting);
                waitPrintPages.Add(wpp);

                worldNumberContainer = wpp.GetCtrl<BlockContainer>("worldNumberContainer");

                startX = 0;
                worldNumberIndex = 0;
                preBlockNameCount = 0;

                blockWorldNumber.Parent = worldNumberContainer;
                blockWorldNumber.Location = new PointF(startX, 0);
                blockLine = null;
            }
            if (blockLine != null)
            {
                wpp.AddCtrl(blockLine);
            }
            return blockWorldNumber;
        }

        private static BlockContainer DrawWroldNumberContainer(BlockContainer rootBlock, Block titleBlock)
        {
            BlockContainer worldNumberContainer = new BlockContainer();
            worldNumberContainer.Name = "worldNumberContainer";
            worldNumberContainer.DrawAreaLine = true;
            worldNumberContainer.Parent = rootBlock;
            worldNumberContainer.Margin = new Margin(10);
            worldNumberContainer.Location = new PointF(0, titleBlock.MarginRectF.Size.Height);
            //这里的容器框的大小应该是root的padding减去title的实际大小margin
            float height = rootBlock.PaddingRectF.Size.Height - titleBlock.MarginRectF.Size.Height - worldNumberContainer.Margin.Top - pageNumberHeight;
            worldNumberContainer.SizeF = new SizeF(rootBlock.PaddingRectF.Size.Width, height);

            return worldNumberContainer;
        }

        private static Block DrawTitleBlock(Genealogy genealogy, CheatSheetsSetting cheatSheetsSetting, BlockContainer rootBlock)
        {
            Block titleBlock = new Block();
            titleBlock.Name = "titleBlock";
            titleBlock.Width = rootBlock.Width;
            titleBlock.Font = cheatSheetsSetting.GetTitleFont();
            titleBlock.Text = "湖北应城程氏";
            titleBlock.Parent = rootBlock;
            titleBlock.CalcSize();
            return titleBlock;
        }

        private static BlockContainer DrawRootBlock(Rectangle bounds, Graphics graphics, System.Drawing.Printing.Margins margins)
        {
            //先加入一个顶级容器进去
            //得到可编辑区域
            PointF editLocation = new PointF(bounds.Location.X + margins.Left, bounds.Location.Y + margins.Top);
            SizeF editSizeF = new SizeF(bounds.Size.Width - margins.Left - margins.Right, bounds.Size.Height - margins.Top - margins.Bottom);
            BlockContainer rootBlock = new BlockContainer(editLocation, editSizeF);
            rootBlock.Name = "rootBlock";
            rootBlock.DrawAreaLine = true;
            rootBlock.Graphics = graphics;

            return rootBlock;
        }

        private static Block DrawPageIndex(BlockContainer rootBlock, int pageIndex)
        {
            Block pageBlock = new Block();
            pageBlock.SizeF = new SizeF(rootBlock.Width, pageNumberHeight);
            pageBlock.Font = new Font("黑体", 13f, FontStyle.Bold);
            pageBlock.Text = pageIndex.ToString();
            pageBlock.Parent = rootBlock;
            pageBlock.Location = new PointF(0, rootBlock.PaddingRectF.Height - pageNumberHeight);
            if (pageIndex % 2 == 0)
            {
                pageBlock.TextAlign = Align.LeftMiddle;
                pageBlock.Padding = new Selene.Draw.CalcStruct.Padding() { Left = 10 };
            }
            else
            {
                pageBlock.TextAlign = Align.RightMiddle;
                pageBlock.Padding = new Selene.Draw.CalcStruct.Padding() { Right = 10 };
                pageBlock.SizeF = new SizeF(pageBlock.SizeF.Width - pageBlock.Padding.Right, pageBlock.SizeF.Height);
            }

            return pageBlock;
        }

        public class ClansmanGroupWorldNumber
        {
            public int WorldNumber { get; set; }

            public int Count { get; set; }

            public List<Clansman> ClansmanList { get; set; }
        }
    }


}
