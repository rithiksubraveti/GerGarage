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
        [Required(ErrorMessage = "Customer Name is required")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Email Id is required")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Vehicle Brand is required")]
        public string VehicleMake { get; set; }

        [Required(ErrorMessage = "Car Model  is required")]
        public string VehicleModel { get; set; }

        [Required(ErrorMessage = "Car Registered Number is required")]
        public string VehicleNumber { get; set; }

        [Required(ErrorMessage = "Car fuel type is required")]
        public string VehicleFuelType { get; set; }

        [Required(ErrorMessage = "Please select the service you are looking for")]
        public string ServiceType { get; set; }
        public DateTime ServiceDate { get; set; }
       
        public string Remarks { get; set; }

   

    }
}