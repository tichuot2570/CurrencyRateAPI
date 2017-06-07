using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyRateAPI.Models
{
    public class Currency
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Rate { get; set; }
        //Navigation Property
        public ICollection<Country> Countries { get; set; }
    }
}