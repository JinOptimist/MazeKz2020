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
            var championModels = new List<ChampionViewModel>();
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

            championModels.Add(akaliViewModel);
            championModels.Add(gangplankViewModel);

            return View(championModels);
        }

        public IActionResult Yessenturov()
        {
            var prods = new List<ProductsViewModel>();

            prods.Add(new ProductsViewModel
            {
                Name = "Artificial limb",
                Description = "Artificial limb or Prosthesis is a next generational leap into cyber era, no difference with the original limbs in terms of cognitive feelings.",
                Price = 150000,
                imgUrl = "https://images.theconversation.com/files/127834/original/image-20160622-7165-egq4no.jpg?ixlib=rb-1.1.0&q=45&auto=format&w=926&fit=clip"
            });
            prods.Add(new ProductsViewModel
            {
                Name = "Animus",
                Description = "Animus is a virtual reality machine developed, and eventually commercialized, by Kazakh Technologies. It allows the user to read a subject's genetic memory and project the output onto an external screen in three dimensions.",
                Price = 550000,
                imgUrl = "https://static.wikia.nocookie.net/assassinscreed/images/8/8e/AC1_Animus_1.28.png"
            });
            prods.Add(new ProductsViewModel
            {
                Name = "Focus",
                Description = "​​​​​​A Focus is a small augmented reality device worn by people that serves as a multipurpose sensory interface. " +
                "This device is responsive to the user's gestures and voice, and displays a visual 3D interface visible only to them, " +
                "aiding in the operation of machinery and technology alike, as well as in communications.",
                Price = 5000,
                imgUrl = "https://static.wikia.nocookie.net/horizonzerodawn/images/3/37/Focus.png"
            });
            return View(prods);
        }

        public IActionResult Mochalkin()
        {
            var models = new List<HookahViewModel>();

            var maklaudViewModel = new HookahViewModel();
            maklaudViewModel.Name = "Maklaud Skytech";
            maklaudViewModel.Price = 26900;
            maklaudViewModel.Material = "Stainless steel";
            maklaudViewModel.ManufacturerCountry = "Russia";
            maklaudViewModel.Height = 62;
            maklaudViewModel.Url = "https://maklaud.ru/image/cache/catalog/Exlusive/Maklaud%20Skytech/Maklaud%20Skytech%20(7)-400x600.jpg";
            models.Add(maklaudViewModel);

            var vinsentViewModel = new HookahViewModel();
            vinsentViewModel.Name = "Indroduce Vinsent Vega!";
            vinsentViewModel.Price = null;
            vinsentViewModel.Url = "https://i.gifer.com/origin/3e/3e6bcf910e0ba9422b6e1ea79cdc6665_w200.webp";
            models.Add(vinsentViewModel);

            return View(models);
        }
    }
}
