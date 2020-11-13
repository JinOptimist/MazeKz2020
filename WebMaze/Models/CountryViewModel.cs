using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models
{
    public class CountryViewModel
    {
        public string CountryName { get; set; }
        public string CapitalName { get; set; }
        public int Population { get; set; }
        public string Flag { get; set; }
        public double Area { get; set; }

        public CountryViewModel(string country, string capital, int population, string flag, double area)
        {
            CountryName = country;
            CapitalName = capital;
            Population = population;
            Flag = flag;
            Area = area;
        }
    }
}
