﻿using System;
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
            List<RequestDTO> r = mapper.Map<List<Request>, List<RequestDTO>>(AllRequest);
            for (int i = 0; i < AllRequest.Count; i++)
            {
                r[i].LastName = AllRequest[i].IdMomNavigation?.IdUserNavigation?.LastName;
                r[i].City= AllRequest[i].IdMomNavigation?.IdUserNavigation?.City;
            }     
            return r;
        }
        public List<RequestDTO> GetClosedRequestsToBs(int babysiterId) {
            List<Request> AllRequest = requestDAL.GetClosedRequestsToBs(babysiterId);
            List<RequestDTO> r = mapper.Map<List<Request>, List<RequestDTO>>(AllRequest);
            for (int i = 0; i < AllRequest.Count; i++)
            {
                r[i].LastName = AllRequest[i].IdMomNavigation?.IdUserNavigation?.LastName;
                r[i].IdMomNavigation.Phone = AllRequest[i].IdMomNavigation?.IdUserNavigation?.Tel;
                r[i].City = AllRequest[i].IdMomNavigation?.IdUserNavigation?.City;
            }
            return r;
        }

        public List<RequestDTO> getAllRequestsOfMom(int momId)
        {
            List<Request> AllRequest = requestDAL.getAllRequestsOfMom(momId);
            List<RequestDTO> r = mapper.Map<List<Request>, List<RequestDTO>>(AllRequest);
            for (int i = 0; i < AllRequest.Count; i++)
            {
                r[i].LastName = AllRequest[i].IdMomNavigation?.IdUserNavigation?.LastName;
                r[i].City = AllRequest[i].IdMomNavigation?.IdUserNavigation?.City;
            }
            return r;
        }
        
        public List<StatusRequestDTO> getAllStatus()
        {
           var result = requestDAL.getAllStatus();
            List<StatusRequestDTO> res = mapper.Map<List<StatusRequest>, List<StatusRequestDTO>>(result);

            return res;
            
        }
    }
}
