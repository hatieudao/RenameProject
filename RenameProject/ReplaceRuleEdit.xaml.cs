using RenameProject;
using RenameRulesLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RenameProject
{
    /// <summary>
    /// Interaction logic for ReplaceRuleEdit.xaml
    /// </summary>
    
    public partial class ReplaceRuleEdit : Window
    {
        public BindingList<string> Needles { get; } = new BindingList<string>(); 
        public string Hammer;
        public string Details
        {
            get
            {
                string result = "ReplaceRule";
                if (Needles != null)
                {
                    if (Needles.Count != 0)
                    {
                        result += $" [\"{Needles[0]}\"";
                        for (int i = 1; i < Needles.Count; ++i)
                        {
                            result += $", \"{Needles[i]}\"";
                        }
                        result += $"] => \"{Hammer}\"";
                    }
                }
                return result;
            }
        }
        public ReplaceRuleEdit()
        {
            this.LoadViewFromUri("/RenameProject;component/ReplaceRuleEdit.xaml");
            NeedleListView.ItemsSource = Needles;
        }
        public ReplaceRuleEdit(IRenameRule rule)
        {
            this.LoadViewFromUri("/RenameProject;component/ReplaceRuleEdit.xaml");
            string line = rule.Details;
            int i = line.IndexOf(" ");
            if (i != -1)
            {
                line = line.Substring(i);
                int pos1 = line.IndexOf("[");
                int pos2 = line.IndexOf("]");
                string nds = line.Substring(pos1 + 1, pos2 - pos1 - 1);
                foreach (string x in nds.Split(','))
                {
                    string needle = x.Trim();
                    Needles.Add(needle.Substring(1, needle.Length - 2));
                }
                pos1 = line.IndexOf(">");
                pos2 = line.Length;
                string Hammer = line.Substring(pos1 + 3, pos2 - pos1 - 4);
                hammerTextBox.Text = Hammer;
            }
            NeedleListView.ItemsSource = Needles;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Hammer = hammerTextBox.Text;
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddNeedleButton_Click(object sender, RoutedEventArgs e)
        {
            Needles.Add(needleTextBox.Text);
            needleTextBox.Text = "";
        }
    }
}
