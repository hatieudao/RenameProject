using RenameRulesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddPrefixRule
{
    class AddPrefixRule : IRenameRule
    {
        public string Prefix { get; set; }
        public string Details {get{ 
            if (Prefix == null)
                {
                    return "AddPrefixRule";
                }
            return $"AddPrefixRule \"{Prefix}\""; 
            } 
        }
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

        public IRenameRule Clone()
        {
            return new AddPrefixRule();
        }

        public IRenameRule Clone(string line)
        {
            int i = line.IndexOf(" ");
            if (i == -1)
            {
                return new AddPrefixRule();
            }
            string prefix = line.Substring(i + 2, line.Length - i - 3);
            return new AddPrefixRule(prefix);
        }
    }
}
