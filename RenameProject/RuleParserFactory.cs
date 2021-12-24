using RenameRulesLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RenameProject
{
    class RuleParserFactory
    {
        private Dictionary<string, IRenameRule> _prototypes = null;
        private Dictionary<string, Window> _editDialog = null;
        private static RuleParserFactory _instance = null;
        private RuleParserFactory()
        {
            string exacPath = Assembly.GetExecutingAssembly().Location;
            string folder = System.IO.Path.GetDirectoryName(exacPath);
            FileInfo[] fis = new DirectoryInfo(folder).GetFiles("*.dll");

            _prototypes = new Dictionary<string, IRenameRule>();
            //_editDialog = new Dictionary<string, Window>();
            foreach (FileInfo fileInfo in fis)
            {
                var domain = AppDomain.CurrentDomain;
                Assembly assembly = Assembly.LoadFile(fileInfo.FullName);
                Type[] types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.IsClass && typeof(IRenameRule).IsAssignableFrom(type))
                    {
                        
                        var newRule = Activator.CreateInstance(type) as IRenameRule;
                        var clone = newRule.Clone().ToString().Split('.')[0];
                        _prototypes.Add( clone , (IRenameRule) newRule );
                        //try
                        //{
                        //    var editDialog = Activator.CreateInstance(null, $"RenameProject.{clone}Edit");
                            
                        //    if (editDialog != null)
                        //    {
                        //        Debug.WriteLine("Dialog:  " + editDialog.Unwrap().ToString());
                        //        var screen = (Window)editDialog.Unwrap();
                        //        _editDialog.Add(clone.ToString().Split('.')[0], screen);
                        //    }
                        //}
                        //catch(Exception e)
                        //{
                        //    Debug.WriteLine(clone + ": => " + e.Message);

                        //}
                        
                    }
                }
            }
            
        }
        public static RuleParserFactory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RuleParserFactory();
            }
            return _instance;
        }
        public IRenameRule Create(string magicWord)
        {
            return (IRenameRule)_prototypes[magicWord];
        }
        //public Window CreateEditDialog(string magicWord, string line)
        //{
        //    return _editDialog[magicWord];
        //}
        //public Dictionary<string, Window> GetEditDialog()
        //{
        //    return _editDialog;
        //}
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
                    presets.Add(RuleParserFactory.GetInstance().Create(firstWord).Clone(line));
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
        public Dictionary<string, IRenameRule> GetTypes()
        {
            return _prototypes;
        }
    }
}
