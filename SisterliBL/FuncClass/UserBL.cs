using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisterLiDAL.Models;
using SisterliDTO.Model;
using SisterLiDAL;
using AutoMapper;
using SisterliBL.FuncClass;
using SisterliBL.FuncInterface;

namespace SisterliBL
{
    public class UserBL : IUserBL
    {
        private IUserDAL userDAL;
        private IMomBL momBL;
        private IBabysiterBL bsBL;
        private IMapper mapper;

        public UserBL(IUserDAL _userDAL, IMomBL _momBL, IBabysiterBL _bsBL, IMapper _mapper)
        {
            userDAL = _userDAL;
            mapper = _mapper;
            momBL = _momBL;
            bsBL = _bsBL;
        }
        // בדיקה
        // public UserDTO getUserByIdAndPassword(string id)
        //{
        //    User u = userDAL.getUserByIdAndPassword(id, password);
        //    UserDTO user = mapper.Map<UserDTO>(u);

        //    //check if this user is MOM type
        //    MomDTO mom = momBL.getMomById(id);
        //    if (mom != null)
        //    {
        //        mom = mapper.Map(user, mom); 
        //            return mom; 
        //    }
        //    else
        //    {
        //        BabysiterDTO bs = bsBL.getBabysitterById(id);
        //        bs = mapper.Map(user, bs);

        //        return bs;
        //    }
        //   // return null;
        //}

        // קבלת כל המשתמשים 
        public List<UserDTO> GetAllUsers()
        {
            List<User> uAll = userDAL.GetAllUsers();
            List<UserDTO> u = new List<UserDTO>();
            for (int i = 0; i < uAll.Count; i++)
            {
                u.Add(mapper.Map<User, UserDTO>(uAll[i]));
            }
            return u;

        }


        //  קבלת ת"ז וסיסמה והחזרת פרטים של משתמש
        public UserDTO getUserByIdAndPassword(string id, string password)
        {
            User u = userDAL.getUserByIdAndPassword(id, password);
            UserDTO user = mapper.Map<UserDTO>(u);


            //check if this user is mom type
            //momdto mom = mombl.getmombyid(id);
            //if (mom != null)
            //{
            //    mom = mapper.map(user, mom);
            //    return mom;
            //}
            //else
            //{
            //    babysiterdto bs = bsbl.getbabysitterbyid(id);
            //    bs = mapper.map(user, bs);

            //    return bs;
            //}
            return null;
        }

        //public void MapIfDestinationIsNull<T>()
        //{
        //    Mapper.CreateMap<T,T>().ForAllMembers(opt => opt.Condition(dest => dest.DestinationValue == null));
        //}

        //sql יצירת משתמש חדש ושמירה ב
        public void CreateUser(UserDTO user)
        {
            //create basic user (id, firstName... )
            User u = mapper.Map<User>(user);
            userDAL.CreateUser(u);

            //check what null? create mom / babysitter
            //if (user.bs == null)
            //{
            //    Mom newMom = mapper.Map<Mom>(user.mom);
            //    newMom.IdUser = u.Id;
            //    momBL.CreateMom(newMom);

            //}
        }

        //sql עדכון משתמש
        public void UpdateUser(UserDTO userSisterli, string type)
        {
            //User u = mapper.Map<User>(userSisterli);
            //userDAL.UpdateUser(u);
            //if (type == "mom")
            //    userDAL.UpdateMom(u);
            //else
            //    userDAL.UpdateBabysiter(u);


        }

        // מחיקת משתמש מ- SQL
        public void deleteUser(UserDTO userSisterli)
        {
            User u = mapper.Map<User>(userSisterli);
            userDAL.deleteUser(u);
        }

        public void UpdateUser(UserDTO userSisterli)
        {
            throw new NotImplementedException();
        }
    }
}
