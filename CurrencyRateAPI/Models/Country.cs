using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CurrencyRateAPI.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        //FK
        public int CurrencyId { get; set; }

        [Required]
        public string CountryName { get; set; }
        
        //Navigation Property
        public Currency Currency { get; set; }
    }
}