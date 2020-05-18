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
    public class PrintManager
    {
        public static readonly int DPI = 96;
        private readonly RichTextBox richTextBox;

        public PrintManager(RichTextBox richTextBox)
        {
            this.richTextBox = richTextBox;
        }

        public bool Print()
        {
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                var printQueue = printDialog.PrintQueue;
                var paginator = GetPaginator(printQueue.UserPrintTicket.PageMediaSize.Width.Value,
                    printQueue.UserPrintTicket.PageMediaSize.Height.Value);
                printDialog.PrintDocument(paginator, "TextEditor Printing");

                return true;
            }

            return false;
        }

        public void PrintPreview()
        {
            var dlg = new PrintPreviewDialog(this);
            dlg.ShowDialog();
        }

        public DocumentPaginator GetPaginator(double pageWidth,double pageHeight)
        {
            var originalRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            var ms = new MemoryStream();
            originalRange.Save(ms, DataFormats.Xaml);

            var copy = new FlowDocument();
            var copyRange = new TextRange(copy.ContentStart, copy.ContentEnd);
            copyRange.Load(ms, DataFormats.Xaml);

            var paginator = ((IDocumentPaginatorSource)copy).DocumentPaginator;

            return new PrintingPaginator(paginator, new Size(pageWidth, pageHeight), new Size(DPI, DPI));
        }
    }
}
