using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hand2hand.Models
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Shipping address")]
        [Display(Name = "Adress 1")]
        public string Line1 { get; set; }
        [Display(Name = "Adress 2")]
        public string Line2 { get; set; }
        [Display(Name = "Adress 3")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Shipping city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Shipping country")]
        public string Country { get; set; }

        public bool IsGift { get; set; }
    }
}