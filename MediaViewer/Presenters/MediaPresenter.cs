using MediaViewer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaViewer.Presenters
{
    public class MediaPresenter<T> where T : Media, new()
    {
        private readonly string _mediaPath;
        private readonly string[] _extensions;
        private ObservableCollection<Media> _media;

        public MediaPresenter(string mediaPath, params string[] extensions)
        {
            this._mediaPath = mediaPath;
            this._extensions = extensions;
        }

        public ObservableCollection<Media> Media
        {
            get
            {
                if (_media == null)
                {
                    LoadMedia();
                }

                return _media;
            }
        }

        private void LoadMedia()
        {
            if (string.IsNullOrEmpty(_mediaPath))
            {
                return;
            }

            _media = new ObservableCollection<Media>();
            var dir = new DirectoryInfo(_mediaPath);

            foreach (var ext in _extensions)
            {
                var files = dir.GetFiles(ext, SearchOption.AllDirectories);
                foreach (var item in files)
                {
                    if (_media.Count() == 50)
                    {
                        break;
                    }
                    T m = new T();
                    m.SetFile(item);                    
                    _media.Add(m);
                }
            }
        }
    }
}
