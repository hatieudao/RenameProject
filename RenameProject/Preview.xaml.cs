using RenameProject;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RenameProject
{
    /// <summary>
    /// Interaction logic for Preview.xaml
    /// </summary>
    
    public partial class Preview : Window
    {
        
        public Preview()
        {
            this.LoadViewFromUri("/RenameProject;component/Preview.xaml");
        }
        public Preview(ItemCollection FileItem, ItemCollection FolderItem)
        {
            this.LoadViewFromUri("/RenameProject;component/Preview.xaml");
            FilePreviewTab.ItemsSource = FileItem;
            FolderPreviewTab.ItemsSource = FolderItem;
        }
    }
}
