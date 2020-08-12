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
       public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleFuelType { get; set; }
        public string ServiceType { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Remarks { get; set; }

   

    }
}