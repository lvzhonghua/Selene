using Selene.Logical.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Selene.Logical
{
    public class GenealogyNoteResolve
    {
        protected static string personnelNumPattern = @"[一-十]{1,}";
        protected static string personnelNamePattern = @"[一-十]{1,}/[\w|\u4e00-\u9fa5/]{1,}/";
        public static int GetBirthPersonnelNum(string input, string checkBody)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 3)
            {
                return 0;
            }

            Match match = Regex.Match(input, checkBody+personnelNumPattern);
            int boyNum = 0;
            if (match.Success)
            {
                var numStr = match.Groups[0].Value.Replace(checkBody, "");
                boyNum = CommonUtil.ChinaToNumber(numStr);
            }
            return boyNum;
        }

        public static List<string> GetBirthPersonnelName(string input,string checkBody)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            string currNamePattern = checkBody+personnelNamePattern;
            string currNumPattern = checkBody+personnelNumPattern;

            Match match=Regex.Match(input, currNamePattern);
            if (match.Success)
            {
                string value = match.Value;

                return Regex.Replace(value, currNumPattern, "").Split('/').Where(item => !string.IsNullOrEmpty(item)).ToList();
            }
            return null;
        }

        public static CheckBirthResult CheckBirth(string input,string checkBody)
        {
            int num = GetBirthPersonnelNum(input, checkBody);
            var names=GetBirthPersonnelName(input, checkBody);

            return new CheckBirthResult(checkBody, num, names);
        }
    }

    public class CheckBirthResult
    {
        public string CheckBody { get; set; }

        public string BodyInfo { 
            get {
                return this.CheckBody + CommonUtil.NumberToChina(this.BodyNum);
            } 
        }

        public int BodyNum { get; set; }

        public List<string> BodyNames { get; set; }

        public string Color
        {
            get
            {
                if (!this.Legal)
                {
                    return "Red";
                }
                return "Transparent";
            }
        }

        public bool Legal
        {
            get
            {
                if (this.BodyNum > 0)
                {
                    if (this.BodyNames == null || this.BodyNum != this.BodyNames.Count)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public CheckBirthResult() { }

        public CheckBirthResult(string checkBody,int bodyNum,List<string> bodyNames)
        {
            this.CheckBody = checkBody;
            this.BodyNum = bodyNum;
            this.BodyNames = bodyNames;
        }
    }
}
