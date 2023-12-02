using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tourTravels.Models
{
    public class ContactUs
    {
        [Required(ErrorMessage ="Enter Your Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Enter Your Email")]
        [DataType (DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Enter Your Phone Number")]
        [DataType (DataType.PhoneNumber)]  
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Enter Your Message")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set;}
                             
    }
}