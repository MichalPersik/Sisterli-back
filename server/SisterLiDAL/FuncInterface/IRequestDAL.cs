using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisterLiDAL.Models;

namespace SisterLiDAL.FuncInterface
{
    public interface IRequestDAL
    {
        List<Request> GetAllRequests();
        bool CreateRequest(Request myRequest);
        bool UpdateRequest(Request myRequest);
        Request getRequestById(int id);
        List<Request> GetClosedRequestsToBs(int babysiterId);
        List<Request> getAllRequestsOfMom(int momId);
        List<StatusRequest> getAllStatus();

    }
}
