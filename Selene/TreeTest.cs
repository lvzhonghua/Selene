using Selene.Draw.CalcStruct;
using Selene.Draw.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selene
{
    public partial class TreeTest : Form
    {
        public TreeTest()
        {
            InitializeComponent();
        }
        List<Person> persons = null;
        private void btnStart_Click(object sender, EventArgs e)
        {
            persons = TestData();
            CalcXY(persons);

            DrawTree(persons, plMain.CreateGraphics());
        }

        float blockWidth = 30;
        float blockHeight = 50;
        float widthSpace = 20;
        float heightSpace = 20;

        private void DrawTree(List<Person> persons, Graphics graphics)
        {
            graphics.Clear(Color.White);
            graphics.ScaleTransform(this.tbScale.Value / 100f, this.tbScale.Value / 100f);
            BlockContainer rootBlock = new BlockContainer();
            rootBlock.Graphics = graphics;
            rootBlock.Location = new PointF(10, 10);
            rootBlock.SizeF = new SizeF(plMain.Width - 21, plMain.Height - 21);
            rootBlock.Draw();

            foreach (var person in persons)
            {
                Block block = new Block();
                block.Parent = rootBlock;
                block.DrawAreaLine = true;
                block.Location = new PointF(person.X * (blockWidth + widthSpace), person.Y * (blockHeight + heightSpace));
                block.SizeF = new SizeF(blockWidth, blockHeight);
                block.Text = person.Name;
                block.TextDirection = Direction.Vertical;
                block.Draw();

                if (person.Childrens.Count > 0)
                {
                    BlockContainer blockLine = new BlockContainer();
                    blockLine.Location = new PointF(block.Location.X + blockWidth / 2, block.Location.Y + blockHeight);
                    blockLine.Height = heightSpace;
                    blockLine.Parent = rootBlock;
                    blockLine.Border = new Border() { Left = 2 };
                    blockLine.Draw();

                    if (person.Childrens.Count > 1)
                    {

                        BlockContainer blockLineHor = new BlockContainer();
                        blockLineHor.Location = new PointF(blockLine.Location.X, blockLine.Location.Y + heightSpace / 2);

                        var lastPerson = person.Childrens.Last();
                        float lastPersonX = lastPerson.X * (blockWidth + widthSpace) + blockWidth / 2;
                        blockLineHor.Width = lastPersonX - blockLineHor.Location.X;
                        blockLineHor.Parent = rootBlock;
                        blockLineHor.Border = new Border() { Top = 2 };
                        blockLineHor.Draw();

                        //由底部向上画线
                        foreach (var childPerson in person.Childrens)
                        {
                            BlockContainer blockLineTop = new BlockContainer();
                            float y = childPerson.Y * (blockHeight + heightSpace) - heightSpace / 2;
                            float x = childPerson.X * (blockWidth + widthSpace) + blockWidth / 2;
                            blockLineTop.Location = new PointF(x, y);
                            blockLineTop.Parent = rootBlock;
                            blockLineTop.Height = heightSpace / 2;
                            blockLineTop.Border = new Border() { Left = 2 };
                            blockLineTop.Draw();
                        }
                    }
                }
            }
        }

        private void CalcXY(List<Person> persons)
        {
            persons = persons.OrderBy(p => p.Level).ToList();

            ChildrenJoin(persons);

            Calc(persons);
        }


        private void ChildrenJoin(List<Person> persons)
        {
            var parentLevel = persons.First(p => p.Pid == 0).Level;
            foreach (var person in persons)
            {
                person.Childrens.Clear();
                person.Childrens.AddRange(persons.Where(p => p.Pid == person.Id).ToList());

                person.Y = person.Level - parentLevel;
            }
        }


        private void Calc(List<Person> allPersons)
        {
            var list = allPersons.GroupBy(person => person.Level).Select(g =>
            {
                return new
                {
                    Key = g.Key,
                    Value = g.DefaultIfEmpty().ToList()
                };
            }).ToList();

            list.ForEach(l =>
            {
                Person upPerson = null;
                l.Value.ForEach(p =>
                {
                    if (upPerson != null)
                    {
                        var personX = upPerson.X;
                        if (p.Childrens.Count > 0)
                        {
                            p.X = personX + upPerson.HorCount + 1;
                        }
                        else
                        {
                            p.X = personX + 1;
                        }
                    }
                    if (p.Pid > 0)
                    {
                        //修正一下数据，主要以下考虑
                        //父级的兄弟节点没有子级节点
                        var parentPerson = allPersons.First(pp => pp.Id == p.Pid);
                        if (p.X < parentPerson.X)
                        {
                            p.X = parentPerson.X;
                        }
                    }
                    p.HorCount = CalcChildrenCount(p);
                    
                    upPerson = p;
                });
            });
        }

        //private static int MaxX(Person person)
        //{
        //    if (person.Childrens.Count <= 0)
        //    {
        //        return person.X;
        //    }
        //    int maxX = person.Childrens.Max(p => p.X);
        //    foreach (var item in person.Childrens)
        //    {
        //        var mx = MaxX(item);
        //        maxX = maxX > mx ? person.X : mx;
        //    }
        //    return person.X;
        //}

        private static int CalcChildrenCount(Person person)
        {
            if (person.Childrens == null || person.Childrens.Count <= 0)
            {
                return 0;
            }
            int result = person.Childrens.Count - 1;
            foreach (var cp in person.Childrens)
            {
                result += CalcChildrenCount(cp);
            }
            return result;
        }

        private List<Person> TestData()
        {
            return new List<Person>()
            {
                new Person(){Id=1,Name="a",Pid=0,Level=1,Sort=0},
                new Person(){Id=2,Name="b",Pid=1,Level=2,Sort=0},
                new Person(){Id=21,Name="b1",Pid=1,Level=2,Sort=1},
                new Person(){Id=3,Name="c",Pid=2,Level=3,Sort=1},
                new Person(){Id=31,Name="c1",Pid=2,Level=3,Sort=2},
                new Person(){Id=32,Name="c2",Pid=21,Level=3,Sort=2},
                new Person(){Id=4,Name="d",Pid=3,Level=4,Sort=1},
                new Person(){Id=41,Name="d1",Pid=3,Level=4,Sort=1},
                new Person(){Id=42,Name="d2",Pid=3,Level=4,Sort=1},
            };
        }

        private List<Person> InitData()
        {
            return new List<Person>()
            {
                new Person(){Id=1,Name="廷轩",Pid=0,Level=0},
                new Person(){Id=2,Name="瑶和",Pid=1,Level=1},
                new Person(){Id=3,Name="韫木",Pid=2,Level=2},
                new Person(){Id=4,Name="希便",Pid=3,Level=3},
                new Person(){Id=5,Name="得宽",Pid=4,Level=4},
                new Person(){Id=6,Name="得童",Pid=4,Level=4},
                new Person(){Id=7,Name="兴花",Pid=6,Level=5},
                new Person(){Id=8,Name="希作",Pid=3,Level=3},
                new Person(){Id=9,Name="希淮",Pid=3,Level=3},
                new Person(){Id=10,Name="得意",Pid=9,Level=4},
                new Person(){Id=11,Name="得产",Pid=9,Level=4},
                new Person(){Id=12,Name="兴倚",Pid=11,Level=5},
                new Person(){Id=13,Name="韫杰",Pid=2,Level=2},
                new Person(){Id=14,Name="希廣",Pid=13,Level=3},
                new Person(){Id=15,Name="希席",Pid=13,Level=3},
                new Person(){Id=16,Name="得竟",Pid=15,Level=4},
                new Person(){Id=17,Name="得增",Pid=15,Level=4},
                new Person(){Id=18,Name="希度",Pid=13,Level=3},
                new Person(){Id=19,Name="得耕",Pid=18,Level=4},
                new Person(){Id=20,Name="得章",Pid=18,Level=4},
                new Person(){Id=21,Name="得位",Pid=18,Level=4},
                new Person(){Id=22,Name="兴武",Pid=21,Level=5},
                new Person(){Id=23,Name="文群",Pid=22,Level=6},
                new Person(){Id=24,Name="同镒",Pid=23,Level=7},
                new Person(){Id=25,Name="同锦",Pid=23,Level=7},
                new Person(){Id=26,Name="同镐",Pid=23,Level=7},
                new Person(){Id=27,Name="同泮",Pid=23,Level=7},
                new Person(){Id=28,Name="同水",Pid=23,Level=7},
                new Person(){Id=29,Name="同涧",Pid=23,Level=7},
                new Person(){Id=30,Name="同波",Pid=23,Level=7},
                new Person(){Id=31,Name="尚桂",Pid=30,Level=8},
                new Person(){Id=32,Name="尚梅",Pid=30,Level=8},
                new Person(){Id=33,Name="同漪",Pid=23,Level=7},
                new Person(){Id=34,Name="尚雨",Pid=33,Level=8},
                new Person(){Id=35,Name="文朴",Pid=22,Level=6},
                new Person(){Id=36,Name="同岳",Pid=35,Level=7},
                new Person(){Id=37,Name="文真",Pid=22,Level=6},
                new Person(){Id=38,Name="文奇",Pid=22,Level=6},
                new Person(){Id=39,Name="文纹",Pid=22,Level=6},
                new Person(){Id=40,Name="兴仉",Pid=21,Level=5},
                new Person(){Id=41,Name="文蔚",Pid=40,Level=6},
                new Person(){Id=42,Name="同达",Pid=41,Level=7},
                new Person(){Id=43,Name="尚葵",Pid=42,Level=8},
                new Person(){Id=44,Name="尚方",Pid=42,Level=8},
                new Person(){Id=45,Name="尚华",Pid=42,Level=8},
                new Person(){Id=46,Name="尚芷",Pid=42,Level=8},
                new Person(){Id=47,Name="尚荃",Pid=42,Level=8},
                new Person(){Id=48,Name="尚学",Pid=42,Level=8},
                new Person(){Id=49,Name="文人",Pid=40,Level=6},
                new Person(){Id=50,Name="文台",Pid=40,Level=6},
                new Person(){Id=51,Name="文生",Pid=40,Level=6},
                new Person(){Id=52,Name="兴佛",Pid=21,Level=5},
                new Person(){Id=53,Name="韫述",Pid=2,Level=2},
                new Person(){Id=54,Name="韫传",Pid=2,Level=2},
                new Person(){Id=55,Name="温和",Pid=1,Level=1},
                new Person(){Id=56,Name="韫炳",Pid=55,Level=2},
                new Person(){Id=57,Name="希韩",Pid=56,Level=3},
                new Person(){Id=58,Name="得性",Pid=57,Level=4},
                new Person(){Id=59,Name="兴湘",Pid=58,Level=5},
                new Person(){Id=60,Name="希欧",Pid=56,Level=3},
                new Person(){Id=61,Name="得情",Pid=60,Level=4},
                new Person(){Id=62,Name="兴渤",Pid=61,Level=5},
                new Person(){Id=63,Name="文同",Pid=62,Level=6},
                new Person(){Id=64,Name="文影",Pid=62,Level=6},
                new Person(){Id=65,Name="文光",Pid=62,Level=6},
                new Person(){Id=66,Name="同珍",Pid=65,Level=7},
                new Person(){Id=67,Name="尚仁",Pid=66,Level=8},
                new Person(){Id=68,Name="尚义",Pid=66,Level=8},
                new Person(){Id=69,Name="同琦",Pid=65,Level=7},
                new Person(){Id=70,Name="尚张",Pid=69,Level=8},
                new Person(){Id=71,Name="同官",Pid=65,Level=7},
                new Person(){Id=72,Name="同圭",Pid=65,Level=7},
                new Person(){Id=73,Name="同瑚",Pid=65,Level=7},
                new Person(){Id=74,Name="尚焕",Pid=73,Level=8},
                new Person(){Id=75,Name="尚具",Pid=73,Level=8},
                new Person(){Id=76,Name="得慎",Pid=60,Level=4},
                new Person(){Id=77,Name="兴渤",Pid=76,Level=5},
                new Person(){Id=78,Name="得忖",Pid=60,Level=4},
                new Person(){Id=79,Name="希潮",Pid=56,Level=3},
                new Person(){Id=80,Name="得心",Pid=79,Level=4},
                new Person(){Id=81,Name="兴阁",Pid=80,Level=5},
                new Person(){Id=82,Name="兴汪",Pid=80,Level=5},
                new Person(){Id=83,Name="汪洋",Pid=80,Level=5},
                new Person(){Id=84,Name="韫华",Pid=55,Level=2},
                new Person(){Id=85,Name="希荡",Pid=84,Level=3},
                new Person(){Id=86,Name="得恩",Pid=85,Level=4},
                new Person(){Id=87,Name="得惠",Pid=85,Level=4},
                new Person(){Id=88,Name="得思",Pid=85,Level=4},
                new Person(){Id=89,Name="得葱",Pid=85,Level=4},
                new Person(){Id=90,Name="希浙",Pid=84,Level=3},
                new Person(){Id=91,Name="韫灼",Pid=55,Level=2},
                new Person(){Id=92,Name="希鹤",Pid=91,Level=3},
                new Person(){Id=93,Name="得恺",Pid=92,Level=4},
                new Person(){Id=94,Name="得惟",Pid=92,Level=4},
                new Person(){Id=95,Name="得怡",Pid=92,Level=4},
                new Person(){Id=96,Name="希鹄",Pid=91,Level=3},
                new Person(){Id=97,Name="希鹏",Pid=91,Level=3},
                new Person(){Id=98,Name="希鸣",Pid=91,Level=3},
                new Person(){Id=99,Name="得里",Pid=98,Level=4},
                new Person(){Id=100,Name="兴浩",Pid=99,Level=5},
                new Person(){Id=101,Name="文榜",Pid=100,Level=6},
                new Person(){Id=102,Name="文柳",Pid=100,Level=6},
                new Person(){Id=103,Name="文材",Pid=100,Level=6},
                new Person(){Id=104,Name="文杭",Pid=100,Level=6},
                new Person(){Id=105,Name="文杠",Pid=100,Level=6},
                new Person(){Id=106,Name="得则",Pid=98,Level=4},
                new Person(){Id=107,Name="兴注",Pid=106,Level=5},
                new Person(){Id=108,Name="文相",Pid=107,Level=6},
                new Person(){Id=109,Name="得恒",Pid=98,Level=4},
                new Person(){Id=110,Name="兴溶",Pid=109,Level=5},
                new Person(){Id=111,Name="兴潮",Pid=109,Level=5},
                new Person(){Id=112,Name="兴滟",Pid=109,Level=5},
                new Person(){Id=113,Name="兴源",Pid=109,Level=5},
                new Person(){Id=114,Name="文棋",Pid=113,Level=6},
                new Person(){Id=115,Name="同贵",Pid=114,Level=7},
                new Person(){Id=116,Name="尚谏",Pid=115,Level=8},
                new Person(){Id=117,Name="尚岱",Pid=115,Level=8},
                new Person(){Id=118,Name="尚薰",Pid=115,Level=8},
                new Person(){Id=119,Name="尚吉",Pid=115,Level=8},
                new Person(){Id=120,Name="同显",Pid=114,Level=7},
                new Person(){Id=121,Name="尚辰",Pid=120,Level=8},
                new Person(){Id=122,Name="尚年",Pid=120,Level=8},
                new Person(){Id=123,Name="同哲",Pid=114,Level=7},
                new Person(){Id=124,Name="尚巳",Pid=123,Level=8},
                new Person(){Id=125,Name="尚位",Pid=123,Level=8},
                new Person(){Id=126,Name="同拔",Pid=114,Level=7},
                new Person(){Id=127,Name="尚寅",Pid=126,Level=8},
                new Person(){Id=128,Name="尚省",Pid=126,Level=8},
                new Person(){Id=129,Name="尚质",Pid=126,Level=8},
                new Person(){Id=130,Name="尚晰",Pid=126,Level=8},
                new Person(){Id=131,Name="兴海",Pid=109,Level=5},
                new Person(){Id=132,Name="文柏",Pid=131,Level=6},
                new Person(){Id=133,Name="同煜",Pid=132,Level=7},
                new Person(){Id=134,Name="尚贡",Pid=133,Level=8},
                new Person(){Id=135,Name="尚游",Pid=133,Level=8},
                new Person(){Id=136,Name="尚践",Pid=133,Level=8},
                new Person(){Id=137,Name="同焕",Pid=132,Level=7},
                new Person(){Id=138,Name="同炜",Pid=132,Level=7},
                new Person(){Id=139,Name="文模",Pid=131,Level=6},
                new Person(){Id=140,Name="同熙",Pid=139,Level=7},
                new Person(){Id=141,Name="同二",Pid=139,Level=7},
                new Person(){Id=142,Name="文桃",Pid=131,Level=6},
                new Person(){Id=143,Name="同关",Pid=142,Level=7},
                new Person(){Id=144,Name="同连",Pid=142,Level=7},
                new Person(){Id=145,Name="同思",Pid=142,Level=7},
                new Person(){Id=146,Name="同魁",Pid=142,Level=7},
                new Person(){Id=147,Name="同豹",Pid=142,Level=7},
                new Person(){Id=148,Name="文橒",Pid=131,Level=6},
                new Person(){Id=149,Name="文榆",Pid=131,Level=6},
                new Person(){Id=150,Name="文種",Pid=131,Level=6},
                new Person(){Id=151,Name="同蒸",Pid=150,Level=7},
                new Person(){Id=152,Name="尚清",Pid=151,Level=8},
                new Person(){Id=153,Name="尚明",Pid=151,Level=8},
                new Person(){Id=154,Name="尚笏",Pid=151,Level=8},
                new Person(){Id=155,Name="尚渤",Pid=151,Level=8},
                new Person(){Id=156,Name="同常",Pid=150,Level=7},
                new Person(){Id=157,Name="尚生",Pid=156,Level=8},
                new Person(){Id=158,Name="尚欢",Pid=156,Level=8},
                new Person(){Id=159,Name="同嗣",Pid=150,Level=7},
                new Person(){Id=160,Name="尚云",Pid=159,Level=8},
                new Person(){Id=161,Name="同卢",Pid=150,Level=7},
                new Person(){Id=162,Name="同佑",Pid=150,Level=7},
                new Person(){Id=163,Name="尚喜",Pid=162,Level=8},
                new Person(){Id=164,Name="兴荡",Pid=109,Level=5},
                new Person(){Id=165,Name="文槟",Pid=164,Level=6},
                new Person(){Id=166,Name="文树",Pid=164,Level=6},
                new Person(){Id=167,Name="文桧",Pid=164,Level=6},
                new Person(){Id=168,Name="文橹",Pid=164,Level=6},
                new Person(){Id=169,Name="文楠",Pid=164,Level=6},
                new Person(){Id=170,Name="文鹿",Pid=164,Level=6},
                new Person(){Id=171,Name="文密",Pid=164,Level=6},
                new Person(){Id=172,Name="文柽",Pid=164,Level=6},
                new Person(){Id=173,Name="文桢",Pid=164,Level=6},
                new Person(){Id=174,Name="同欣",Pid=173,Level=7},
                new Person(){Id=175,Name="同宗",Pid=173,Level=7},
                new Person(){Id=176,Name="尚得",Pid=175,Level=8},
                new Person(){Id=177,Name="同望",Pid=173,Level=7},
                new Person(){Id=178,Name="得俞",Pid=98,Level=4},
                new Person(){Id=179,Name="兴汪",Pid=178,Level=5},
                new Person(){Id=180,Name="文机",Pid=179,Level=6},
                new Person(){Id=181,Name="文梅",Pid=179,Level=6},
                new Person(){Id=182,Name="文林",Pid=179,Level=6},
                new Person(){Id=183,Name="兴黄",Pid=178,Level=5},
                new Person(){Id=184,Name="得铭",Pid=98,Level=4},
                new Person(){Id=185,Name="兴楚",Pid=184,Level=5},
                new Person(){Id=186,Name="文桥",Pid=185,Level=6},
                new Person(){Id=187,Name="同灯",Pid=186,Level=7},
                new Person(){Id=188,Name="尚透",Pid=187,Level=8},
                new Person(){Id=189,Name="文梁",Pid=185,Level=6},
                new Person(){Id=190,Name="兴湄",Pid=184,Level=5},
                new Person(){Id=191,Name="文木",Pid=190,Level=6},
                new Person(){Id=192,Name="文松",Pid=190,Level=6},
                new Person(){Id=193,Name="同艳",Pid=192,Level=7},
                new Person(){Id=194,Name="尚荣",Pid=193,Level=8},
                new Person(){Id=195,Name="尚英",Pid=193,Level=8},
                new Person(){Id=196,Name="同灿",Pid=192,Level=7},
                new Person(){Id=197,Name="尚珍",Pid=196,Level=8},
                new Person(){Id=198,Name="同灼",Pid=192,Level=7},
                new Person(){Id=199,Name="尚儒",Pid=198,Level=8},
                new Person(){Id=200,Name="尚庚",Pid=198,Level=8},
                new Person(){Id=201,Name="同益",Pid=192,Level=7},
                new Person(){Id=202,Name="尚近",Pid=201,Level=8},
                new Person(){Id=203,Name="兴淮",Pid=184,Level=5},
                new Person(){Id=204,Name="文朴",Pid=203,Level=6},
                new Person(){Id=205,Name="文相",Pid=203,Level=6},
                new Person(){Id=206,Name="同昆",Pid=205,Level=7},
                new Person(){Id=207,Name="尚元",Pid=206,Level=8},
                new Person(){Id=208,Name="尚喜",Pid=206,Level=8},
                new Person(){Id=209,Name="同文",Pid=205,Level=7},
                new Person(){Id=210,Name="尚春",Pid=209,Level=8},
                new Person(){Id=211,Name="同勿",Pid=205,Level=7},
                new Person(){Id=212,Name="尚连",Pid=211,Level=8},
                new Person(){Id=213,Name="尚申",Pid=211,Level=8},
                new Person(){Id=214,Name="同周",Pid=205,Level=7},
                new Person(){Id=215,Name="同抚",Pid=205,Level=7},
                new Person(){Id=216,Name="同纪",Pid=205,Level=7},
                new Person(){Id=217,Name="同纶",Pid=205,Level=7},
                new Person(){Id=218,Name="同赞",Pid=205,Level=7},
                new Person(){Id=219,Name="尚谷",Pid=218,Level=8},
                new Person(){Id=220,Name="文楷",Pid=203,Level=6},
                new Person(){Id=221,Name="同凤",Pid=220,Level=7},
                new Person(){Id=222,Name="尚庆",Pid=221,Level=8},
                new Person(){Id=223,Name="尚鲁",Pid=221,Level=8},
                new Person(){Id=224,Name="兴济",Pid=184,Level=5},
                new Person(){Id=225,Name="文辑",Pid=224,Level=6},
                new Person(){Id=226,Name="文桧",Pid=224,Level=6},
                new Person(){Id=227,Name="文枫",Pid=224,Level=6},
                new Person(){Id=228,Name="文桁",Pid=224,Level=6},
                new Person(){Id=229,Name="同学",Pid=228,Level=7},
                new Person(){Id=230,Name="同士",Pid=228,Level=7},
                new Person(){Id=231,Name="文析",Pid=224,Level=6},
                new Person(){Id=232,Name="文柝",Pid=224,Level=6},
                new Person(){Id=233,Name="同辉",Pid=232,Level=7},
                new Person(){Id=234,Name="同若",Pid=232,Level=7},
                new Person(){Id=235,Name="同湜",Pid=232,Level=7},
                new Person(){Id=236,Name="尚俸",Pid=235,Level=8},
                new Person(){Id=237,Name="同中",Pid=232,Level=7},
                new Person(){Id=238,Name="同试",Pid=232,Level=7},
                new Person(){Id=239,Name="兴洛",Pid=184,Level=5},
                new Person(){Id=240,Name="文夷",Pid=239,Level=6},
                new Person(){Id=241,Name="兴添",Pid=184,Level=5},
                new Person(){Id=242,Name="文格",Pid=241,Level=6},
                new Person(){Id=243,Name="同龙",Pid=242,Level=7},
                new Person(){Id=244,Name="同燧",Pid=242,Level=7},
                new Person(){Id=245,Name="尚燕",Pid=244,Level=8},
                new Person(){Id=246,Name="尚退",Pid=244,Level=8},
                new Person(){Id=247,Name="尚安",Pid=244,Level=8},
                new Person(){Id=248,Name="尚琬",Pid=244,Level=8},
                new Person(){Id=249,Name="同申",Pid=242,Level=7},
                new Person(){Id=250,Name="同助",Pid=242,Level=7},
                new Person(){Id=251,Name="尚退",Pid=250,Level=8},
                new Person(){Id=252,Name="文棣",Pid=241,Level=6},
                new Person(){Id=253,Name="同鸿",Pid=252,Level=7},
                new Person(){Id=254,Name="尚任",Pid=253,Level=8},
                new Person(){Id=255,Name="尚汉",Pid=253,Level=8},
                new Person(){Id=256,Name="尚江",Pid=253,Level=8},
                new Person(){Id=257,Name="同雁",Pid=252,Level=7},
                new Person(){Id=258,Name="尚慕",Pid=257,Level=8},
                new Person(){Id=259,Name="尚爱",Pid=257,Level=8},
                new Person(){Id=260,Name="尚颜",Pid=257,Level=8},
                new Person(){Id=261,Name="文梅",Pid=241,Level=6},
                new Person(){Id=262,Name="同薰",Pid=261,Level=7},
                new Person(){Id=263,Name="尚俊",Pid=262,Level=8},
                new Person(){Id=264,Name="同志",Pid=261,Level=7},
                new Person(){Id=265,Name="尚林",Pid=264,Level=8},
                new Person(){Id=266,Name="文棠",Pid=241,Level=6},
                new Person(){Id=267,Name="同灌",Pid=266,Level=7},
                new Person(){Id=268,Name="尚用",Pid=267,Level=8},
                new Person(){Id=269,Name="尚位",Pid=267,Level=8},
                new Person(){Id=270,Name="同溪",Pid=266,Level=7},
                new Person(){Id=271,Name="尚望",Pid=270,Level=8},
                new Person(){Id=272,Name="尚金",Pid=270,Level=8},
                new Person(){Id=273,Name="尚玉",Pid=270,Level=8},
                new Person(){Id=274,Name="同炯",Pid=266,Level=7},
                new Person(){Id=275,Name="文杜",Pid=241,Level=6},
                new Person(){Id=276,Name="同矿",Pid=275,Level=7},
                new Person(){Id=277,Name="同星",Pid=275,Level=7},
                new Person(){Id=278,Name="文栋",Pid=241,Level=6},
                new Person(){Id=279,Name="文宋",Pid=241,Level=6},
                new Person(){Id=280,Name="兴汲",Pid=184,Level=5},
                new Person(){Id=281,Name="得奇",Pid=98,Level=4},
                new Person(){Id=282,Name="得翠",Pid=98,Level=4},
                new Person(){Id=283,Name="韫炼",Pid=55,Level=2},
                new Person(){Id=284,Name="让和",Pid=1,Level=1},
                new Person(){Id=285,Name="谦和",Pid=1,Level=1},
                new Person(){Id=286,Name="谟和",Pid=1,Level=1},
            };


            #region 测试数据
            /*return new List<Person>()
            {
                new Person(){Id=1,Name="a",Pid=0,Level=1,Sort=0},
                new Person(){Id=11,Name="a1",Pid=0,Level=1,Sort=1},
                new Person(){Id=12,Name="a2",Pid=0,Level=1,Sort=2},
                new Person(){Id=2,Name="b",Pid=1,Level=2,Sort=0},
                new Person(){Id=21,Name="b1",Pid=1,Level=2,Sort=1},
                new Person(){Id=22,Name="b2",Pid=1,Level=2,Sort=2},
                new Person(){Id=23,Name="b3",Pid=11,Level=2,Sort=3},
                new Person(){Id=24,Name="b4",Pid=11,Level=2,Sort=3},
                new Person(){Id=25,Name="b5",Pid=11,Level=2,Sort=3},
                new Person(){Id=26,Name="b6",Pid=11,Level=2,Sort=3},
                new Person(){Id=27,Name="b7",Pid=12,Level=2,Sort=3},
                new Person(){Id=28,Name="b8",Pid=12,Level=2,Sort=3},
                new Person(){Id=29,Name="b9",Pid=12,Level=2,Sort=3},
                new Person(){Id=210,Name="b10",Pid=12,Level=2,Sort=3},
                new Person(){Id=3,Name="c",Pid=2,Level=3,Sort=0},
                new Person(){Id=31,Name="c1",Pid=21,Level=3,Sort=1},
                new Person(){Id=32,Name="c2",Pid=21,Level=3,Sort=2},
                new Person(){Id=33,Name="c3",Pid=21,Level=3,Sort=3},
                new Person(){Id=34,Name="c4",Pid=22,Level=3,Sort=4},
                new Person(){Id=35,Name="c5",Pid=23,Level=3,Sort=5},
                new Person(){Id=36,Name="c6",Pid=23,Level=3,Sort=5},
                new Person(){Id=37,Name="c7",Pid=24,Level=3,Sort=5},
                new Person(){Id=38,Name="c8",Pid=25,Level=3,Sort=5},
                new Person(){Id=39,Name="c9",Pid=25,Level=3,Sort=5},
                new Person(){Id=310,Name="c10",Pid=25,Level=3,Sort=5},
                new Person(){Id=4,Name="d",Pid=3,Level=4,Sort=0},
                new Person(){Id=41,Name="d1",Pid=31,Level=4,Sort=1},
                new Person(){Id=42,Name="d2",Pid=31,Level=4,Sort=2},
                new Person(){Id=43,Name="d3",Pid=32,Level=4,Sort=3},
                new Person(){Id=44,Name="d4",Pid=32,Level=4,Sort=4},
                new Person(){Id=45,Name="d5",Pid=34,Level=4,Sort=5},
                new Person(){Id=46,Name="d6",Pid=35,Level=4,Sort=6},
                new Person(){Id=47,Name="d7",Pid=35,Level=4,Sort=7},
                new Person(){Id=48,Name="d8",Pid=35,Level=4,Sort=7},
                new Person(){Id=49,Name="d9",Pid=35,Level=4,Sort=7},
                new Person(){Id=410,Name="d10",Pid=35,Level=4,Sort=7},
                new Person(){Id=411,Name="d11",Pid=35,Level=4,Sort=7},
                new Person(){Id=5,Name="e",Pid=4,Level=5,Sort=0},
                new Person(){Id=51,Name="e1",Pid=4,Level=5,Sort=1},
                new Person(){Id=52,Name="e2",Pid=4,Level=5,Sort=2},
                new Person(){Id=53,Name="e3",Pid=41,Level=5,Sort=2},
                new Person(){Id=54,Name="e4",Pid=41,Level=5,Sort=2},
                new Person(){Id=55,Name="e5",Pid=42,Level=5,Sort=2},
                new Person(){Id=56,Name="e6",Pid=42,Level=5,Sort=2},
                new Person(){Id=57,Name="e7",Pid=43,Level=5,Sort=2},
                new Person(){Id=58,Name="e8",Pid=43,Level=5,Sort=2},
                new Person(){Id=59,Name="e9",Pid=43,Level=5,Sort=2},
                new Person(){Id=510,Name="e10",Pid=44,Level=5,Sort=2},
                new Person(){Id=511,Name="e11",Pid=44,Level=5,Sort=2},
                new Person(){Id=512,Name="e12",Pid=45,Level=5,Sort=2},
                new Person(){Id=513,Name="e13",Pid=45,Level=5,Sort=2},
                new Person(){Id=514,Name="e14",Pid=46,Level=5,Sort=2},
                new Person(){Id=6,Name="f",Pid=5,Level=6,Sort=0},
                new Person(){Id=61,Name="f1",Pid=51,Level=6,Sort=1},
                new Person(){Id=62,Name="f2",Pid=51,Level=6,Sort=2},
                new Person(){Id=63,Name="f3",Pid=52,Level=6,Sort=2},
                new Person(){Id=64,Name="f4",Pid=52,Level=6,Sort=2},
                new Person(){Id=65,Name="f5",Pid=52,Level=6,Sort=2},
                new Person(){Id=66,Name="f6",Pid=53,Level=6,Sort=2},
                new Person(){Id=67,Name="f7",Pid=53,Level=6,Sort=2},
                new Person(){Id=68,Name="f8",Pid=53,Level=6,Sort=2},
                new Person(){Id=69,Name="f9",Pid=53,Level=6,Sort=2},
                new Person(){Id=610,Name="f10",Pid=54,Level=6,Sort=2},
                new Person(){Id=611,Name="f11",Pid=54,Level=6,Sort=2},
                new Person(){Id=612,Name="f12",Pid=55,Level=6,Sort=2},
                new Person(){Id=613,Name="f13",Pid=55,Level=6,Sort=2},
                new Person(){Id=614,Name="f14",Pid=56,Level=6,Sort=2},
                new Person(){Id=615,Name="f15",Pid=56,Level=6,Sort=2},
                new Person(){Id=616,Name="f16",Pid=57,Level=6,Sort=2},
                new Person(){Id=617,Name="f17",Pid=57,Level=6,Sort=2},
                new Person(){Id=7,Name="g",Pid=6,Level=7,Sort=0},
                new Person(){Id=71,Name="g1",Pid=6,Level=7,Sort=0},
                new Person(){Id=72,Name="g2",Pid=6,Level=7,Sort=0},
                new Person(){Id=73,Name="g3",Pid=62,Level=7,Sort=0},
                new Person(){Id=74,Name="g4",Pid=62,Level=7,Sort=0},
                new Person(){Id=75,Name="g5",Pid=63,Level=7,Sort=0},
                new Person(){Id=76,Name="g6",Pid=63,Level=7,Sort=0},
                new Person(){Id=77,Name="g7",Pid=65,Level=7,Sort=0},
                new Person(){Id=78,Name="g8",Pid=66,Level=7,Sort=0},
                new Person(){Id=79,Name="g9",Pid=66,Level=7,Sort=0},
                new Person(){Id=710,Name="g10",Pid=66,Level=7,Sort=0},
                new Person(){Id=711,Name="g11",Pid=66,Level=7,Sort=0},
                new Person(){Id=712,Name="g12",Pid=68,Level=7,Sort=0},
                new Person(){Id=713,Name="g13",Pid=68,Level=7,Sort=0},
                new Person(){Id=714,Name="g14",Pid=69,Level=7,Sort=0},
                new Person(){Id=8,Name="h",Pid=7,Level=8,Sort=0},
                new Person(){Id=81,Name="h1",Pid=7,Level=8,Sort=0},
                new Person(){Id=82,Name="h2",Pid=7,Level=8,Sort=0},
                new Person(){Id=83,Name="h3",Pid=7,Level=8,Sort=0},
                new Person(){Id=84,Name="h4",Pid=7,Level=8,Sort=0},
                new Person(){Id=85,Name="h5",Pid=7,Level=8,Sort=0},
                new Person(){Id=86,Name="h6",Pid=71,Level=8,Sort=0},
                new Person(){Id=87,Name="h7",Pid=71,Level=8,Sort=0},
                new Person(){Id=88,Name="h8",Pid=71,Level=8,Sort=0},
                new Person(){Id=89,Name="h9",Pid=72,Level=8,Sort=0},
                new Person(){Id=810,Name="h10",Pid=72,Level=8,Sort=0},
                new Person(){Id=811,Name="h11",Pid=73,Level=8,Sort=0},
                new Person(){Id=812,Name="h12",Pid=73,Level=8,Sort=0},
                new Person(){Id=813,Name="h13",Pid=73,Level=8,Sort=0},
                new Person(){Id=814,Name="h14",Pid=74,Level=8,Sort=0},
                new Person(){Id=815,Name="h15",Pid=74,Level=8,Sort=0},
                new Person(){Id=816,Name="h16",Pid=74,Level=8,Sort=0},
                new Person(){Id=9,Name="i",Pid=8,Level=9,Sort=0},
                new Person(){Id=100,Name="j",Pid=9,Level=10,Sort=0},
                new Person(){Id=101,Name="k",Pid=100,Level=11,Sort=0},
                new Person(){Id=102,Name="l",Pid=101,Level=12,Sort=0}
            };*/
            #endregion
        }

        private void TreeTest_Load(object sender, EventArgs e)
        {

        }

        private void plMain_Paint(object sender, PaintEventArgs e)
        {
            if (persons != null)
            {
                DrawTree(persons, plMain.CreateGraphics());
            }

        }

        private void tbScale_Scroll(object sender, EventArgs e)
        {
            if (persons != null)
            {
                DrawTree(persons, plMain.CreateGraphics());
            }
        }
    }

    class Person
    {
        public Person()
        {
            this.Childrens = new List<Person>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int Pid { get; set; }

        public int Level { get; set; }

        public int Sort { get; set; }

        public List<Person> Childrens { get; set; }

        public int HorCount { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
