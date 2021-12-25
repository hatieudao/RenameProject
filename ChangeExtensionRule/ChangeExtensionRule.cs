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

        public string Details {
            get 
            {
                if (NewExtension == null || NewExtension == "")
                {
                    return "ChangeExtensionRule";
                }
                return $"ChangeExtensionRule \"{NewExtension}\"";
            } 
        }

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
            return pos == -1 ? origin + NewExtension : origin.Substring(0, pos + 1) + NewExtension;
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
            return new ChangeExtensionRule(line.Substring(i+2, line.Length - 3 - i));
        }
    }
}
