using System.Collections.Generic;
using System.Globalization;
using System.Security.Policy;

namespace WebMaze.Models
{
    public class BeverageViewModel
    {
        public string BeverageName { get; set; }
        public List<BeverageIngredient> BeverageIngredients { get; set; }

        public decimal BeveragePricePerPiece { get; set; }

        public string BeveragePriceAsString
        {
            get => BeveragePricePerPiece.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
        }

    }
    
}