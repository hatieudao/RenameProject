using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRenameRuleLib
{
    interface IRenameRule
    {
        public string Details { get; }

        public string Rename(string origin);
    }
}
