using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class AllLowerCaseRule : IRenameRule
    {
        public string Details => "Lowercase";

        public string Rename(string origin)
        {
            return origin.ToLower();
        }
    }
}
