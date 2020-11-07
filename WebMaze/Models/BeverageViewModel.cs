using System.Collections.Generic;
using System.Globalization;
using System.Security.Policy;

namespace WebMaze.Models
{
    public class BeverageViewModel
    {
        public string BeverageName { get; set; }
        public List<Ingredient> BeverageIngredients { get; set; }

        public decimal BeveragePricePerPiece { get; set; }

        public string BeveragePriceAsString
        {
            get => BeveragePricePerPiece.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
        }

    }

    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Units { get; set; }
        public string PictureUrl { get; set; }

    }
}