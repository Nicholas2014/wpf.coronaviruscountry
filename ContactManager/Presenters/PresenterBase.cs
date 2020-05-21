using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Presenters
{
    public class PresenterBase<T> : Notifier
    {
        private readonly T _view;
        private readonly string _tabHeaderPath;

        public PresenterBase(T view)
        {
            this._view = view;
        }

        public PresenterBase(T view ,string tabHeaderPath)
        {
            this._view = view;
            this._tabHeaderPath = tabHeaderPath;
        }

        public T View
        {
            get { return _view; }
        }

        public string TabHeaderPath
        {
            get { return _tabHeaderPath; }
        }
    }
}
