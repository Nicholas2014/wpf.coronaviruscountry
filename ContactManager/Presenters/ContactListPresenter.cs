using ContactManager.Model;
using ContactManager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Presenters
{
    public class ContactListPresenter:PresenterBase<ContactListView>
    {
        private readonly ApplicationPresenter _applicationPresenter;

        public ContactListPresenter(ApplicationPresenter applicationPresenter,ContactListView contactListView):base(contactListView,"TabHeader")
        {
            this._applicationPresenter = applicationPresenter;
        }

        public string TabHeader
        {
            get { return "All Contacts"; }
        }

        public ObservableCollection<Contact> AllContacts
        {
            get { return _applicationPresenter.CurrentContacts; }
        }

        public void OpenContact(Contact contact)
        {
            _applicationPresenter.OpenContact(contact);
        }

        public void Close()
        {
            _applicationPresenter.CloseTab(this);
        }

        public override bool Equals(object obj)
        {
            return obj != null && GetType() == obj.GetType();
        }
    }
}
