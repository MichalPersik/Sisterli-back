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
    public class MomBL : IMomBL
    {
        private IMomDAL momDAL;
        private IMapper mapper;
        public MomBL(IMomDAL _momDAL, IMapper _mapper)
        {
            momDAL = _momDAL;
            mapper = _mapper;
        }
        public bool CreateMom(MomDTO mom)
        {
            mom.IdAgeChildrenNavigation = null;
            Mom myMom = mapper.Map<Mom>(mom);
            return momDAL.CreateMom(myMom);
        }

        public MomDTO getMomById(string id, string password)
        {
            Mom mom = momDAL.getMomById(id,password);
            return mapper.Map<Mom, MomDTO>(mom);
        }

        public bool UpdateMom(MomDTO mom)
        {
            mom.IdAgeChildrenNavigation = null;
            Mom myMom = mapper.Map<Mom>(mom);
            return momDAL.UpdateMom(myMom);
        }

   
    }
}
