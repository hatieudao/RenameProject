using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RenameProject
{
    class RuleNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string name = (string)value;
            name = name.Trim();
            int pos = name.IndexOf(' ');
            if(pos != -1)
            {
                name = name.Substring(0, pos);
            }
            name = name.Substring(0, name.Length - 4);
            for (int i = 1; i < name.Length; ++i)
            {
                char c = name[i];
                if (Char.IsUpper(c) && name[i-1] != ' ') 
                {
                    string noSpace = $"{c}";
                    string haveSPace = $" {c}";
                    name = name.Replace(noSpace, haveSPace);
                }
            }
            return name.Trim();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
