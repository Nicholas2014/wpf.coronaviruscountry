using ContactManager.Model;
using ContactManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Presenters
{
    public class EditContactPresenter:PresenterBase<EditContactView>
    {
        private readonly ApplicationPresenter _applicationPresenter;
        private readonly Contact _contact;

        public EditContactPresenter(ApplicationPresenter applicationPresenter,EditContactView view,Contact contact):base(view,"Contact.LookupName")
        {
            this._applicationPresenter = applicationPresenter;
            this._contact = contact;
        }

        public Contact Contact
        {
            get { return _contact; }
        }

        public void SelectImage()
        {
            var imagePath = View.AskUserForImagePath();
            if (!string.IsNullOrEmpty(imagePath))
            {
                Contact.ImagePath = imagePath;
            }
        }

        public void Save()
        {
            _applicationPresenter.SaveContact(Contact);
        }
        public void Delete()
        {
            _applicationPresenter.CloseTab(this);
            _applicationPresenter.DeleteContact(Contact);
        }
        public void Close()
        {
            _applicationPresenter.CloseTab(this);
        }

        public override bool Equals(object obj)
        {
            var presenter = obj as EditContactPresenter;

            return presenter != null && presenter.Contact.Equals(Contact);
        }
    }
}
