using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisterliDTO.Model;

namespace SisterliBL.FuncInterface
{
    public interface IRequestBL
    {
        RequestDTO getRequestById(int id);
        bool CreateRequest(RequestDTO Request);
        bool UpdateRequest(RequestDTO Request);

        public List<RequestDTO> GetAllRequest();
        List<RequestDTO> GetClosedRequestsToBs(int babysiterId);
        List<RequestDTO> getAllRequestsOfMom(int momId);

    }
}
