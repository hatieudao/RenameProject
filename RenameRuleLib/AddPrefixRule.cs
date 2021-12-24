using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class AddPrefixRule : IRenameRule
    {
        public string Prefix { get; set; }

        public string Details => $"Prefix {Prefix}";

        public AddPrefixRule(string prefix)
        {
            Prefix = prefix;
        }

        public AddPrefixRule()
        {
        }

        public string Rename(string original)
        {
           return $"{Prefix}{original}"; 
        }
    }
}
