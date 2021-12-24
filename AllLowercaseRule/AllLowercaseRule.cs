using RenameRulesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllLowercaseRule
{
    class AllLowerCaseRule : IRenameRule
    {
        public string Details => "AllLowercaseRule";

        public IRenameRule Clone()
        {
            return new AllLowerCaseRule();
        }

        public IRenameRule Clone(string line)
        {
            return new AllLowerCaseRule();
        }

        public string Rename(string origin)
        {
            return origin.ToLower();
        }
    }
}
