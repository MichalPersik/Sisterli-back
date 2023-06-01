using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisterliBL.FuncClass;
using SisterliBL.FuncInterface;
using SisterliDTO.Model;

namespace Sisterli.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        IRequestBL _IRequestBL;
        public RequestController(IRequestBL RequestBL)
        {
            _IRequestBL = RequestBL;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public RequestDTO getRequestById(int id)
        {
            return _IRequestBL.getRequestById(id);
        }
        // POST api/<ValuesController>
        [HttpPost]
        public bool addRequest(RequestDTO Request)
        {
            return _IRequestBL.CreateRequest(Request);
        }

        // PUT api/<ValuesController>/5
        [HttpPut()]
        public bool PutRequest(RequestDTO Request)
        {
            return _IRequestBL.UpdateRequest(Request);
        }

        [HttpGet]
        [Route("[action]")]
        public List<RequestDTO> GetAllRequest()
        {
            return _IRequestBL.GetAllRequest();
        } 
        // DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public bool DeleteRequest(RequestDTO Request)
        //{
        //    return _IRequestBL.DeleteRequest(Request);
        //}
    }
}
