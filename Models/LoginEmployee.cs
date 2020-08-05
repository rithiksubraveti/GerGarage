using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerGarage.Models
{
    public class LoginEmployee
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeEmailId { get; set; }
        public string EmployeePassword { get; set; }
    }
}