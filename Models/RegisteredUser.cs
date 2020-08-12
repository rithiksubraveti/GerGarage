using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerGarage.Models
{
    public class RegisteredUser
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name Required")]
        public string CustomerFirstName { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        public string CustomerLastName { get; set; }

        [Required(ErrorMessage = "Contact Number Required")]
        public long CustomerContact { get; set; }

        [Required(ErrorMessage = "Email Id Required")]
        public string CustomerEmailId { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string CustomerPassword { get; set; }

        [Required(ErrorMessage = "Address Required")]
        public string CustomerAddress { get; set; }

        [Required(ErrorMessage = "Postal Code Required")]
        public string CustomerPostalCode{ get; set; }

    }
}