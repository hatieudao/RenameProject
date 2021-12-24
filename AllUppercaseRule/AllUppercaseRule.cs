using RenameRulesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllUppercaseRule
{
    class AllUppercaseRule : IRenameRule
    {
        public string Details => "AllUppercaseRule";
        public AllUppercaseRule() { }

        public IRenameRule Clone()
        {
            return new AllUppercaseRule();
        }

        public IRenameRule Clone(string line)
        {
            return new AllUppercaseRule();
        }

        public string Rename(string origin)
        {
            return origin.ToUpper();
        }
    }
}
