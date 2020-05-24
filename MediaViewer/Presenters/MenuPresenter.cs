using MediaViewer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }

        public void ListenToMusic()
        {

        }

        public void WatchVideo()
        {

        }
    }
}
