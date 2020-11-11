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
