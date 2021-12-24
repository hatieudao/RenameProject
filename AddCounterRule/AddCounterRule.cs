using RenameRulesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddCounterRule
{
    class AddCounterRule : IRenameRule
    {
        public int StartNumber { get; set; }
        public int FinishNumber { get; set; }
        public int Step { get; set; }
        public int Digits { get; set; }
        public string Padding { get; set; }
        public string Position { get; set; }
        public string Details {
            get 
            {
                if (Position == "")
                {
                    return "AddCounterRule";
                }
                return $"AddCounterRule {Position} {StartNumber} {FinishNumber} {Step} {Digits} {Padding}";
            } 
        }


        public AddCounterRule(string position, int start, int finish, int step, int digits, string padding)
        {
            Position = position;
            StartNumber = start;
            FinishNumber = finish;
            Step = step;
            Digits = digits;
            Padding = padding;
        }

        public AddCounterRule()
        {
            Position = "";
        }

        public string Rename(string origin)
        {

            if (Position == "Prefix")
            {
                string prefix = "";
                for (int i = StartNumber; i <= FinishNumber; i += Step)
                {
                    prefix += $"{i.ToString($"D{Digits}")}{Padding}";
                }
                return $"{prefix}{origin}";
            }
            int pos = origin.LastIndexOf('.');
            origin = origin.Substring(0, pos);
            string extension = origin.Substring(pos);
            for (int i = StartNumber; i <= FinishNumber; i += Step)
            {
                origin += $"{Padding}{i.ToString($"D{Digits}")}";
            }
            return origin + extension;
        }
        public IRenameRule Clone(string line)
        {
            line = line.Trim();
            var args = line.Split(' ');
            if(args.Length < 7)
            {
                return new AddCounterRule();
            }
            return new AddCounterRule(args[1], Int32.Parse(args[2]), Int32.Parse(args[3]), Int32.Parse(args[4]), Int32.Parse(args[5]), args[6]);
        }
        public IRenameRule Clone()
        {
            return new AddCounterRule();
        }
    }
}
