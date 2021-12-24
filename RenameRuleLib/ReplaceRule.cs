using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class ReplaceRule : IRenameRule
    {
        public List<string> Needles { get; set; }
        public string Replacer { get; set; }

        public string Details {
            get
            {
                string result = "[";
                foreach(string needle in Needles)
                {
                    result += $", \"{needle}\"";
                }
                result += $"] => \" {Replacer}\"";
                return result;
            }
        }

        public ReplaceRule(List<string> needles, string replacer)
        {
            Needles = needles;
            Replacer = replacer;
        }
        public ReplaceRule(string needles, string replacer)
        {
            Needles = new List<string>();
            Needles.Add(needles);
            Replacer = replacer;
        }

        public ReplaceRule()
        {
        }

        public string Rename(string original)
        {
            string result = original;

            foreach (var needle in Needles)
            {
                result = result.Replace(needle, Replacer);
            }

            return result;
        }
    }
}
