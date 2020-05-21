using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Model
{
    public class ContactRepository
    {
        private List<Contact> _contactStore;
        private readonly string _stateFile;

        public ContactRepository()
        {
            _stateFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ContactManager.state");
            Deserialize();
        }

        public void Save(Contact contact)
        {
            if (contact.Id == Guid.Empty)
            {
                contact.Id = Guid.NewGuid();
            }
            if (!_contactStore.Contains(contact))
            {
                _contactStore.Add(contact);
            }

            Serialize();
        }
        public void Delete(Contact contact)
        {
            _contactStore.Remove(contact);

            Serialize();
        }

        public List<Contact> FindByLookup(string lookupName)
        {
            return _contactStore.Where(r => r.LookupName.StartsWith(lookupName,StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Contact> FindAll()
        {
            return _contactStore.ToList();
        }

        private void Serialize()
        {
            using (var fs = File.Open(_stateFile,FileMode.OpenOrCreate))
            {
                var binary = new BinaryFormatter();
                binary.Serialize(fs, _contactStore);
            }
        }
        private void Deserialize()
        {
            if (!File.Exists(_stateFile))
            {
                _contactStore = new List<Contact>();
                return;
            }

            using (var fs = File.Open(_stateFile,FileMode.Open))
            {
                var binary = new BinaryFormatter();
                _contactStore = binary.Deserialize(fs) as List<Contact>;
            }
        }
    }
}
