using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class AddCounterRule : IRenameRule
    {
        public int StartNumber { get; set; }
        public int FinishNumber { get; set; }
        public int Step { get; set; }
        public int Digits { get; set; }
        public string Padding { get; set; }
        public string Position { get; set; }
        public string Details => $"Counter {Position} {StartNumber} {FinishNumber} {Step} {Digits} {Padding}";
        public AddCounterRule(string position, int start, int finish, int step = 1, int digits=3, string padding ="")
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
            StartNumber = 0;
            FinishNumber = 0;
            Step = 1;
            Digits = 1;
            Padding = "";
            Position = "Suffix";
        }

        public string Rename(string origin)
        {

            if(Position == "Prefix")
            {
                string prefix = "";
                for (int i = StartNumber; i <= FinishNumber; i += Step)
                {
                    prefix += $"{i.ToString($"D{Digits}")}{Padding}";
                }
                return $"{prefix}{origin}";
            }

            for(int i = StartNumber; i<=FinishNumber; i+= Step)
            {
                origin += $"{Padding}{i.ToString($"D{Digits}")}";
            }
            return origin;
        }
    }
}
