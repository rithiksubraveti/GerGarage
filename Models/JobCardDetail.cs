//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GerGarage.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class JobCardDetail
    {
        public int JobNumber { get; set; }
        public int BookingId { get; set; }
        public System.DateTime ServiceDate { get; set; }
        public string CustomerName { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string ServiceType { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string MechanicAssigned { get; set; }
        public string JobStatus { get; set; }
    
        public virtual CustomerBooking CustomerBooking { get; set; }
    }
}
