using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisterLiDAL.Models;
using SisterliDTO.Model;

namespace SisterliBL.FuncInterface
{
    public interface IBabysiterBL
    {
        List<BabysiterDTO> GetAllBabysiters();
        BabysiterDTO getBabysitterById(string idUser,string password);
        bool CreateBabysitter(BabysiterDTO Babysiter);
        bool UpdateBabysitter(BabysiterDTO Babysiter);
        List<string> GetRecomendsByUserId(string idNum);
        List<BabysiterDTO> GetBabysitersByMom(int momId);

    }
}
