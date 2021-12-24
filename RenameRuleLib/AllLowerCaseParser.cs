using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class AllLowerCaseParser : IRuleDataParser
    {
        public static string MagicWord => "Lowercase";
        public IRenameRule Parse(string line)
        {
            return new AllLowerCaseRule();
        }
    }
}
