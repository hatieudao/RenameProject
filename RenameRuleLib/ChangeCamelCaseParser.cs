using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class ChangeCamelCaseParser : IRuleDataParser
    {
        public static string MagicWord => "CamelCase";

        public IRenameRule Parse(string line)
        {
            return new ChangeCamelCaseRule();
        }
    }
}
