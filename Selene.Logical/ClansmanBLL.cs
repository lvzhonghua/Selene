using Selene.DAL.DAL;
using Selene.DAL.IDAL;
using Selene.Logical.Message;
using Selene.Logical.Utils;
using Selene.Logical.ViewModel;
using Selene.Model;
using Selene.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Selene.Logical
{
    public class ClansmanBLL:IDisposable
    {
        public ClansmanBLL()
        {
            clansmanDAL = new ClansmanDAL();
        }

        protected IClansmanDAL clansmanDAL;

        public List<Clansman> GetAllList()
        {
            return (List<Clansman>)clansmanDAL.GetAllEntityList();
        }

        public List<ClansmanTree> GetAllTreeList()
        {
            var allList = GetAllList();

            int ancestorWorldNumber = new GenealogyBLL().GetAncestorWorldNumber();

            List<ClansmanTree> treeListTop = allList.Where(item => item.Pid == -1).Select(item =>
            {
                var clansmanTree = CommonUtil.AutoCopy<Clansman, ClansmanTree>(item);
                clansmanTree.RelativeWorldNumber = ancestorWorldNumber;
                return clansmanTree;
            }).ToList();


            RecursionClansmanTree(treeListTop, allList);


            return treeListTop;
        }

        private void RecursionClansmanTree(List<ClansmanTree> treeListTop, List<Clansman> allList)
        {
            if (treeListTop == null || treeListTop.Count == 0)
            {
                return;
            }
            foreach (var itemParent in treeListTop)
            {
                //求出子级
                itemParent.Childrens = allList.Where(item => item.Pid == itemParent.Id).Select(item =>
                {
                    var clansmanTree = CommonUtil.AutoCopy<Clansman, ClansmanTree>(item);
                    clansmanTree.RelativeWorldNumber = itemParent.RelativeWorldNumber + 1;
                    return clansmanTree;
                }).ToList();

                RecursionClansmanTree(itemParent.Childrens, allList);
            }
        }

        /// <summary>
        /// 保存始祖的使用下即可
        /// 其它的建议调用下返回ReturnMessage的，会做更多的解析和判断
        /// </summary>
        public bool SaveClansmanRtnBool(Clansman clansman)
        {
            ResolveChildnames(clansman);
            return clansmanDAL.SaveRtnBool(clansman);
        }

        private Clansman SaveClansmanRtnEntity(Clansman clansman)
        {
            ResolveChildnames(clansman);
            return clansmanDAL.SaveRtnEntity(clansman);
        }

        private bool UpdateClansmanRtnBool(Clansman clansman)
        {
            ResolveChildnames(clansman);
            return clansmanDAL.UpdateRtnBool(clansman);
        }


        public ReturnMessage SaveClansmanRtnEntity(string genealogyNote)
        {
            ReturnMessage rm = CreateClansman(genealogyNote);
            if (!rm.Ok)
            {
                return rm;
            }
            Clansman clansman = rm.GetEntity<Clansman>();

            clansman = SaveClansmanRtnEntity(clansman);
            if (clansman == null)
            {
                rm.Message = "保存信息出错";
                rm.Status = MessageStatus.CommonError;
            }
            else
            {
                rm.SetObject(clansman);
            }
            return rm;
        }

        public ReturnMessage SaveClansman(string genealogyNote)
        {
            ReturnMessage rm = CreateClansman(genealogyNote);

            if (!rm.Ok)
            {
                return rm;
            }

            Clansman clansman = rm.GetEntity<Clansman>();
            if (!SaveClansmanRtnBool(clansman))
            {
                rm.Status = MessageStatus.CommonError;
                rm.Message = "信息保存出错1";
            }

            return rm;
        }


        public ReturnMessage UpdateClansman(Clansman clansman)
        {
            ReturnMessage rm = new ReturnMessage();
            if (ChildrenType.ancestor.Equals(clansman.OwnType))
            {
                if (!UpdateClansmanRtnBool(clansman))
                {
                    rm = new ReturnMessage(MessageStatus.CommonError, "信息保存出错2");
                }
                return rm;
            }
            rm = UpdateCreateClansman(clansman);

            if (!rm.Ok)
            {
                return rm;
            }

            if (!UpdateClansmanRtnBool(clansman))
            {
                rm.Status = MessageStatus.CommonError;
                rm.Message = "信息保存出错";
            }

            return rm;
        }

        #region 新增时通过genealogyNote来创建clansman
        private ReturnMessage CreateClansman(string genealogyNote)
        {
            ReturnMessage rm = new ReturnMessage();

            Clansman clansman = new Clansman();
            clansman.GenealogyNote = genealogyNote;

            //先解析谱名
            clansman.Name = ResolveGenealogyName(genealogyNote);
            clansman.ParentNameDesc = ResolveParentNameDesc(genealogyNote);
            if (string.IsNullOrEmpty(clansman.Name) || string.IsNullOrEmpty(clansman.ParentNameDesc))
            {
                rm = new ReturnMessage(MessageStatus.CommonError, "谱名信息出错");
                return rm;
            }

            //在解析父级id
            Clansman clansmanParent = ResolveParent(clansman);
            if (clansmanParent == null || clansmanParent.Id <= 0)
            {
                rm = new ReturnMessage(MessageStatus.CommonError, "子父级关系存在错误1");
                return rm;
            }
            int pid = clansmanParent.Id;

            rm = CheckBrotherSort(clansman.ParentNameDesc, clansmanParent,-1);
            if (!rm.Ok)
            {
                return rm;
            }
            clansman.Sort = int.Parse(rm.GetObject().ToString());

            clansman.RelativeWorldNumber = clansmanParent.RelativeWorldNumber + 1;
            clansman.Sex = ResolveClansmanSex(clansman.ParentNameDesc);
            clansman.OwnType = ResolveChildrenType(clansman.ParentNameDesc);

            clansman.Pid = pid;
            //直接取父级的卷
            clansman.Volume = clansmanParent.Volume;

            rm = CheckBrother(clansman, clansmanParent);
            if (!rm.Ok) { return rm; }

            rm.SetObject(clansman);

            return rm;
        }
        #endregion

        #region 修改时通过genealogyNote来创建clansman
        private ReturnMessage UpdateCreateClansman(Clansman clansman)
        {
            string genealogyNote = clansman.GenealogyNote;
            int oldPid = clansman.Pid;

            ReturnMessage rm = new ReturnMessage();

            //先解析谱名
            clansman.Name = ResolveGenealogyName(genealogyNote);
            clansman.ParentNameDesc = ResolveParentNameDesc(genealogyNote);
            if (string.IsNullOrEmpty(clansman.Name) || string.IsNullOrEmpty(clansman.ParentNameDesc))
            {
                rm = new ReturnMessage(MessageStatus.CommonError, "谱名信息出错");
                return rm;
            }

            //在解析父级id
            Clansman clansmanParent = ResolveParent(clansman);
            if (clansmanParent == null || clansmanParent.Id <= 0)
            {
                rm = new ReturnMessage(MessageStatus.CommonError, "子父级关系存在错误1");
                return rm;
            }
            int pid = clansmanParent.Id;

            rm = CheckBrotherSort(clansman.ParentNameDesc, clansmanParent,clansman.Id);
            if (!rm.Ok)
            {
                return rm;
            }
            clansman.Sort = int.Parse(rm.GetObject().ToString());

            clansman.RelativeWorldNumber = clansmanParent.RelativeWorldNumber + 1;
            clansman.Sex = ResolveClansmanSex(clansman.ParentNameDesc);
            clansman.OwnType = ResolveChildrenType(clansman.ParentNameDesc);

            clansman.Pid = pid;
            //直接取父级的卷
            clansman.Volume = clansmanParent.Volume;

            //如果更换了父级，那么就要验证brother，否则就不用验证brother
            if (oldPid != pid)
            {
                rm = CheckBrother(clansman, clansmanParent);
                if (!rm.Ok) { return rm; }
            }

            return rm;
        }
        #endregion

        #region 各种单个属性的数据解析

        /// <summary>
        /// 单纯解析谱名
        /// </summary>
        public string ResolveGenealogyName(string genealogyNote)
        {
            int firstComma = genealogyNote.IndexOf(CommonBLLMessage.Comma);
            if (firstComma < 0)
            {
                return genealogyNote;
            }
            return genealogyNote.Substring(0, genealogyNote.IndexOf(CommonBLLMessage.Comma));
        }

        public string ResolveParentNameDesc(string genealogyNote)
        {
            string[] noteStr = genealogyNote.Split(CommonBLLMessage.Comma.ToCharArray());
            if (noteStr != null && noteStr.Length > 1)
            {
                return noteStr[1];
            }
            return null;
        }

        public int ResolveClansmanSex(string parentNameDesc)
        {
            if (string.IsNullOrEmpty(parentNameDesc))
            {
                return -1;
            }
            if (parentNameDesc.IndexOf("子") > 0)
            {
                return SexStatus.male;
            }
            if (parentNameDesc.IndexOf("女") > 0)
            {
                return SexStatus.female;
            }
            return -1;
        }

        public int ResolveClansmanSort(string parentNameDesc)
        {
            if (string.IsNullOrEmpty(parentNameDesc))
            {
                return -1;
            }
            //天公长子、天公之子：之子代表只有一个情况
            if (parentNameDesc.IndexOf("长") > 0 || parentNameDesc.IndexOf("之") > 0)
            {
                return 1;
            }
            if (parentNameDesc.IndexOf("次") > 0)
            {
                return 2;
            }
            if (parentNameDesc.IndexOf("幼") > 0)
            {
                return 99;
            }
            //正则提取一下 数字的模式
            string regex = "[一二三四五六七八九零十百千万亿]+";
            Match match = Regex.Match(parentNameDesc, regex);
            if (match.Success)
            {
                return CommonUtil.ChinaToNumber(match.Value);
            }
            return -1;
        }

        public ReturnMessage CheckBrotherSort(string parentNameDesc, Clansman parentClansman,int id)
        {
            int sort = ResolveClansmanSort(parentNameDesc);
            if (sort <= 0)
            {
                return new ReturnMessage(MessageStatus.CommonError, "生子排序信息有误");
            }
            int childrenCount = parentClansman.SonChildrenNames.Count(item => item.Equals(','))+1;

            if (sort > childrenCount)
            {
                return new ReturnMessage(MessageStatus.CommonError, "生子排序信息有误1");
            }

            if (childrenCount > 1)
            {
                if (parentNameDesc.IndexOf("之") >= 0)
                {
                    return new ReturnMessage(MessageStatus.CommonError, "生子排序信息有误2");
                }
            }
            
            //判断是否存在长子、二子、三子等信息的情况
            if (clansmanDAL.CheckPersonSortExist(parentClansman.Id, sort,id))
            {
                return new ReturnMessage(MessageStatus.CommonError, "已经存在对应的生子序号了");
            }

            ReturnMessage rm = new ReturnMessage();
            rm.SetObject(sort);
            return rm;
        }

        /// <summary>
        /// 解析父级名称
        /// </summary>
        public string ResolveParentName(string parentNameDesc)
        {
            if (string.IsNullOrEmpty(parentNameDesc))
            {
                return null;
            }

            string regex = "(长|之|次|[一二三四五六七八九零十百千万亿]+)(子|女)";

            return Regex.Replace(parentNameDesc, regex, "");
        }

        public Clansman ResolveParent(Clansman clansman)
        {
            string ownName = clansman.Name;
            string parentName = ResolveParentName(clansman.ParentNameDesc);

            if (string.IsNullOrEmpty(ownName) || string.IsNullOrEmpty(parentName))
            {
                return null;
            }

            //根据谱名和parentName得到parentId
            return clansmanDAL.GetClansmanParent(ownName, parentName);

        }



        //验证输入规则:兄弟重复
        public ReturnMessage CheckBrother(Clansman clansman, Clansman clansmanParent)
        {
            ReturnMessage rm = new ReturnMessage();
            string genealogyNote = clansman.GenealogyNote;

            string ownName = clansman.Name;
            string parentName = ResolveParentName(clansman.ParentNameDesc);

            string parentNameDesc = ResolveParentNameDesc(genealogyNote);

            #region 检测同级信息是否合规
            //已经有的兄弟个数
            int brotherCount = clansmanDAL.GetCurrentChildrenCount(clansman.Pid, clansman.OwnType);
            //父级描述信息中存在的兄弟格式
            int parentBrotherCount = 0;
            //检测兄弟,判断个数，是否以及录入了指定的格式
            if (ChildrenType.son.Equals(clansman.OwnType))
            {
                parentBrotherCount = string.IsNullOrEmpty(clansmanParent.SonChildrenNames) ? 0 : clansmanParent.SonChildrenNames.Count(item => item.Equals(',')) + 1;
            }
            else if (ChildrenType.daughter.Equals(clansman.OwnType))
            {
                parentBrotherCount = string.IsNullOrEmpty(clansmanParent.DaughterChildrenNames) ? 0 : clansmanParent.DaughterChildrenNames.Count(item => item.Equals(',')) + 1;
            }
            else if (ChildrenType.heir.Equals(clansman.OwnType))
            {
                parentBrotherCount = string.IsNullOrEmpty(clansmanParent.HeirChildrenNames) ? 0 : clansmanParent.HeirChildrenNames.Count(item => item.Equals(',')) + 1;
            }
            if (brotherCount >= parentBrotherCount)
            {
                return new ReturnMessage(MessageStatus.CommonError, "子父级信息存在错误2");
            }
            #endregion

            #region 检测是否已经存在同名的子级
            if (clansmanDAL.CheckPersonExist(ownName, clansman.Pid))
            {
                return new ReturnMessage(MessageStatus.CommonError, "已经存在该子级信息");
            }
            #endregion


            return rm;
        }


        /// <summary>
        /// 得到当前人的子级类型
        /// </summary>
        public string ResolveChildrenType(string parentNameDesc)
        {
            string sonRegex = "(长|之|次|[一二三四五六七八九零十百千万亿]+)子";
            string daughterRegex = "(长|之|次|[一二三四五六七八九零十百千万亿]+)子";
            if (Regex.IsMatch(parentNameDesc, sonRegex))
            {
                return ChildrenType.son;
            }
            else if (Regex.IsMatch(parentNameDesc, daughterRegex))
            {
                return ChildrenType.daughter;
            }
            else
            {
                return ChildrenType.heir;
            }

        }

        private void ResolveChildnames(Clansman clansman)
        {
            List<string> childnames = new List<string>();
            CommonBLLMessage.GenealogyChildren.ToList().ForEach(item =>
            {
                CheckBirthResult result = GenealogyNoteResolve.CheckBirth(clansman.GenealogyNote, item);
                if (result.Legal && result.BodyNames != null && result.BodyNames.Count > 0)
                {
                    childnames.AddRange(result.BodyNames);
                    if (item.Equals("生子"))
                    {
                        clansman.SonChildrenNames = string.Join(",", result.BodyNames);
                    }
                    else if (item.Equals("生女"))
                    {
                        clansman.DaughterChildrenNames = string.Join(",", result.BodyNames);
                    }
                    else if (item.Equals("嗣子"))
                    {
                        clansman.HeirChildrenNames = string.Join(",", result.BodyNames);
                    }
                }
            });
            if (childnames.Count > 0)
            {
                clansman.ChildrenNames = string.Join(",", childnames);
            }
        }

        #endregion

        public void Dispose()
        {
        }
    }
}
