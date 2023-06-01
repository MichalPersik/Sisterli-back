using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisterLiDAL.Models;

namespace SisterLiDAL
{
    public interface IUserDAL
    {
        List <User> GetAllUsers();
        User getUserByIdAndPassword(string id, string password);
        void CreateUser(User userSisterli);
        void UpdateUser(User userSisterli);
        void deleteUser(User userSisterli);


    }
}
