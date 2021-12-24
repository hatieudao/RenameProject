using RenameRulesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceRule
{
    class ReplaceRule : IRenameRule
    {
        public List<string> Needles { get; set; }
        public string Hammer { get; set; }

        public string Details
        {
            get
            {
                string result = "ReplaceRule";
                if (Needles != null)
                {
                    if (Needles.Count != 0) {
                        result += $" [\"{Needles[0]}\"";
                        for(int i = 1; i < Needles.Count; ++i)
                        {
                            result += $", \"{Needles[i]}\"";
                        }
                        result += $"] => \"{Hammer}\"";
                    }
                }
                return result;
            }
        }

        public ReplaceRule(List<string> needles, string hammer)
        {
            Needles = needles;
            Hammer = hammer;
        }
        public ReplaceRule(string needles, string hammer)
        {
            Needles = new List<string>();
            Needles.Add(needles);
            Hammer = hammer;
        }

        public ReplaceRule()
        {
        }

        public string Rename(string original)
        {
            string result = original;

            foreach (var needle in Needles)
            {
                result = result.Replace(needle, Hammer);
            }

            return result;
        }

        public IRenameRule Clone()
        {
            return new ReplaceRule();
        }

        public IRenameRule Clone(string line)
        {
            int i = line.IndexOf(" ");
            if(i == -1)
            {
                return new ReplaceRule();
            }
            line = line.Substring(i);
            List<string> needles = new List<string>();
            int pos1 = line.IndexOf("[");
            int pos2 = line.IndexOf("]");
            string nds = line.Substring(pos1 + 1, pos2 - pos1 - 1);
            foreach (string x in nds.Split(','))
            {
                string needle = x.Trim();
                if(needle == null || needle == "")
                {
                    continue;
                }
                needles.Add(needle.Substring(1, needle.Length - 2));
            }
            pos1 = line.IndexOf(">");
            pos2 = line.Length;
            string hammer = line.Substring(pos1 + 3, pos2 - pos1 - 4);
            return new ReplaceRule(needles, hammer);
        }
    }
}
