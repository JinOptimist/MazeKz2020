using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model.Police;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.Police.Violation;

namespace WebMaze.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViolationController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ViolationRepository violationRepo;

        public ViolationController(IMapper mapper, ViolationRepository violationRepo)
        {
            this.mapper = mapper;
            this.violationRepo = violationRepo;
        }

        [HttpGet]
        public IEnumerable<ViolationItemViewModel> Get()
        {
            return mapper.Map<ViolationItemViewModel[]>(violationRepo.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ViolationItemViewModel> Get(long id)
        {
            var item = violationRepo.Get(id);
            if(item == null)
            {
                return NotFound();
            }

            return mapper.Map<ViolationItemViewModel>(item);
        }

        [HttpPost("Search")]
        public ActionResult<ViolationSearchItems> GetSearchItems(ViolationSearchItems searchItem)
        {
            var item = violationRepo.GetByGivenSettings(searchItem.SearchWord, searchItem.DateFrom, 
                searchItem.DateTo, searchItem.Order, out int foundCount, searchItem.CurrentPage);
            
            searchItem.Violations = mapper.Map<ViolationItemViewModel[]>(item);
            searchItem.FoundCount = foundCount;
            searchItem.FoundOnThisPage = searchItem.Violations.Length;

            return searchItem;
        }

        [HttpPost]
        public ActionResult<ViolationRegistrationViewModel> Post(ViolationRegistrationViewModel item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var mappedItem = mapper.Map<Violation>(item);
            if (!violationRepo.AddViolation(mappedItem, item.UserLogin, item.PolicemanLogin))
            {
                return BadRequest();
            }

            return Ok(item);
        }
    }
}
