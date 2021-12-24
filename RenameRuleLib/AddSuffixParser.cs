using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class AddSuffixParser : IRuleDataParser
    {
        public static string MagicWord => "Suffix";
        public IRenameRule Parse(string line)
        {
            int i = line.IndexOf(" ");
            string suffix = line.Substring(i + 2, line.Length - i - 3);
            return new AddSuffixRule(suffix);
        }
    }
}
