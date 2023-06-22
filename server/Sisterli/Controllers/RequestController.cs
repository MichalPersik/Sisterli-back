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
        [HttpPut]
        public bool PutRequest([FromBody] RequestDTO Request)
        {
            return _IRequestBL.UpdateRequest(Request);
        }

        [HttpGet]
        [Route("[action]")]
        public List<RequestDTO> GetAllRequest()
        {
            return _IRequestBL.GetAllRequest();
        }

        [HttpGet]
        [Route("[action]/{babysiterId}")]
        public List<RequestDTO> GetClosedRequestsToBs(int babysiterId)
        {
            return _IRequestBL.GetClosedRequestsToBs(babysiterId);
        }

        [HttpGet]
        [Route("[action]/{momId}")]
        public List<RequestDTO> getAllRequestsOfMom(int momId)
        {
            return _IRequestBL.getAllRequestsOfMom(momId);
        }

    }
}
