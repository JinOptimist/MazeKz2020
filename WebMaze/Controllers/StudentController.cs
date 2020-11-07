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
            meiViewModel.Hegith = 150;
            meiViewModel.Url = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a2/Mei_Overwatch.png/220px-Mei_Overwatch.png";
            models.Add(meiViewModel);

            var diva = new GirlViewModel();
            diva.Name = "diva";
            diva.Hegith = 150;
            diva.Url = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a2/Mei_Overwatch.png/220px-Mei_Overwatch.png";
            models.Add(diva);

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
                    BeverageIngredients = new List<Ingredient>
                        {
                            new Ingredient
                            {
                                Name = "Белый ром",
                                Quantity = 50,
                                Units = "мл",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/88/1586504624-white-rum_200х200.jpg",
                            },
                            new Ingredient
                            {
                                Name = "Сахарный сироп",
                                Quantity = 15,
                                Units = "мл",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/295/1562833766-Simple_syrup_-_icon.jpg",
                            },
                            new Ingredient
                            {
                                Name = "Содовая",
                                Quantity = 100,
                                Units = "мл",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/34/1596442484-4_200х200.jpg",
                            },
                            new Ingredient
                            {
                                Name = "Лайм",
                                Quantity = 80,
                                Units = "г",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/5/lime-preview.jpg",
                            },
                            new Ingredient
                            {
                                Name = "Мята",
                                Quantity = 3,
                                Units = "г",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/672/mint-preview.jpg",
                            },
                            new Ingredient
                            {
                                Name = "Дробленый лед",
                                Quantity = 200,
                                Units = "г",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/83/led-preview.jpg",
                            },
                        },
                },
                new BeverageViewModel
                {
                    // source of info = https://ru.inshaker.com/cocktails/55-negroni
                    BeverageName = "Негрони",
                    BeveragePricePerPiece = 8,
                    BeverageIngredients = new List<Ingredient>
                        {
                            new Ingredient
                            {
                                Name = "Лондонский сухой джин",
                                Quantity = 30,
                                Units = "мл",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/799/1547564665-Gin-200х200.jpg",
                            },
                            new Ingredient
                            {
                                Name = "Красный вермут",
                                Quantity = 30,
                                Units = "мл",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/36/1559121890-Red-vermouth-200х200.jpg",
                            },
                            new Ingredient
                            {
                                Name = "Красный биттер Campari",
                                Quantity = 30,
                                Units = "мл",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/47/Campari-200x200.jpg",
                            },
                            new Ingredient
                            {
                                Name = "Апельсин",
                                Quantity = 30,
                                Units = "г",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/4/orange-preview.jpg",
                            },
                            new Ingredient
                            {
                                Name = "Лед в кубиках",
                                Quantity = 120,
                                Units = "г",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/31/preview.jpg",
                            },
                        },
                },
                new BeverageViewModel
                {
                    // source of info = https://ru.inshaker.com/cocktails/44-tom-kollinz
                    BeverageName = "Том Коллинз",
                    BeveragePricePerPiece = 7,
                    BeverageIngredients = new List<Ingredient>
                        {
                            new Ingredient
                            {
                                Name = "Лондонский сухой джин",
                                Quantity = 50,
                                Units = "мл",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/799/1547564665-Gin-200х200.jpg",
                            },
                            new Ingredient
                            {
                                Name = "Сахарный сироп",
                                Quantity = 25,
                                Units = "мл",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/295/1562833766-Simple_syrup_-_icon.jpg",
                            },
                            new Ingredient
                            {
                                Name = "Лимонный сок",
                                Quantity = 25,
                                Units = "мл",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/9/Lemon_juice-preview.jpg",
                            },
                            new Ingredient
                            {
                                Name = "Содовая",
                                Quantity = 100,
                                Units = "мл",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/34/1596442484-4_200х200.jpg",
                            },
                            new Ingredient
                            {
                                Name = "Апельсин",
                                Quantity = 30,
                                Units = "г",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/4/orange-preview.jpg",
                            },
                            new Ingredient
                            {
                                Name = "Коктейльная вишня красная",
                                Quantity = 5,
                                Units = "г",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/20/preview.jpg",
                            },
                            new Ingredient
                            {
                                Name = "Лед в кубиках",
                                Quantity = 380,
                                Units = "г",
                                PictureUrl = @"https://ru.inshaker.com/uploads/good/icon_common/31/preview.jpg",
                            },
                        },
                },
            };
                
            return View(beveragesViewModel);
        }
    }
}
