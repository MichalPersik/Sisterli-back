using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SisterliBL;
using SisterliBL.FuncInterface;
using SisterLiDAL;
using SisterLiDAL.Models;
using SisterliDTO.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sisterli.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MomController : ControllerBase
    {
        IMomBL _momBL;
        public MomController(IMomBL momBL)
        {
            _momBL = momBL;
        }

        [HttpGet]
        [Route("[action]")]
        //[Route("getMomById")]
        public MomDTO getMomById([FromQuery] string id, [FromQuery] string password)
        {
          Response.Headers.AccessControlAllowOrigin = "*";
            return _momBL.getMomById(id,password);
        }

        [HttpPost]
        //[Route("addMom")]
        public bool addMom(MomDTO mom)
        {
          return  _momBL.CreateMom(mom);
        }

        [HttpPut()]
        //[Route("UpdateMom")]
        public bool UpdateMom(MomDTO mom)
        {
         return  _momBL.UpdateMom(mom);
        }


    }
}
