using System;
using System.Collections.Generic;

#nullable disable

namespace Users.Data.Model
{
    public partial class Person : IEntity
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Address { get; set; }

        public virtual Address? AddressNavigation { get; set; }
    }
}
