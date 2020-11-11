namespace WebMaze.Models
{
    public class ChampionViewModel
    {
        public string Name { get; set; }
        public string SplashUrl { get; set; }
        public string Fraction { get; set; }
        public string UrlFractionIcon { get; set; }
        public string ShortBio { get; set; }
        public Stats CurrentUpdateStats { get; set; }
        
        public class Stats
        {
            public double BaseHealth { get; set; }
            public double BaseMana { get; set; }
            public bool IsEnergy { get; set; }
            public double BaseDamage { get; set; }
        } 
            
    }
}