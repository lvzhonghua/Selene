using Selene.DB.Base;
using Selene.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.DAL.IDAL
{
    public interface IClansmanDAL:ICommonDB<Clansman>
    {
        Clansman GetClansmanParent(string ownName, string parentName);

        int GetClansmanPid(string ownName, string parentName);
        
        /// <summary>
        /// 获取当前数据库已经有的子级数量
        /// </summary>
        int GetCurrentChildrenCount(int pid);

        /// <summary>
        /// 获取当前数据库已经有的ownType对应的子级数量
        /// </summary>
        int GetCurrentChildrenCount(int pid, string ownType);

        /// <summary>
        /// 检测是否已经存在相同的人
        /// </summary>
        bool CheckPersonExist(string ownName,int pid);

        /// <summary>
        /// 检测是否以及存在对应的子级，长子、次子等的判断
        /// </summary>
        /// <param name="pid">父级id</param>
        /// <param name="sort">序号</param>
        /// <param name="id">修改的时候传入大于-1的id</param>
        /// <returns>存在为true</returns>
        bool CheckPersonSortExist(int pid, int sort,int id);
    }
}
