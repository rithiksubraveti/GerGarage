using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerGarage.Models
{
    public class RegisteredEmployee
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public long EmployeeContact { get; set; }
        public string EmployeeEmailId { get; set; }
        public string EmployeePassword { get; set; }
    }
   
}