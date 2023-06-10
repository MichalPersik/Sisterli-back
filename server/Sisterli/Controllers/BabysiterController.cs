//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisterliBL;
using SisterliBL.FuncClass;
using SisterLiDAL;
using SisterliDTO.Model;
using SisterliBL.FuncInterface;
using AutoMapper;
using SisterLiDAL.Models;


namespace SisterliAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BabysiterController : ControllerBase
    {
        IBabysiterBL _BabysiterBL;

        public BabysiterController(IBabysiterBL babysiterBL)
        {
            _BabysiterBL = babysiterBL;
        }

        [HttpGet]
        [Route("[action]")]
        // [Route("GetBabysiterById")]
        public String test()
        {
            return "this is test"; 
        }

        [HttpGet]
        [Route("[action]")]
        // [Route("GetBabysiterById")]
        public BabysiterDTO GetBabysiterById([FromQuery]string id, [FromQuery] string password)
        {
            return _BabysiterBL.getBabysitterById(id,password);
        }
        [HttpGet]
        [Route("[action]")]
        public List<BabysiterDTO> GetAllBabysiters()
        {
            //HttpContext.Response.Headers
            Response.Headers.AccessControlAllowOrigin = "*";// ("Access-Control-Allow-Origin", "*");

            return _BabysiterBL.GetAllBabysiters();
        }
        //[HttpGet]
        //[Route("[action]")]
        //public List<BabysiterDTO> GetAllBabysiters()
        //{
        //    return _BabysiterBL.GetAllUsers();
        //}

        [HttpPost]
        // [Route("addBabysiter")]
        [Route("[action]")]

        public bool addBabysiter(BabysiterDTO babysiter)
        {
            return _BabysiterBL.CreateBabysitter(babysiter);
        }

        [HttpPut()]
       // [Route("UpdateBabysitter")]
        public bool UpdateBabysitter(BabysiterDTO Babysiter)
        {
            return _BabysiterBL.UpdateBabysitter(Babysiter);
        }


    }
}
