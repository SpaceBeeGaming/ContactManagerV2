using ContactManagerLibrary.Models;
using ContactManagerLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ContactManagerLibrary
{
    public class ContactHandler : IContactHandler
    {
        private readonly List<ContactModel> contacts;
        private readonly IDataAccess dataAccess;

        public ContactHandler(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
            contacts = dataAccess.LoadContacts();
        }

        public List<ContactModel> GetContactsByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Argument can't be null or whitespace", nameof(name));

            return contacts.FindAll(
             delegate (ContactModel contact)
             {
                 return Regex.IsMatch(contact.FullName, $@"\b({name})\b", RegexOptions.IgnoreCase);
             });
        }

        public void RemoveContact(ContactModel contactToRemove) => contacts.Remove(contactToRemove);

        public void UpdateContact(ContactModel contactToUpdate)
        {
            contacts.Remove(contactToUpdate);
            contacts.Add(contactToUpdate);
            dataAccess.SaveContacts(contacts);
        }

        public bool AddContact(ContactModel contactToAdd)
        {
            foreach (ContactModel contact in contacts)
            {
                if (contact.Id == contactToAdd.Id)
                {
                    return false;
                }
            }
            contacts.Add(contactToAdd);
            dataAccess.SaveContacts(contacts);
            return true;
        }
    }
}
