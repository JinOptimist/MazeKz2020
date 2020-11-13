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

        public IActionResult Lvou()
        {
            var models = new List<GirlViewModel>();

            var meiViewModel = new GirlViewModel();
            meiViewModel.Name = "mei";
            meiViewModel.Hegith  = 150;
            meiViewModel.Url = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a2/Mei_Overwatch.png/220px-Mei_Overwatch.png";
            models.Add(meiViewModel);

            var ViewModel = new GirlViewModel();
            ViewModel.Name = "diva";
            ViewModel.Hegith = 150;
            ViewModel.Url = "https://i.pinimg.com/originals/36/aa/aa/36aaaaeb580f226c5d1a48c2a8821dad.jpg";
            models.Add(ViewModel);

            var bastionViewModel = new GirlViewModel();
            bastionViewModel.Name = "bastion";
            bastionViewModel.Hegith = 200;
            bastionViewModel.Url = "/image/Lvou/Bastion_portrait.png";
            models.Add(bastionViewModel);

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
      
        public IActionResult Rudich()
        {
            var models = new List<CountryRudichViewModel>();

            var jordanViewModel = new CountryRudichViewModel();
            jordanViewModel.Name = "Jordan";
            jordanViewModel.Continent = "Asia";
            jordanViewModel.Area = 92300;
            jordanViewModel.Url = "https://i.pinimg.com/originals/a5/4c/73/a54c730efc294c758934033455b7eb9d.jpg";
            models.Add(jordanViewModel);

            var indiaViewModel = new CountryRudichViewModel();
            indiaViewModel.Name = "India";
            indiaViewModel.Continent = "South Asia";
            indiaViewModel.Area = 3287263;
            indiaViewModel.Url = "https://www.africanjacana.com/wp-content/uploads/IND.jpg.image_.750.563.low_.jpg";
            models.Add(indiaViewModel);

            return View(models);
        }

        public IActionResult Srazhov()
        {
            var models = new List<AnimeGirlViewModel>();

            models.Add(new AnimeGirlViewModel()
            {
                Name = "Rem",
                TitleName = "Ri:Zero kara Hajimeru Isekai Seikatsu",
                URLToPNG = "https://i.pinimg.com/originals/3a/da/82/3ada82dc265205ee239f0f69f373aa31.png"
            });

            models.Add(new AnimeGirlViewModel()
            {
                Name = "Taiga",
                TitleName = "ToraDora",
                URLToPNG = "https://pbs.twimg.com/media/ELW4PuaVUAA1M_l.jpg"
            });

            models.Add(new AnimeGirlViewModel()
            {
                Name = "Megumin",
                TitleName = "Kono Subarashii Sekai ni Shukufuku wo!",
                URLToPNG = "https://cs10.pikabu.ru/post_img/big/2020/05/01/7/1588333493125556579.png"
            });

            return View(models);
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

        public IActionResult Proshutin()
        {
            var countries = new List<CountryViewModel>();

            var germany = new CountryViewModel("Germany", "Berlin", 81_770_900, "https://restcountries.eu/data/deu.svg", 357114.0);
            countries.Add(germany);
            var switzerland = new CountryViewModel("Switzerland", "Bern", 8_341_600, "https://restcountries.eu/data/che.svg", 41284.0);
            countries.Add(switzerland);
            var austria = new CountryViewModel("Austria", "Vienna", 8_725_931, "https://restcountries.eu/data/aut.svg", 83871.0);
            countries.Add(austria);
            var poland = new CountryViewModel("Poland", "Warsaw", 38_437_239, "https://restcountries.eu/data/pol.svg", 312679.0);
            countries.Add(poland);
            var ukraine = new CountryViewModel("Ukraine", "Kiev", 42_692_393, "https://restcountries.eu/data/ukr.svg", 603700.0);
            countries.Add(ukraine);
            var georgia = new CountryViewModel("Georgia", "Tbilisi", 3_720_400, "https://restcountries.eu/data/geo.svg", 69700.0);
            countries.Add(georgia);
            var turkey = new CountryViewModel("Turkey", "Ankara", 78_741_053, "https://restcountries.eu/data/tur.svg", 783562.0);
            countries.Add(turkey);
            var israel = new CountryViewModel("Israel", "Jerusalem", 8_527_400, "https://restcountries.eu/data/isr.svg", 20770.0);
            countries.Add(israel);
            var thailand = new CountryViewModel("Thailand", "Bangkok", 65_327_652, "https://restcountries.eu/data/tha.svg", 513120.0);
            countries.Add(thailand);
            var britain = new CountryViewModel("United Kingdom", "London", 65_110_000, "https://restcountries.eu/data/gbr.svg", 242900.0);
            countries.Add(britain);
            var russia = new CountryViewModel("Russian Federation", "Moscow", 146_599_183, "https://restcountries.eu/data/rus.svg", 17124442.0);
            countries.Add(russia);
            var indonesia = new CountryViewModel("Indonesia", "Jakarta", 258_705_000, "https://restcountries.eu/data/idn.svg", 1904569.0);
            countries.Add(indonesia);

            return View(countries);
        }
        
        public IActionResult Karayev()
        {
            var models = new List<BucsTeamCaptainViewModel>();

            var tomBrady = new BucsTeamCaptainViewModel
            {
                Name = "Tom Brady",
                Position = "Quarterback / Offense",
                College = "Michigan",
                Experience = 21,
                PhotoURL = "https://i.ibb.co/m9v7CNV/TomBrady.webp"
            };
            models.Add(tomBrady);

            var mikeEvans = new BucsTeamCaptainViewModel
            {
                Name = "Mike Evans",
                Position = "Wide Receiver / Offense",
                College = "Texas A&M",
                Experience = 7,
                PhotoURL = "https://i.ibb.co/5LfnR8j/Mike-Evans.webp"
            };
            models.Add(mikeEvans);

            var lavonteDavid = new BucsTeamCaptainViewModel
            {
                Name = "Lavonte David",
                Position = "Linebacker / Defense",
                College = "Nebraska",
                Experience = 9,
                PhotoURL = "https://i.ibb.co/PwKWRTM/Lavonte-David.webp",
            };
            models.Add(lavonteDavid);

            var devinWhite = new BucsTeamCaptainViewModel
            {
                Name = "Devin White",
                Position = "Linebacker / Defense",
                College = "LSU",
                Experience = 2,
                PhotoURL = "https://i.ibb.co/892CCqC/Devin-White.webp",
            };
            models.Add(devinWhite);

            var kevinMinter = new BucsTeamCaptainViewModel
            {
                Name = "Kevin Minter",
                Position = "Linebacker / Special Teams",
                College = "LSU",
                Experience = 8,
                PhotoURL = "https://i.ibb.co/P1S1YNR/Kevin-Minter.webp",
            };
            models.Add(kevinMinter);

            var bradleyPinion = new BucsTeamCaptainViewModel
            {
                Name = "Bradley Pinion",
                Position = "Punter / Special Teams",
                College = "Clemson",
                Experience = 6,
                PhotoURL = "https://i.ibb.co/MZ745my/Bradley-Pinion.webp",
            };
            models.Add(kevinMinter);

            return View(models);
        }
    }
}
