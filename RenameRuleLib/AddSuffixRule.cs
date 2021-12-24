using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class AddSuffixRule : IRenameRule
    {
        public string Suffix { get; set; }
        public string Details => $"Suffix {Suffix}";
        public AddSuffixRule(string suffix)
        {
            Suffix = suffix;
        }
        public AddSuffixRule()
        {
        }
        public string Rename(string origin)
        {
            return $"{origin}{Suffix}";
        }
    }
}
