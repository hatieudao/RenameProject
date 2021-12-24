using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class ChangeCamelCaseRule : IRenameRule
    {
        public ChangeCamelCaseRule() { }

        public string Details => "CamelCase";

        public string Rename(string origin)
        {
            return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(origin);
        }
    }
}
