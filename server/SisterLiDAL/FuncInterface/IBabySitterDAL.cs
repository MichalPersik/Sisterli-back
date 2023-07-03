using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisterLiDAL.Models;

namespace SisterLiDAL
{
    public interface IBabySitterDAL
    {
        List<Babysiter> GetAllBabySiters();
        bool CreateBabySitter(Babysiter myBabySitter);
        bool UpdateBabySitter(Babysiter myBabySitter);

        Babysiter getBabysiterById(string idUser, string password);
        List<string> GetRecomendsByUserId(string idNum);
        List<Babysiter> GetBabysitersByMom(int momId);

    }
}
