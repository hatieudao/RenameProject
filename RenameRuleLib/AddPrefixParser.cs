using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class AddPrefixParser: IRuleDataParser
    {
        public static string MagicWord => "Prefix";
        public IRenameRule Parse(string line)
        {
            int i = line.IndexOf(" ");
            string prefix = line.Substring(i + 2, line.Length-i-3);
            return new AddPrefixRule(prefix);
        }
    }
}
