using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace TextEditor
{
    public class DocumentManager
    {
        private string _currentFile;
        private readonly RichTextBox text;

        public DocumentManager(RichTextBox text)
        {
            this.text = text;
        }

        public bool OpenDocument()
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                _currentFile = ofd.FileName;
                using (Stream s = ofd.OpenFile())
                {
                    var range = new TextRange(text.Document.ContentStart, text.Document.ContentEnd);
                    range.Load(s, DataFormats.Rtf);
                }

                return true;
            }

            return false;
        }

        public bool SaveDocument()
        {
            if (string.IsNullOrEmpty(_currentFile))
            {
                return SaveDocumentAs();
            }
            else
            {
                using (Stream s = new FileStream(_currentFile, FileMode.Create))
                {
                    var range = new TextRange(text.Document.ContentStart, text.Document.ContentEnd);
                    range.Save(s, DataFormats.Rtf);
                }

                return true;
            }
        }

        public bool SaveDocumentAs()
        {
            var sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == true)
            {
                _currentFile = sfd.FileName;

                return SaveDocument();
            }

            return false;
        }

        public void ApplyToSelection(DependencyProperty property, object value)
        {
            if (value != null)
            {
                text.Selection.ApplyPropertyValue(property, value);
            }
        }
    }
}
