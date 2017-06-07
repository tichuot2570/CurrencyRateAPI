using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyRateAPI.Models
{
    public class CurrencyDetailDTO
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Rate { get; set; }

        public List<Country> Countries { get; set; }
    }
}