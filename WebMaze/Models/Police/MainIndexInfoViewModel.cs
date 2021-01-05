using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Police
{
    public class MainIndexInfoViewModel
    {
        public List<CardViewModel> Cards { get; set; }
    }

    public class CardViewModel
    {
        public string SubTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string LinkText { get; set; }
    }
}
