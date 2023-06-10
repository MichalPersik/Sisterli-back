using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisterliBL.FuncClass;
using SisterLiDAL.Models;
using SisterliDTO.Model;

namespace SisterliBL.FuncInterface
{
    public interface IMomBL
    {
        MomDTO getMomById(string id, string password);
        bool CreateMom(MomDTO mom);
        bool UpdateMom(MomDTO mom);

    }
}
