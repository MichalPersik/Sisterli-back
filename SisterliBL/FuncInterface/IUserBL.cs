using System;
using System.Collections.Generic;
using SisterliBL.FuncClass;
using SisterLiDAL.Models;
using SisterliDTO.Model;

namespace SisterliBL
{
    public interface IUserBL
    {


        public List<UserDTO> GetAllUsers();
        UserDTO getUserByIdAndPassword(string id, string password);
        void CreateUser(UserDTO userMom);
        void UpdateUser(UserDTO userSisterli);
        void deleteUser(UserDTO userSisterli);



    }
}
