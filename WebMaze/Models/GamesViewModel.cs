using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models
{
    public class GamesViewModel
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public int YearOfRelease { get; set; }
        public string ImageUrl { get; set; }
        public string Descriprion { get; set; }
    }
}
