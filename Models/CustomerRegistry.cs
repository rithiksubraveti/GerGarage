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
    
    public partial class CustomerRegistry
    {
        public int Id { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public Nullable<long> CustomerContact { get; set; }
        public string CustomerEmailId { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPostalCode { get; set; }
    }
}
