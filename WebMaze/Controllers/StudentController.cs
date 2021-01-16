using MazeKz;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebMaze.Controllers.CustomAttribute;
using WebMaze.DbStuff;
using WebMaze.DbStuff.Model;
using WebMaze.Models;


namespace WebMaze.Controllers
{
    public class StudentController : Controller
    {
        private WebMazeContext _webMazeContext;

        private const int MazeWidth = 25;
        private const int MazeHeight = 20;

        public StudentController(WebMazeContext webMazeContext)
        {
            _webMazeContext = webMazeContext;
        }

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

        [IsAdmin]
        public IActionResult Lvou()
        {
            var viewModels = new List<GirlViewModel>();

            var dbCitizens = _webMazeContext.CitizenUser;

            foreach (var citizen in dbCitizens)
            {
                var meiViewModel = new GirlViewModel();
                meiViewModel.Name = citizen.Login;
                meiViewModel.Url = citizen.AvatarUrl;
                viewModels.Add(meiViewModel);
            }

            return View(viewModels);
        }

        public IActionResult AddCitizen(string name, string url)
        {
            var dbModel = new CitizenUser()
            {
                Login = name,
                AvatarUrl = url
            };

            _webMazeContext.CitizenUser.Add(dbModel);

            _webMazeContext.SaveChanges();

            return RedirectToAction("Lvou", "Student");
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
            var models = new List<InteriorViewModel>();

            models.Add(new InteriorViewModel()
            {
                StyleName = "Kitchen",
                Area = 18,
                ImgUrl = "/image/Rudich/kitchen.jpg",
            });

            models.Add(new InteriorViewModel()
            {
                StyleName = "Bathroom",
                Area = 15,
                ImgUrl = "/image/Rudich/bathroom.jpg",
            });

            models.Add(new InteriorViewModel()
            {
                StyleName = "Bedroom",
                Area = 22,
                ImgUrl = "/image/Rudich/bedroom.jpg",
            });

            models.Add(new InteriorViewModel()
            {
                StyleName = "Wardrobe",
                Area = 13,
                ImgUrl = "/image/Rudich/wardrobe.jpg",
            });

            models.Add(new InteriorViewModel()
            {
                StyleName = "Living room",
                Area = 22,
                ImgUrl = "/image/Rudich/living-room.jpg",
            });

            models.Add(new InteriorViewModel()
            {
                StyleName = "Home office",
                Area = 13,
                ImgUrl = "/image/Rudich/home-office.jpg",
            });

            return View(models);
        }

        public IActionResult Yermolayev()
        {
            var beveragesViewModel = new List<BeverageViewModel>
            {
                new BeverageViewModel
                {
                    // source of info = https://ru.inshaker.com/cocktails/57-mohito
                    BeverageName = "Мохито",
                    BeveragePricePerPiece = 5,
                    BeverageIngredients = new List<BeverageIngredient>
                        {
                            new BeverageIngredient
                            {
                                Name = "Белый ром",
                                Quantity = 50,
                                Units = BeverageIngredientUnit.mL,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/88/1586504624-white-rum_200х200.jpg",
                            },
                            new BeverageIngredient
                            {
                                Name = "Сахарный сироп",
                                Quantity = 15,
                                Units = BeverageIngredientUnit.mL,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/295/1562833766-Simple_syrup_-_icon.jpg",
                            },
                            new BeverageIngredient
                            {
                                Name = "Содовая",
                                Quantity = 100,
                                Units = BeverageIngredientUnit.mL,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/34/1596442484-4_200х200.jpg",
                            },
                            new BeverageIngredient
                            {
                                Name = "Лайм",
                                Quantity = 80,
                                Units = BeverageIngredientUnit.g,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/5/lime-preview.jpg",
                            },
                            new BeverageIngredient
                            {
                                Name = "Мята",
                                Quantity = 3,
                                Units = BeverageIngredientUnit.g,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/672/mint-preview.jpg",
                            },
                            new BeverageIngredient
                            {
                                Name = "Дробленый лед",
                                Quantity = 200,
                                Units = BeverageIngredientUnit.g,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/83/led-preview.jpg",
                            },
                        },
                },
                new BeverageViewModel
                {
                    // source of info = https://ru.inshaker.com/cocktails/55-negroni
                    BeverageName = "Негрони",
                    BeveragePricePerPiece = 8,
                    BeverageIngredients = new List<BeverageIngredient>
                        {
                            new BeverageIngredient
                            {
                                Name = "Лондонский сухой джин",
                                Quantity = 30,
                                Units = BeverageIngredientUnit.mL,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/799/1547564665-Gin-200х200.jpg",
                            },
                            new BeverageIngredient
                            {
                                Name = "Красный вермут",
                                Quantity = 30,
                                Units = BeverageIngredientUnit.mL,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/36/1559121890-Red-vermouth-200х200.jpg",
                            },
                            new BeverageIngredient
                            {
                                Name = "Красный биттер Campari",
                                Quantity = 30,
                                Units = BeverageIngredientUnit.mL,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/47/Campari-200x200.jpg",
                            },
                            new BeverageIngredient
                            {
                                Name = "Апельсин",
                                Quantity = 30,
                                Units = BeverageIngredientUnit.g,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/4/orange-preview.jpg",
                            },
                            new BeverageIngredient
                            {
                                Name = "Лед в кубиках",
                                Quantity = 120,
                                Units = BeverageIngredientUnit.g,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/31/preview.jpg",
                            },
                        },
                },
                new BeverageViewModel
                {
                    // source of info = https://ru.inshaker.com/cocktails/44-tom-kollinz
                    BeverageName = "Том Коллинз",
                    BeveragePricePerPiece = 7,
                    BeverageIngredients = new List<BeverageIngredient>
                        {
                            new BeverageIngredient
                            {
                                Name = "Лондонский сухой джин",
                                Quantity = 50,
                                Units = BeverageIngredientUnit.mL,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/799/1547564665-Gin-200х200.jpg",
                            },
                            new BeverageIngredient
                            {
                                Name = "Сахарный сироп",
                                Quantity = 25,
                                Units = BeverageIngredientUnit.mL,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/295/1562833766-Simple_syrup_-_icon.jpg",
                            },
                            new BeverageIngredient
                            {
                                Name = "Лимонный сок",
                                Quantity = 25,
                                Units = BeverageIngredientUnit.mL,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/9/Lemon_juice-preview.jpg",
                            },
                            new BeverageIngredient
                            {
                                Name = "Содовая",
                                Quantity = 100,
                                Units = BeverageIngredientUnit.mL,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/34/1596442484-4_200х200.jpg",
                            },
                            new BeverageIngredient
                            {
                                Name = "Апельсин",
                                Quantity = 30,
                                Units = BeverageIngredientUnit.g,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/4/orange-preview.jpg",
                            },
                            new BeverageIngredient
                            {
                                Name = "Коктейльная вишня красная",
                                Quantity = 5,
                                Units = BeverageIngredientUnit.g,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/20/preview.jpg",
                            },
                            new BeverageIngredient
                            {
                                Name = "Лед в кубиках",
                                Quantity = 380,
                                Units = BeverageIngredientUnit.g,
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/31/preview.jpg",
                            },
                        },
                },
            };

            return View(beveragesViewModel);
        }

        public IActionResult Velinskiy()
        {
            var models = new List<GwentViewModel>();

            var GeraltViewModel = new GwentViewModel();
            GeraltViewModel.CardAbility = "";
            GeraltViewModel.CardDescription = "If that's what it takes to save the world, it's better to let that world die.";
            GeraltViewModel.CardStrenght = 15;
            GeraltViewModel.CardTitle = "Geralt of Rivia";
            GeraltViewModel.CardUrl = "https://cdnb.artstation.com/p/assets/images/images/000/848/617/large/marek-madej-gwent-geralt-by-marekmadej.jpg?1443928905";
            GeraltViewModel.CardFaction = GwentViewModel.Faction.Neutral;
            models.Add(GeraltViewModel);

            var TiborViewModel = new GwentViewModel();
            TiborViewModel.CardAbility = "Deploy: If neither player has passed, Boost self by 15, then your opponent draws the top Bronze card from their Deck and Reveals it.";
            TiborViewModel.CardDescription = "Tibor's zeal was legendary. It was said when the emperor passed, he'd not so much bow as somersault.";
            TiborViewModel.CardStrenght = 10;
            TiborViewModel.CardTitle = "Tibor Eggebracht";
            TiborViewModel.CardUrl = "https://i.pinimg.com/originals/00/8f/7d/008f7d76ec909ad104a0d4a478f60675.jpg";
            TiborViewModel.CardFaction = GwentViewModel.Faction.Nilfgaard;
            models.Add(TiborViewModel);

            var DandelionViewModel = new GwentViewModel();
            DandelionViewModel.CardAbility = "Deploy: Add 2 strength to every non-Gold unit played on your side of the battlefield.";
            DandelionViewModel.CardDescription = "Dandelion, you're a cynic, a lecher, a liar – and my best friend.";
            DandelionViewModel.CardStrenght = 4;
            DandelionViewModel.CardTitle = "Dandelion";
            DandelionViewModel.CardUrl = "https://i.pinimg.com/originals/74/c7/96/74c796199c5fea2aa05ee2a9565b43c2.jpg";
            DandelionViewModel.CardFaction = GwentViewModel.Faction.Northern_Realms;
            models.Add(DandelionViewModel);
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

        public IActionResult Akhmetov()
        {
            var buildings = new List<BuildingViewModel>() {
                new BuildingViewModel
                {
                    Name = "Бурдж-Халифа",
                    Description = "Cверхвысотный небоскрёб высотой 828 метров в Дубае (ОАЭ), самое высокое и самое многоэтажное здание в мире.",
                    Url = "https://kuku.travel/wp-content/uploads/2018/07/%D0%9D%D0%B5%D0%B1%D0%BE%D1%81%D0%BA%D1%80%D0%B5%D0%B1-%D0%91%D1%83%D1%80%D0%B4%D0%B6-%D0%A5%D0%B0%D0%BB%D0%B8%D1%84%D0%B0-%D0%B2-%D0%94%D1%83%D0%B1%D0%B0%D0%B5.jpg",
                    Height = 828
                },
                new BuildingViewModel
                {
                    Name = "Шанхайская башня",
                    Description = "Cверхвысокое здание в районе Пудун города Шанхай в Китае.",
                    Url = "https://www.votpusk.ru/gallery/mobile/132311.jpg",
                    Height = 632
                },
                new BuildingViewModel
                {
                    Name = "Часовая королевская башня",
                    Description = "Расположена в городе Мекка, Саудовская Аравия.",
                    Url = "https://islamosfera.ru/wp-content/uploads/2019/12/%D0%90%D0%B1%D1%80%D0%B0%D0%B4%D0%B6-%D0%B0%D0%BB%D1%8C-%D0%91%D0%B5%D0%B9%D1%82-1024x683.jpg",
                    Height = 601
                },
                new BuildingViewModel
                {
                    Name = "Международный финансовый центр Пинань",
                    Description = "Комплекс зданий, включающий 599-метровый, 115-этажный небоскрёб в городе Шэньчжэнь, провинция Гуандун, Китай.",
                    Url = "https://images.adsttc.com/media/images/5a4c/6cb4/b22e/38fb/6600/00e0/large_jpg/3_Ping_An_FC_(c)_Tim_Griffith.jpg?1514957995",
                    Height = 599
                },
                new BuildingViewModel
                {
                    Name = "Lotte World Tower",
                    Description = "123-этажный сверхвысокий небоскрёб, в районе развлекательного комплекса Lotte World в Сеуле, Южная Корея.",
                    Url = "https://i.insider.com/5c12c950a040ff03023de2c9?width=1100&format=jpeg&auto=webp",
                    Height = 555
                },
                new BuildingViewModel
                {
                    Name = "Всемирный торговый центр 1",
                    Description = "Центральное здание в новом комплексе Всемирного торгового центра в нижнем Манхэттене (город Нью-Йорк, США).",
                    Url = "https://aecom.com/wp-content/uploads/2015/10/1WTC_Credit-Michael-Mahesh-PANYNJ-810x531.jpg",
                    Height = 541
                }
            };

            return View(buildings.OrderByDescending(building => building.Height).ToList());
        }

        public IActionResult Shilnikov()
        {
            List<HeroViewModels> heroes = new List<HeroViewModels>
            {
                new HeroViewModels { Name="Blast", Number=1, Rang=HeroViewModels.Rangs.S, UrlPhoto="/image/Shilnikov/Blast.jpg" },
                new HeroViewModels { Name="Tornado of Terror", Number=2, Rang=HeroViewModels.Rangs.S, UrlPhoto="/image/Shilnikov/Tatsumaki_Manga.webp" },
                new HeroViewModels { Name="Silver Fang", Number=3, Rang=HeroViewModels.Rangs.S, UrlPhoto="/image/Shilnikov/Bang_Manga_Profile.webp" },
                new HeroViewModels { Name="Secret Mask", Number=1, Rang=HeroViewModels.Rangs.A, UrlPhoto="/image/Shilnikov/SweetMaskProfile.webp" },
                new HeroViewModels { Name="Iaian", Number=2, Rang=HeroViewModels.Rangs.A, UrlPhoto="/image/Shilnikov/Iaian_Anime_Profile.webp" },
                new HeroViewModels { Name="Okamaitachi", Number=3, Rang=HeroViewModels.Rangs.A, UrlPhoto="/image/Shilnikov/Slicing_SheMan.webp" },
                new HeroViewModels { Name="Fubuki", Number=1, Rang=HeroViewModels.Rangs.B, UrlPhoto="/image/Shilnikov/Fubuki_Manga.webp" },
                new HeroViewModels { Name="Eyelashes", Number=2, Rang=HeroViewModels.Rangs.B, UrlPhoto="/image/Shilnikov/Eyelashes_Anime.webp" },
                new HeroViewModels { Name="Saitama", Number=7, Rang=HeroViewModels.Rangs.B, UrlPhoto="/image/Shilnikov/Saitama_Manga.webp" },
                new HeroViewModels { Name="Satoru", Number=1, Rang=HeroViewModels.Rangs.C, UrlPhoto="/image/Shilnikov/Mumen_Rider_Manga.webp" },
                new HeroViewModels { Name="Monster Roper Shell", Number=3, Rang=HeroViewModels.Rangs.C, UrlPhoto="/image/Shilnikov/Monster_Roper_Shell.webp" },
                new HeroViewModels { Name="Horse-Bone", Number=283, Rang=HeroViewModels.Rangs.C, UrlPhoto="/image/Shilnikov/HorseBoneAnime.webp" },
            };

            return View(heroes);
        }

        public IActionResult Boris()
        {
            var mazeGenerator = new MazeGenerator();
            var maze = mazeGenerator.GenerateSmart(MazeWidth, MazeHeight);
            return View(new MazeViewModel(maze));

        }


        public IActionResult Batyrov()
        {
            var models = new List<GamesViewModel>();

            var tes = new GamesViewModel()
            {
                Name = "The Elder Scrolls 5. Skyrim",
                Genre = Genre.RPG,
                YearOfRelease = 2011,
                ImageUrl = "https://u.kanobu.ru/editor/images/29/3caaccd8-417b-4170-8fbe-7facfdbdc308.jpg",
                Descriprion = "мультиплатформенная компьютерная ролевая игра с открытым миром, разработанная студией Bethesda Game Studios и выпущенная компанией Bethesda Softworks. Это пятая часть в серии The Elder Scrolls. Игра была выпущена 11 ноября 2011 года для Windows, Playstation 3 и Xbox 360. Для игры были выпущены три загружаемых дополнения под названиями Dawnguard, Hearthfire и Dragonborn, позже объединённых в издании The Elder Scrolls V: Skyrim — Legendary Edition."
            };
            models.Add(tes);

            var witcher = new GamesViewModel()
            {
                Name = "The Witcher",
                Genre = Genre.RPG,
                YearOfRelease = 2015,
                ImageUrl = "https://www.overclockers.ua/news/games/126893-witcher3.jpg",
                Descriprion = "мультиплатформенная компьютерная игра в жанре action/RPG, разработанная польской студией CD Projekt RED по мотивам серии романов «Ведьмак» польского писателя Анджея Сапковского, выпущенная в 2015 году для Windows, PlayStation 4 и Xbox One. Игра является продолжением компьютерных игр «Ведьмак» и «Ведьмак 2: Убийцы королей», заключительной частью трилогии"
            };
            models.Add(witcher);

            var lol = new GamesViewModel()
            {
                Name = "League Of Legends",
                Genre = Genre.MOBA,
                YearOfRelease = 2009,
                ImageUrl = "https://3dnews.ru/assets/external/illustrations/2020/07/25/1016625/01.jpg",
                Descriprion = "сокращённо LoL — ролевая видеоигра с элементами стратегии в реальном времени (MOBA), разработанная и выпущенная компанией Riot Games 27 октября 2009 года для платформ Microsoft Windows и Apple Macintosh[1]. Игра распространяется по модели free-to-play. Ежемесячная аудитория игры составляет 100 млн игроков по всему миру"
            };
            models.Add(lol);



            return View(models);
        }

        public IActionResult Maralov()
        {
            var shrekCharacters = new List<ShrekViewModel>()
            {
                new ShrekViewModel { Name = "Shrek", Url = "/image/Maralov/shrek.jpg" },
                new ShrekViewModel { Name = "Fiona", Url = "/image/Maralov/fiona.jpg" },
                new ShrekViewModel { Name = "Donkey", Url = "/image/Maralov/donkey.jpg"}
            };

            return View(shrekCharacters);
        }
        
        public IActionResult Samorukov()
        {
            var quoteModels = new List<SimpleLifeQuotesViewModel>();
            var pigsViewModel = new SimpleLifeQuotesViewModel
            {
                CardName = "Свиньи",
                CardText = "Не мечите бисер перед свиньями",
                CardImgUrl = "https://i.pinimg.com/originals/4d/ae/71/4dae71ba812c20c0560360fe9e668b03.jpg",
                AuthorOfQuote = "Библия"
            };
            quoteModels.Add(pigsViewModel);

            var poisonViewModel = new SimpleLifeQuotesViewModel()
            {
                CardName = "Яд",
                CardText = "Всё – яд, всё – лекарство. Решает доза.",
                CardImgUrl = "https://arteymedicinalasseriesart.files.wordpress.com/2020/02/11-3.jpg?w=962",
                AuthorOfQuote = "Парацельс"
            };
            quoteModels.Add(poisonViewModel);

            var lieViewModel = new SimpleLifeQuotesViewModel()
            {
                CardName = "Ложь",
                CardText = "Есть три вида лжи: ложь, наглая ложь и статистика.",
                CardImgUrl = "https://i.pinimg.com/originals/73/1a/6d/731a6d7b6db4a972682fdddfb1930773.jpg",
                AuthorOfQuote = "Марк Твен"
            };
            quoteModels.Add(lieViewModel);

            return View(quoteModels);
        }

        public IActionResult Saginbek()
        {
            var gameModels = new List<SaginbekViewModel>();

            var cyberpunkModel = new SaginbekViewModel();
            cyberpunkModel.GamePosterURL = "https://metro.co.uk/wp-content/uploads/2019/06/cyberpunk-2077-84e5.jpg?quality=90&strip=all";
            cyberpunkModel.GameDescription = "Cyberpunk 2077 is an open-world, action-adventure story set in Night City.";
            cyberpunkModel.GameSteamURL = "https://store.steampowered.com/app/1091500/Cyberpunk_2077/";
            gameModels.Add(cyberpunkModel);

            var sekiroModel = new SaginbekViewModel();
            sekiroModel.GamePosterURL = "https://gamingbolt.com/wp-content/uploads/2019/03/sekiro-1280x720.jpg";
            sekiroModel.GameDescription = "In Sekiro: Shadows Die Twice you are the 'one-armed wolf', a disgraced and disfigured warrior rescued from the brink of death.";
            sekiroModel.GameSteamURL = "https://store.steampowered.com/app/814380/Sekiro_Shadows_Die_Twice__GOTY_Edition/";
            gameModels.Add(sekiroModel);

            var mortalKombat = new SaginbekViewModel();
            mortalKombat.GamePosterURL = "https://images.hdqwalls.com/download/mortal-kombat-11-81-1280x720.jpg";
            mortalKombat.GameDescription = "Mortal Kombat is back and better than ever in the next evolution of the iconic franchise.";
            mortalKombat.GameSteamURL = "https://store.steampowered.com/app/976310/Mortal_Kombat11/";
            gameModels.Add(mortalKombat);

            return View(gameModels);
        }
    }
}
