using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManagerLibrary.Models
{
    public class ContactModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }

        public Guid Id { get; set; }
        public ContactModel() => Id = new Guid();
    }
}
