using System.Collections.Generic;

#nullable disable

namespace Users.Data.Model
{
    public partial class Сountry : IEntity
    {
        public Сountry()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
