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
        public IActionResult Rudich()
        {
            var models = new List<CountryViewModel>();

            var jordanViewModel = new CountryViewModel();
            jordanViewModel.Name = "Jordan";
            jordanViewModel.Continent = "Asia";
            jordanViewModel.Area = 92300;
            jordanViewModel.Url = "https://i.pinimg.com/originals/a5/4c/73/a54c730efc294c758934033455b7eb9d.jpg";
            models.Add(jordanViewModel);

            var indiaViewModel = new CountryViewModel();
            indiaViewModel.Name = "India";
            indiaViewModel.Continent = "South Asia";
            indiaViewModel.Area = 3287263;
            indiaViewModel.Url = "https://www.africanjacana.com/wp-content/uploads/IND.jpg.image_.750.563.low_.jpg";
            models.Add(indiaViewModel);
            return models;
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
            models.Add(vinsentViewModel)

            return View(models);
        }
    }
}
