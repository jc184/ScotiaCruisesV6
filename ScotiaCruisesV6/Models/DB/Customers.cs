using System;
using System.Collections.Generic;

namespace ScotiaCruisesV6.Models.DB
{
    public partial class Customers
    {
        public Customers()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
