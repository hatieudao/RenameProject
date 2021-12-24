using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameProject
{
    public class Folder : INotifyPropertyChanged
    {
        private string _folder;
        private string _newfolder;
        private string _path;
        private string _error;

        public string Foldername
        {
            get => _folder; set
            {
                _folder = value;
                NotifyChanged("Folder");
            }
        }

        public string Newfolder
        {
            get => _newfolder;
            set
            {
                _newfolder = value;
                NotifyChanged("Newfolder");
            }
        }

        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                NotifyChanged("Path");
            }
        }

        public string Error
        {
            get => _error;
            set
            {
                _error = value;
                NotifyChanged("Error");
            }
        }

        private void NotifyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(v));
            }
        }

        public Folder Clone()
        {
            return new Folder()
            {
                Foldername = this._folder,
                Newfolder = this._newfolder,
                Path = this._path,
                Error = this._error
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
