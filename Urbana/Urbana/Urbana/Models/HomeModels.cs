using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
namespace Urbana.Models
{
    public class ContactModel
    {
        [Display(Name="First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }
        public string Company { get; set; }
        public string PhonePrefix { get; set; }
        public string PhoneAreaCode { get; set; }
        public string PhoneSuffix { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}