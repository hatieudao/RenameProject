using RenameRulesLib;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for GetWord.xaml
    /// </summary>
    public partial class GetWord : Window
    {
        public string Word { get; set; }
        public string NameRule { get; set; }
        public string Details => $"{NameRule} \"{Word}\"";
        public GetWord()
        {
            this.LoadViewFromUri("/RenameProject;component/GetWord.xaml");
        }
        public GetWord(IRenameRule rule)
        {
            this.LoadViewFromUri("/RenameProject;component/GetWord.xaml");
            string line = rule.Details;
            int pos = line.IndexOf(" ");
            if (pos == -1)
            {
                NameRule = line;
                return;
            }
            
            NameRule = line.Substring(0, pos);
            wordTextBox.Text = line.Substring(pos + 2, line.Length - pos - 3);
        }
    
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Word = wordTextBox.Text;
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
