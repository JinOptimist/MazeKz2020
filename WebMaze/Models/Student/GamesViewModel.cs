using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models
{
    public class GamesViewModel
    {
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int YearOfRelease { get; set; }
        public string ImageUrl { get; set; }
        public string Descriprion { get; set; }
    }

    public enum Genre
    {
        RPG = 1,
        MMO = 2,
        MOBA = 3,
        Shooter = 4
    }
}
