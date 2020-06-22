using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Doit.Print
{
    /// <summary>
    /// 程序集分析器
    /// </summary>
    public class AssemblyAnalyzer
    {
        public static List<Type> GetTypesAssociatedByCellStyle(string fileName)
        {
            List<Type> typeList = new List<Type>();
            Assembly assembly = Assembly.LoadFrom(fileName);
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            { 
                if (type.IsAbstract) continue;
                if (type.IsEnum) continue;

                TypeInfo typeInfo = type.GetTypeInfo();
                if (typeInfo.DeclaredProperties == null || typeInfo.DeclaredProperties.Count() == 0) continue;

                typeList.Add(type);
            }

            return typeList;
        }
    }
}
