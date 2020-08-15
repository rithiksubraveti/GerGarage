
namespace GerGarage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class JobDetail
    {
        public int JobNumber { get; set; }
        public int BookingId { get; set; }
        public System.DateTime ServiceDate { get; set; }
        public string CustomerName { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarNumber { get; set; }
        public string ServiceType { get; set; }
        public string CustomerMessage { get; set; }
        [Required(ErrorMessage = "Please enter the estimated rate")]
        public Nullable<decimal> Rate { get; set; }
        [Required(ErrorMessage = "Please Assign a mechanic")]
        public string MechanicAssigned { get; set; }
        [Required(ErrorMessage = "Please update the Job Status")]
        public string JobStatus { get; set; }
    
        public virtual CustomersBooking CustomersBooking { get; set; }
    }
}
