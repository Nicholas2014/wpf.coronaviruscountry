using MediaViewer.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaViewer.Presenters
{
    public class ApplicationController
    {
        private readonly MainWindow _shell;

        public ApplicationController(MainWindow shell)
        {
            this._shell = shell;
        }

        public void ShowMenu()
        {
            new MenuPresenter(this);
        }

        public void DisplayInShell(object view)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            _shell.TransitionTo(view);
        }

        public string RequestDirectoryFromUser()
        {
            var ofd = new OpenFileDialog();

            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            ofd.Title = "Please choose a folder.";
            ofd.CheckFileExists = false;
            ofd.FileName = "[Get Folder]";
            ofd.Filter = "Folders|no.files";

            if (ofd.ShowDialog() == true)
            {
                var path = Path.GetDirectoryName(ofd.FileName);
                if (!string.IsNullOrEmpty(path))
                {
                    return path;
                }
            }

            return string.Empty;
        }

    }
}
