using MediaViewer.Model;
using MediaViewer.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MediaViewer.Presenters
{
    public class MenuPresenter
    {
        private readonly ApplicationController _controller;

        public MenuPresenter(ApplicationController controller)
        {
            this._controller = controller;
            this._controller.DisplayInShell(new MenuView(this));
        }

        public void DisplayPictures()
        {
            string picPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            Display<PictureView, Picture>(picPath, "*.jpg", "*.gif", "*.png", "*.bmp");
        }

        public void ListenToMusic()
        {
            Display<MusicView, Media>(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "*.wma", "*.mp3");
        }

        public void WatchVideo()
        {
            Display<VideoView, Media>(_controller.RequestDirectoryFromUser(), "*.wmv", "*.mp4");
        }

        private void Display<View, MediaType>(string mediaPath, params string[] extensions)
            where View : UserControl, new()
            where MediaType : Media, new()
        {
            var mediaPresenter = new MediaPresenter<MediaType>(mediaPath, extensions);
            View view = new View();
            view.DataContext = mediaPresenter;

            _controller.DisplayInShell(view);
        }
    }
}
