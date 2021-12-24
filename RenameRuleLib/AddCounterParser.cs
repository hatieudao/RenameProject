using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class AddCounterParser : IRuleDataParser
    {
        public static string MagicWord => "Counter";

        public IRenameRule Parse(string line)
        {
            var args = line.Split(" ");
            return new AddCounterRule(args[1], Int32.Parse(args[2]), Int32.Parse(args[3]), Int32.Parse(args[4]), Int32.Parse(args[5]), args[6] );
        }
    }
}
