using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace MediaViewer.Model
{
    public class Picture : Media
    {
        private ImageSource _thumbnail;

        public ImageSource Thumbnail
        {
            get
            {
                if (_thumbnail == null)
                {
                    ThreadPool.QueueUserWorkItem(LoadImage);
                }
                return _thumbnail;
            }
        }

        private void LoadImage(object state)
        {
            var buffer = File.ReadAllBytes(_fileInfo.FullName);
            var mem = new MemoryStream(buffer);
            var decoder = BitmapDecoder.Create(mem, BitmapCreateOptions.None, BitmapCacheOption.None);

            _thumbnail = decoder.Frames[0];
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate { OnPropertyChanged(nameof(Thumbnail)); });
        }
    }
}
