using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    
    interface IRuleDataParser
    {
        public static string MagicWord { get; }
        public IRenameRule Parse(string line);
    }
}
