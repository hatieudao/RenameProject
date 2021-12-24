using RenameRulesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrimSpaceRule
{
    class TrimSpaceRule : IRenameRule
    {
        public TrimSpaceRule() { }

        public string Details => "TrimSpaceRule";

        public IRenameRule Clone()
        {
            return new TrimSpaceRule();
        }

        public IRenameRule Clone(string line)
        {
            return new TrimSpaceRule();
        }

        public string Rename(string origin)
        {
            return origin.Trim();
        }
    }
}
