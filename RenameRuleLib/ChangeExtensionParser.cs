using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class ChangeExtensionParser : IRuleDataParser
    {
        public static string MagicWord => "Extension";

        public IRenameRule Parse(string line)
        {
            int i = line.IndexOf(" ");
            return new ChangeExtensionRule(line.Substring(i));
        }
    }
}
