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
        //   bool DeleteRequest(RequestDTO Request);
    }
}
