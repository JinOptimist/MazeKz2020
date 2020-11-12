namespace WebMaze.Models
{
    public partial class ChampionViewModel
    {
        public string Name { get; set; }
        public string SplashUrl { get; set; }
        public string Fraction { get; set; }
        public string UrlFractionIcon { get; set; }
        public string ShortBio { get; set; }
        public StatsViewModel CurrentUpdateStats { get; set; }
            
    }
}