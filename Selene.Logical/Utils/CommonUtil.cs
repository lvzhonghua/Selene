using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selene.Logical.Utils
{
    public class CommonUtil
    {
        public static OutType AutoCopy<InType, OutType>(InType parent) where OutType : new()
        {
            OutType outType = new OutType();

            var inType = typeof(InType);

            var Properties = inType.GetProperties();

            foreach (var Propertie in Properties)
            {
                if (Propertie.CanRead && Propertie.CanWrite)
                {
                    Propertie.SetValue(outType, Propertie.GetValue(parent, null), null);
                }
            }
            return outType;
        }
        private static string[] numbers = new string[] { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十二", "十三", "十四", "十五", "十六", "十七", "十八", "十九", "二十" };

        public static string NumberToChina(int number)
        {
            return numbers[number];
        }

        public static int ChinaToNumber(string number)
        {
            return numbers.ToList().IndexOf(number);
        }

        public static float FValue(float? value)
        {
            if (value.HasValue)
            {
                return value.Value;
            }
            return default(float);
        }

        public static string Number2Char(int num)
        {
            List<string> theUnitList = new List<string>();
            theUnitList.AddRange(new string[] { "一", "二", "三", "四", "五", "六", "七", "八", "九" });

            List<string> tenUnitList = new List<string>();
            tenUnitList.AddRange(new string[] { "十", "廿", "卅", "四", "五", "六", "七", "八", "九" });

            List<string> hundredUnitList = new List<string>();
            hundredUnitList.AddRange(new string[] { "一百", "二百", "三百", "四百", "五百", "六百", "七百", "八百", "九百" });

            char[] charArr = num.ToString().ToCharArray();

            int[] intArr = charArr.Select(c => int.Parse(c.ToString())).ToArray();

            string result = "";

            if (charArr.Length == 3)
            {
                result = hundredUnitList[intArr[0] - 1];
                if (intArr[1] == 0 && intArr[2] > 0)
                {
                    result += "零";
                    result += theUnitList[intArr[2] - 1];
                }
                else if (intArr[1] > 0 && intArr[2] > 0)
                {
                    result += tenUnitList[intArr[1] - 1];
                    result += theUnitList[intArr[2] - 1];
                }
            }
            else if (charArr.Length == 2)
            {
                result = tenUnitList[intArr[0] - 1];
                if (intArr[1] == 0)
                {
                    if (intArr[0] == 1)
                    {
                        result = "";
                    }
                    else if (intArr[0] == 2)
                    {
                        result = "二";
                    }
                    else if (intArr[0] == 3)
                    {
                        result = "三";
                    }
                    result += "十";
                }
                else
                {
                    result += theUnitList[intArr[1] - 1];
                }
            }
            else if (charArr.Length == 1)
            {
                result = theUnitList[intArr[0] - 1];
            }
            return result;
        }
    }
}
