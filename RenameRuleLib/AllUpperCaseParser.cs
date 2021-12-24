using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class AllUpperCaseParser : IRuleDataParser
    {
        public static string MagicWord => "Uppercase";
        public IRenameRule Parse(string line)
        {
            return new AllUpperCaseRule();
        }
    }
}
