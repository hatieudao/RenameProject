using RenameRulesLib;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddCounterRule.xaml
    /// </summary>
    public partial class AddCounterRuleEdit : Window
    {

        public string Position {get; set;}
        public string Padding { get; set; }
        public int StartNumber { get; set; }
        public int FinishNumber { get; set; }
        public int Step { get; set; }
        public int Digits { get; set; }
        public string Details
        {
            get
            {
                if (Position == "")
                {
                    return "AddCounterRule";
                }
                return $"AddCounterRule {Position} {StartNumber} {FinishNumber} {Step} {Digits} {Padding}";
            }
        }
        public AddCounterRuleEdit()
        {
            this.LoadViewFromUri("/RenameProject;component/AddCounterRuleEdit.xaml");
            
        }
        public AddCounterRuleEdit(IRenameRule rule)
        {
            this.LoadViewFromUri("/RenameProject;component/AddCounterRuleEdit.xaml");
            string line = rule.Details;
            line = line.Trim();
            var args = line.Split(' ');
            if (args.Length < 7)
            {
                return;
            }
            startNumberTextBox.Text = args[1];
            finishNumberTextBox.Text = args[2];
            stepTextBox.Text = args[3];
            digitsTextBox.Text = args[4];
            positionCombobox.Text = args[5];
            paddingTextBox.Text = args[6];
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            StartNumber = Int32.Parse(startNumberTextBox.Text);
            FinishNumber = Int32.Parse(finishNumberTextBox.Text);
            Step = Int32.Parse(stepTextBox.Text);
            Digits = Int32.Parse(digitsTextBox.Text);
            Position = (string) positionCombobox.Text;
            Padding = paddingTextBox.Text;
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
