using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerGarage.Models
{
    public class LoginUser
    {
        [Key]
        public int Id { get; set; }

       
        public string CustomerEmailId { get; set; }

   
        public string CustomerPassword { get; set; }
    }
}