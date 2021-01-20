using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Police.Violation
{
    public class ViolationSearchItems
    {
        public string SearchWord { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int FoundCount { get; set; }
        public int FoundOnThisPage { get; set; }
        public int CurrentPage { get; set; }
        public WayOfOrder Order { get; set; } = WayOfOrder.Latest;

        public ViolationItemViewModel[] Violations { get; set; }
    }

    public enum WayOfOrder
    {
        Latest,
        Earliest,
        ABCUser,
        ABCPolice
    }
}
