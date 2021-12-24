using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameRuleLib
{
    class RuleParserFactory : IFactory
    {
        private Dictionary<string, IRuleDataParser> _prototypes = null;
        private static RuleParserFactory _instance = null;
        private RuleParserFactory()
        {
            _prototypes = new Dictionary<string, IRuleDataParser>(){
                { AddCounterParser.MagicWord, new AddCounterParser() },
                { AddPrefixParser.MagicWord, new AddPrefixParser() },
                { AddSuffixParser.MagicWord, new AddSuffixParser() },
                { ChangeCamelCaseParser.MagicWord, new ChangeCamelCaseParser() },
                { ChangeExtensionParser.MagicWord, new ChangeExtensionParser() },
                { ReplaceParser.MagicWord, new ReplaceParser() },
                { TrimSpaceParser.MagicWord, new TrimSpaceParser() },
                { AllLowerCaseParser.MagicWord, new AllLowerCaseParser() },
                { AllUpperCaseParser.MagicWord, new AllUpperCaseParser() },
            };
        }
        public static RuleParserFactory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RuleParserFactory();
            }
            return _instance;
        }
        public IRuleDataParser Create(string magicWord)
        {
            return (IRuleDataParser)_prototypes[magicWord];
        }
        public List<IRenameRule> ReadRuleFromFile(string filePath)
        {
            var presets = new List<IRenameRule>();
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    int pos = line.IndexOf(" ");
                    string firstWord = pos == -1 ? line : line.Substring(0, pos);
                    presets.Add(RuleParserFactory.GetInstance().Create(firstWord).Parse(line));
                }
            }
            return presets;
        }
        public void SaveRuleToFile(List<IRenameRule> rules, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var rule in rules)
                {
                    sw.WriteLine(rule.Details);
                }
            }
        }
    }
}
