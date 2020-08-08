using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerGarage.Models
{
    public class CustomerAppointment
    {
        [Key]
        public int BookingId { get; set; }

       public DateTime BookingDate { get; set; }
        /*private DateTime _bookingDate = DateTime.Now;
        public DateTime BookingDate { 
            get{ return (_bookingDate == DateTime.Now) ? DateTime.Now : _bookingDate; }
            set {_bookingDate = value; }
        }*/
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string ServiceType { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Remarks { get; set; }

   

    }
}