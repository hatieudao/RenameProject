using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class AllUpperCaseRule : IRenameRule
    {
        public string Details => "Uppercase";

        public string Rename(string origin)
        {
            return origin.ToUpper();
        }
    }
}
