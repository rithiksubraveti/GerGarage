﻿using System;
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
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public long CustomerContact { get; set; }
        public string CustomerEmailId { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPostalCode { get; set; }
    }
}