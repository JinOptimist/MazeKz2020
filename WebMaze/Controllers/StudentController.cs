using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMaze.Models;

namespace WebMaze.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var models = new List<StudentViewModel>();

            for (int i = 0; i < 5; i++)
            {
                var model = new StudentViewModel();
                model.Second = DateTime.Now.Second + i * 2;
                model.CurentUserName = "Ivan" + i;
                model.DayOfWeek = DateTime.Now.DayOfWeek.ToString();
                models.Add(model);
            }

            return View(models);
        }

        public IActionResult Meiramov()
        {
            var models = new List<GirlViewModel>();

            var meiViewModel = new GirlViewModel();
            meiViewModel.Name = "mei";
            meiViewModel.Hegith  = 150;
            meiViewModel.Url = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a2/Mei_Overwatch.png/220px-Mei_Overwatch.png";
            models.Add(meiViewModel);

            var diva = new GirlViewModel();
            diva.Name = "diva";
            diva.Hegith = 150;
            diva.Url = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a2/Mei_Overwatch.png/220px-Mei_Overwatch.png";
            models.Add(diva);

            return View(models);
        }

        public IActionResult Kenzhebayev()
        {
            var models = new List<ChampionViewModel>();
            var akaliViewModel = new ChampionViewModel
            {
                Name = "Akali",
                SplashUrl = "https://ddragon.leagueoflegends.com/cdn/img/champion/splash/Akali_0.jpg",
                Fraction = "Ionia",
                ShortBio = "Abandoning the Kinkou Order and her title of the Fist of Shadow, Akali now strikes alone, " +
                "ready to be the deadly weapon her people need. Though she holds onto all she learned from her master " +
                "Shen, she has pledged to defend Ionia from its enemies, one kill at a time. Akali may strike in silence, " +
                "but her message will be heard loud and clear: fear the assassin with no master.",
                CurrentUpdateStats = new ChampionViewModel.StatsViewModel()
                {
                    BaseHealth = 575, 
                    BaseMana = 200,
                    IsEnergy = true,
                    BaseDamage = 62.4,
                },
                UrlFractionIcon = "https://static.wikia.nocookie.net/leagueoflegends/images/a/ae/Ionia_Crest.png",
            };

            var gangplankViewModel = new ChampionViewModel
            {
                Name = "Gangplank",
                SplashUrl = "https://ddragon.leagueoflegends.com/cdn/img/champion/splash/Gangplank_0.jpg",
                Fraction = "Bilgewater",
                ShortBio = "As unpredictable as he is brutal, the dethroned reaver king Gangplank is feared far and wide. " +
                "Once, he ruled the port city of Bilgewater, and while his reign is over, there are those who believe this " +
                "has only made him more dangerous. Gangplank would see Bilgewater bathed in blood once more before letting someone " +
                "else take it—and now with pistol, cutlass, and barrels of gunpowder, he is determined to reclaim what he has lost.",
                CurrentUpdateStats = new ChampionViewModel.StatsViewModel()
                {
                    BaseHealth = 540,
                    BaseMana = 280,
                    IsEnergy = false,
                    BaseDamage = 64,
                },
                UrlFractionIcon = "https://static.wikia.nocookie.net/leagueoflegends/images/0/06/Bilgewater_Crest.png",
            };

            models.Add(akaliViewModel);
            models.Add(gangplankViewModel);

            return View(models);
        }
    }
}
