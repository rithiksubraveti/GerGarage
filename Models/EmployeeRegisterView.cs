using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace GerGarage.Models
{
    public class EmployeeRegisterView
    {
        [Key]
        [Required(ErrorMessage = "First Name is required")]
        public string EmployeeFirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string EmployeeLastName { get; set; }
        [Required(ErrorMessage = "Contact Number is required")]
        public int EmployeeContact { get; set; }
        [Required(ErrorMessage = "Email Id is required")]
        public string EmployeeEmailId { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string EmployeePassword { get; set; }
    }
}
   