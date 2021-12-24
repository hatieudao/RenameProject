using RenameRulesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeExtensionRule
{
    class ChangeExtensionRule : IRenameRule
    {
        public string NewExtension { get; set; }

        public string Details => $"ChangeExtensionRule {NewExtension}";

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
            return pos == -1 ? origin : origin.Substring(0, pos + 1) + NewExtension;
        }

        public IRenameRule Clone()
        {
            return new ChangeExtensionRule();
        }

        public IRenameRule Clone(string line)
        {
            int i = line.IndexOf(" ");
            if (i == -1)
            {
                return new ChangeExtensionRule();
            }
            return new ChangeExtensionRule(line.Substring(i));
        }
    }
}
