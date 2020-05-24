using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaViewer.Model
{
    public class Media : INotifyPropertyChanged
    {
        public FileInfo _fileInfo { get; set; }
        public Uri _uri { get; set; }

        public string Name
        {
            get
            {
                return Path.GetFileNameWithoutExtension(_fileInfo.Name);
            }
        }

        public Uri Uri => _uri;

        public string Directory => _fileInfo.Directory.Name;

        public void SetFile(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
            _uri = new Uri(_fileInfo.FullName);

            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Directory));
            OnPropertyChanged(nameof(Uri));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
