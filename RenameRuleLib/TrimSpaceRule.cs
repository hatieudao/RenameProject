using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class TrimSpaceRule : IRenameRule
    {
        public TrimSpaceRule() { }

        public string Details => "Trim";

        public string Rename(string origin)
        {
            return origin.Trim();
        }
    }
}
