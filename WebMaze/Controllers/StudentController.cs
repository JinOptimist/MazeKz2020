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
