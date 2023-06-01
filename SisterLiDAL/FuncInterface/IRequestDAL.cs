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
      //  bool DeleteRequest(Request myRequest);
    }
}
