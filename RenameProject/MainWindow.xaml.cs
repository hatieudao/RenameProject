using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using RenameRulesLib;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace RenameProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        BindingList<IRenameRule> actions { get; set; } = new BindingList<IRenameRule>();
        RuleParserFactory factory = RuleParserFactory.GetInstance();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            var loadActions = new List<IRenameRule>();

            foreach(var action in factory.GetTypes())
            {
                loadActions.Add(action.Value);
            }
            actionCombobox.ItemsSource = loadActions;
            ActionListBox.ItemsSource = actions;
            GetPreview();
        }
        private void LoadPreset_Click(object sender, RoutedEventArgs e)
        {
            var screen = new Microsoft.Win32.OpenFileDialog();
            screen.ShowDialog();
            string presetFile = screen.FileName;
            var listRules = factory.ReadRuleFromFile(presetFile);
            actions.Clear();
            foreach(var rule in listRules)
            {
                actions.Add(rule);
            }
            GetPreview();
        }

        private void SavePreset_Click(object sender, RoutedEventArgs e)
        {
            if (ActionListBox.Items.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Nothing To Save To Preset", "Error !", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                var rules = new List<IRenameRule>();
                foreach (IRenameRule rule in ActionListBox.Items)
                {
                    rules.Add(rule);
                }
                factory.SaveRuleToFile(rules, "preset.txt");
                System.Windows.Forms.MessageBox.Show("All thing done ^_^", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            GetPreview();
        }

        private void AddFileButtons_Click(object sender, RoutedEventArgs e)
        {
            var screen = new Microsoft.Win32.OpenFileDialog();
            screen.Multiselect = true;
            if (screen.ShowDialog() == true)
            {
                foreach (var file in screen.FileNames)
                {
                    FileTab.Items.Add(new File()
                    {
                        Filename = System.IO.Path.GetFileName(file),
                        Path = file
                    });
                }
            }
            GetPreview();
        }
        private void AddFolderButtons_Click(object sender, RoutedEventArgs e)
        {
            string directory;
            var screen = new FolderBrowserDialog();
            if (screen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                directory = screen.SelectedPath;
                string[] subDirectory = Directory.GetDirectories(directory);

                foreach (var dir in subDirectory)
                {
                    FolderTab.Items.Add(new Folder()
                    {
                        Foldername = dir.Substring(directory.Length + 1),
                        Path = dir
                    });
                }
            }
            GetPreview();
        }

        private void AddMethodButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedRule = actionCombobox.SelectedItem as IRenameRule;
            if(selectedRule == null)
            {
                System.Windows.MessageBox.Show("Nothing To Add", "Error !");
                return;
            }
            actions.Add(selectedRule.Clone());
            GetPreview();
        }
        private void GetPreview()
        {
            foreach (File file in FileTab.Items)
            {
                string result = file.Filename;
                foreach (var action in actions)
                {
                    if(action.Details.Trim().IndexOf(' ') != -1)
                    {
                        result = action.Rename(result);
                    }
                }
                file.Newfilename = result;

                string dirctory = System.IO.Path.GetDirectoryName(file.Path);
                file.Error = System.IO.File.Exists(dirctory + "\\" + result) ? "New file name exists" : "";
            }
            foreach (Folder folder in FolderTab.Items)
            {
                string result = folder.Foldername;
                foreach (var action in actions)
                {
                    result = action.Rename(result);
                }
                folder.Newfolder = result;
                string dirctory = System.IO.Path.GetDirectoryName(folder.Path);
                folder.Error = System.IO.Directory.Exists(dirctory + "\\" + result) ? "New folder name exists" : "";
            }
        }

        private string GetMagicWord(IRenameRule rule)
        {
            string line = rule.Details;
            int pos = line.IndexOf(' ');
            if(pos == -1)
            {
                return line;
            }
            line = line.Substring(0, pos).Trim();
            return line;
        }
        private void EditButtonClicked(object sender, RoutedEventArgs e)
        {
            var rule = ActionListBox.SelectedItem as IRenameRule;
            //var screen = (Window)factory.CreateEditDialog(GetMagicWord(action));

            //if (screen.ShowDialog() == true)
            //{
            //    var pos = ActionListBox.SelectedIndex;
            //    string line = screen.Details;

            //}
            int pos = ActionListBox.SelectedIndex;
            string magic = GetMagicWord(rule);
            if ( magic == "ReplaceRule")
            {
                var screen = new ReplaceRuleEdit(rule);

                if (screen.ShowDialog() == true)
                {
                    var editedRule = factory.Create("ReplaceRule").Clone(screen.Details);

                    actions[pos] = editedRule;
                }
            }
            if (magic == "AddCounterRule")
            {
                var screen = new AddCounterRuleEdit(rule);

                if (screen.ShowDialog() == true)
                {
                    var editedRule = factory.Create("AddCounterRule").Clone(screen.Details);

                    actions[pos] = editedRule;
                }
            }
            if (magic == "AddSuffixRule" || magic == "AddPrefixRule" || magic == "ChangeExtensionRule")
            {
                
                var screen = new GetWord(rule);
                System.Windows.MessageBox.Show(rule.Details);
                if (screen.ShowDialog() == true)
                {
                    var editedRule = factory.Create(magic).Clone(screen.Details);
                    actions[pos] = editedRule;
                }
            }
            GetPreview();
        }

        public static void CopyAll(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
            {
                System.Windows.MessageBox.Show("Source Directory does not exist or could not be found !");
            }

            if (!Directory.Exists(destDirName))
            {
                DirectoryInfo tempFolder = Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = System.IO.Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = System.IO.Path.Combine(destDirName, subdir.Name);
                    CopyAll(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        public static void RemoveDirectory(string sourcePath)
        {
            DirectoryInfo src = new DirectoryInfo(sourcePath);

            foreach (var file in src.GetFiles())
            {
                file.Delete();
            }
            foreach (var dir in src.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        private void StartBatchButtonButton_Click(object sender, RoutedEventArgs e)
        {
            bool isDuplicate = false;
            //check input from users;
            if (ActionListBox.Items.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Add Method Before Batching!", "Erro Detected in Input", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else if (FileTab.Items.Count == 0 && FolderTab.Items.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Choose File Or Folder Before Batching!", "Erro Detected in Input", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                ObservableCollection<File> FileList = new ObservableCollection<File>();
                ObservableCollection<Folder> FolderList = new ObservableCollection<Folder>();
                //file process
                foreach (File file in FileTab.Items)
                {
                    string result = file.Filename;
                    foreach (var action in actions)
                    {
                        result = action.Rename(result);
                    }

                    var path = System.IO.Path.GetDirectoryName(file.Path);
                    try
                    {
                        var tempfile = new FileInfo(file.Path);
                        tempfile.MoveTo(path + "\\" + result);
                        file.Newfilename = result;
                    }
                    catch (Exception k)
                    {
                        Debug.WriteLine(k.ToString());
                        isDuplicate = true;
                        file.Newfilename = result;
                        file.Error = "Duplicate";
                        FileList.Add(file);
                    }
                }
                
                int count = 0;
                foreach (Folder folder in FolderTab.Items)
                {
                    string result = folder.Foldername;

                    foreach (var rule in actions)
                    {
                        result = rule.Rename(result);
                    }
                    string newfolderpath = System.IO.Path.GetDirectoryName(folder.Path) + "\\" + result;
                    string tempFolderName = "\\Temp";
                    string tempFolderPath = System.IO.Path.GetDirectoryName(folder.Path) + tempFolderName;
                    CopyAll(folder.Path, tempFolderPath, true);

                    if (folder.Path.Equals(newfolderpath) == false)
                    {
                        RemoveDirectory(folder.Path);
                        Directory.Delete(folder.Path);
                        try
                        {
                            Directory.Move(tempFolderPath, newfolderpath);
                            folder.Newfolder = result;
                            folder.Error = "OK";
                        }
                        catch (Exception exception) 
                        {
                            string duplicatestore = System.IO.Path.GetDirectoryName(folder.Path) + "\\Store" + $"{++count}";
                            CopyAll(tempFolderPath, duplicatestore, true);
                            RemoveDirectory(tempFolderPath);
                            Directory.Delete(tempFolderPath);
                            isDuplicate = true;
                            folder.Newfolder = result;
                            folder.Error = "Duplicate Foldername";
                            FolderList.Add(folder);
                        }
                    }
                    else
                    {
                        RemoveDirectory(tempFolderPath);
                        Directory.Delete(tempFolderPath);
                    }
                }

                if (isDuplicate == true)
                {
                    var duplicateSolve = new DuplicateSolve(FileList, FolderList);
                    duplicateSolve.ShowDialog();
                }
                var screen = new Preview(FileTab.Items, FolderTab.Items);
                screen.ShowDialog();
                FolderTab.Items.Refresh();
                FileTab.Items.Refresh();
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            FileTab.Items.Refresh();
            FolderTab.Items.Refresh();
        }

        private void DeleteButotn_Click(object sender, RoutedEventArgs e)
        {
            actions.Clear();
            FileTab.ItemsSource = null;
            FileTab.Items.Clear();
            FolderTab.ItemsSource = null;
            FolderTab.Items.Clear();
        }
    }
}
