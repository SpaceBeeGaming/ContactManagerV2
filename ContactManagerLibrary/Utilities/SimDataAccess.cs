using ContactManagerLibrary.Models;
using System;
using System.Collections.Generic;

namespace ContactManagerLibrary.Utilities
{
    public class SimDataAccess : IDataAccess
    {
        public List<ContactModel> LoadContacts()
        {
            bool check = true;

            List<ContactModel> result = new List<ContactModel>()
            {
                new ContactModel { FirstName = "Space", LastName = "Bee", Email = "space.bee@example.com" },
                new ContactModel { FirstName = "Space", LastName = "Bee", Email = "space.bee@gmail.com" },
                new ContactModel { FirstName = "Foo", LastName = "Bar", Email = "foo.bar@example.com" }
            };

            return check ? result : new List<ContactModel>();
        }

        public void SaveContacts(List<ContactModel> contacts)
        {
            Console.WriteLine($"Saving {contacts} to Simulated storage");
        }
    }
}
