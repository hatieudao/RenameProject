using RenameRulesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChangeCamelCaseRule
{
    class ChangeCamelCaseRule : IRenameRule
    {
        public ChangeCamelCaseRule() { }

        public string Details => "ChangeCamelCaseRule";

        public IRenameRule Clone()
        {
            return new ChangeCamelCaseRule();
        }

        public IRenameRule Clone(string line)
        {
            return new ChangeCamelCaseRule();
        }

        public string Rename(string origin)
        {
            return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(origin);
        }
    }
}
