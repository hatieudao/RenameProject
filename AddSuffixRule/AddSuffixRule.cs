using RenameRulesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddSuffixRule
{
    class AddSuffixRule : IRenameRule
    {
        public string Suffix { get; set; }
        public string Details
        {
            get
            {
                if (Suffix == null)
                {
                    return "AddSuffixRule";
                }
                return $"AddPrefixRule \"{Suffix}\"";
            }
        }

        public AddSuffixRule(string suffix)
        {
            Suffix = suffix;
        }
        public AddSuffixRule()
        {
        }
        public string Rename(string origin)
        {
            int pos = origin.LastIndexOf('.');
            return pos == -1 ? origin  + Suffix : origin.Substring(0, pos) + Suffix + origin.Substring(pos);
        }

        public IRenameRule Clone()
        {
            return new AddSuffixRule();
        }

        public IRenameRule Clone(string line)
        {
            int i = line.IndexOf(" ");
            if (i == -1)
            {
                return new AddSuffixRule();
            }
            string suffix = line.Substring(i + 2, line.Length - i - 3);
            return new AddSuffixRule(suffix);
        }
    }
}
