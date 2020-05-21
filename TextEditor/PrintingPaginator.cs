using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace TextEditor
{
    public class PrintingPaginator : DocumentPaginator
    {
        private readonly DocumentPaginator _originalPaginator;
        private readonly Size _pageSize;
        private readonly Size _margin;

        public PrintingPaginator(DocumentPaginator documentPaginator, Size pageSize, Size margin)
        {
            this._originalPaginator = documentPaginator;
            this._pageSize = pageSize;
            this._margin = margin;

            this._originalPaginator.PageSize = new Size(_pageSize.Width - _margin.Width * 2, _pageSize.Height - margin.Height * 2);
            this._originalPaginator.ComputePageCount();
        }
        public override bool IsPageCountValid => this._originalPaginator.IsPageCountValid;

        public override int PageCount => this._originalPaginator.PageCount;

        public override Size PageSize { get => this._originalPaginator.PageSize; set => this._originalPaginator.PageSize = value; }

        public override IDocumentPaginatorSource Source => this._originalPaginator.Source;

        public override DocumentPage GetPage(int pageNumber)
        {
            var page = this._originalPaginator.GetPage(pageNumber);
            var fixedPage = new ContainerVisual();
            fixedPage.Children.Add(page.Visual);
            fixedPage.Transform = new TranslateTransform(_margin.Width, _margin.Height);

            return new DocumentPage(fixedPage, _pageSize, AdjustForMargins(page.BleedBox), AdjustForMargins(page.ContentBox));
        }

        private Rect AdjustForMargins(Rect rect)
        {
            if (rect.IsEmpty)
            {
                return rect;
            }
            else
            {
                return new Rect(rect.Left + _margin.Width, rect.Top + _margin.Height, rect.Width, rect.Height);
            }
        }
    }
}
