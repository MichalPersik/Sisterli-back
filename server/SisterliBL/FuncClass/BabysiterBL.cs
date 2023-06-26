using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SisterliBL.FuncInterface;
using SisterLiDAL;
using SisterLiDAL.Models;
using SisterliDTO.Model;

namespace SisterliBL.FuncClass
{
    public class BabysiterBL : IBabysiterBL
    {
        private IBabySitterDAL babysiterDAL;
        private IMapper mapper;
        public BabysiterBL(IBabySitterDAL _babysiterDAL, IMapper _mapper)
        {
            babysiterDAL = _babysiterDAL;
            mapper = _mapper;
        }
        public bool CreateBabysitter(BabysiterDTO Babysiter)
        {
           // Babysiter.AgesChildren = null;
          //  Babysiter.HoursAvailble = null;
            Babysiter myBabysiter = mapper.Map<Babysiter>(Babysiter);
            return babysiterDAL.CreateBabySitter(myBabysiter);
        }

        public List<BabysiterDTO> GetAllBabysiters()
        {
            List<Babysiter> bAll = babysiterDAL.GetAllBabySiters();
            List<BabysiterDTO> b = mapper.Map<List<Babysiter>, List<BabysiterDTO>>(bAll);
            return b;
        }

        public BabysiterDTO getBabysitterById(string idUser, string password)
        {
            Babysiter Babysiter = babysiterDAL.getBabysiterById(idUser,password);
            return mapper.Map<Babysiter, BabysiterDTO>(Babysiter);
        }

        public bool UpdateBabysitter(BabysiterDTO myBabysiter)


        {
           /// myBabysiter.AgesChildren = null;לבדוק מה עם שורה זו
            Babysiter Babysiter = mapper.Map<Babysiter>(myBabysiter);
            return babysiterDAL.UpdateBabySitter(Babysiter);
        }

    }
}
