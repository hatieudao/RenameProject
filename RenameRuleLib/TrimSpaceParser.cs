using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class TrimSpaceParser : IRuleDataParser
    {
        public static string MagicWord => "Trim";

        public IRenameRule Parse(string line)
        {
            return new TrimSpaceRule();
        }
    }
}
