using SalaoBeleza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaoBeleza.ViewModels
{
    public class NewBookingViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }

        public Booking Bookings { get; set; }
    }
}