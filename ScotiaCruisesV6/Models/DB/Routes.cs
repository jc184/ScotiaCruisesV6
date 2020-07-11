using System;
using System.Collections.Generic;

namespace ScotiaCruisesV6.Models.DB
{
    public partial class Routes
    {
        public Routes()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int RouteId { get; set; }
        public string RouteName { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
