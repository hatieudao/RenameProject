using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class ReplaceParser : IRuleDataParser
    {
        public static string MagicWord => "Replace";

        public IRenameRule Parse(string line)
        {
            int i = line.IndexOf(" ");
            line = line.Substring(i);
            List<string> needles = new List<string>();
            int pos1 = line.IndexOf("[");
            int pos2 = line.IndexOf("]");
            string nds = line.Substring(pos1 + 1, pos2 - pos1 - 1);
            foreach (string x in nds.Split(","))
            {
                string needle = x.Trim();
                needles.Add(needle.Substring(1,  needle.Length - 2));
            }
            pos1 = line.IndexOf(">");
            pos2 = line.Length;
            string hammer = line.Substring(pos1 + 3, pos2 - pos1 - 4);
            return new ReplaceRule(needles, hammer);
        }
    }
}
