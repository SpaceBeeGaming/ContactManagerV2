using System.Collections.Generic;
using ContactManagerLibrary.Models;

namespace ContactManagerLibrary
{
    public interface IContactHandler
    {
        bool AddContact(ContactModel contactToAdd);
        List<ContactModel> GetContactsByName(string name);
        void RemoveContact(ContactModel contactToRemove);
        void UpdateContact(ContactModel contactToUpdate);
    }
}