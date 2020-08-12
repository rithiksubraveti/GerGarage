using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerGarage.Models
{
    public class UserRegisterView
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string CustomerFirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string CustomerLastName { get; set; }
        [Required(ErrorMessage = "Contact Number is required")]
        public long CustomerContact { get; set; }
        [Required(ErrorMessage = "Email Id is required")]
        public string CustomerEmailId { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string CustomerPassword { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string CustomerAddress { get; set; }
        [Required(ErrorMessage = "Postal Code is required")]
        public string CustomerPostalCode { get; set; }
    }
}