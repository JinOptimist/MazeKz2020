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
    }
}
