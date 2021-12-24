using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class ChangeExtensionRule : IRenameRule
    {
        public string NewExtension { get; set; }

        public string Details => $"Extension {NewExtension}";

        public ChangeExtensionRule(string newExtension)
        {
            NewExtension = newExtension;
        }

        public ChangeExtensionRule()
        {
        }

        public string Rename(string origin)
        {
            int pos = origin.LastIndexOf('.');
            return pos == -1 ? origin : origin.Substring(0, pos+1) + NewExtension;
        }
    }
}
