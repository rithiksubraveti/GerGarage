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
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public int EmployeeContact { get; set; }

        public string EmployeeEmailId { get; set; }
        public string EmployeePassword { get; set; }
    }
}
   