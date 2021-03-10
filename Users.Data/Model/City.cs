using System;
using System.Collections.Generic;

#nullable disable

namespace Users.Data.Model
{
    public partial class City : IEntity
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string City1 { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
