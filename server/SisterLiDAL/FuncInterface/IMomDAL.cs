using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisterLiDAL.Models;

namespace SisterLiDAL
{
    public interface IMomDAL
    {
        bool CreateMom(Mom myMom);
        bool UpdateMom(Mom myMom);
        Mom getMomById(string id, string password);
        

    }
}
