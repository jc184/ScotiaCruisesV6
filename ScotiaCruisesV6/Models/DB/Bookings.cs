using System;
using System.Collections.Generic;

namespace ScotiaCruisesV6.Models.DB
{
    public partial class Bookings
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int NoAdults { get; set; }
        public int NoChildren { get; set; }
        public int NoInfants { get; set; }
        public DateTime SailingDate { get; set; }
        public int RouteId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Routes Route { get; set; }
    }
}
