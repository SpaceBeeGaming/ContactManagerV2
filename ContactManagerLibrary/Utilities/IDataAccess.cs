using System.Collections.Generic;
using ContactManagerLibrary.Models;

namespace ContactManagerLibrary.Utilities
{
    public interface IDataAccess
    {
        List<ContactModel> LoadContacts();
        void SaveContacts(List<ContactModel> contacts);
    }
}