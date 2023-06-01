using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using SisterliBL.FuncInterface;
using SisterLiDAL;
using SisterLiDAL.FuncClass;
using SisterLiDAL.FuncInterface;
using SisterLiDAL.Models;
using SisterliDTO.Model;
using Request = SisterLiDAL.Models.Request;

namespace SisterliBL.FuncClass
{
    public class RequestBL : IRequestBL
    {
        private IRequestDAL requestDAL;
        private IMapper mapper;
        public RequestBL(IRequestDAL _RequestDAL, IMapper _mapper)
        {
            requestDAL = _RequestDAL;
            mapper = _mapper;
        }
        public bool CreateRequest(RequestDTO request)
        {
            Request myRequest = mapper.Map<Request>(request);
            return requestDAL.CreateRequest(myRequest);
        }

        //public bool DeleteRequest(RequestDTO Request)
        //{
        //    Request myRequest = mapper.Map<Request>(Request);
        //    return requestDAL.DeleteRequest(myRequest);
        //}

        public RequestDTO getRequestById(int id)
        {
            Request myRequest = requestDAL.getRequestById(id);
            return mapper.Map<Request, RequestDTO>(myRequest);
        }

        public bool UpdateRequest(RequestDTO Request)
        {
            Request myRequest = mapper.Map<Request>(Request);
            return requestDAL.UpdateRequest(myRequest);
        }

        public List<RequestDTO> GetAllRequest()
        {
            List<Request> AllRequest = requestDAL.GetAllRequests();
            List<RequestDTO> r = new List<RequestDTO>();
            for (int i = 0; i < AllRequest.Count; i++)
            {
                r.Add(mapper.Map<Request, RequestDTO>(AllRequest[i]));
            }
            return r;
        }
    }
}
