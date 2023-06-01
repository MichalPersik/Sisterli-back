using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SisterliBL;
using SisterliBL.FuncClass;
using SisterLiDAL;
using SisterLiDAL.Models;
using SisterliDTO.Model;

namespace SisterliAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserBL _userBL;
        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        [HttpGet]
        [Route("[action]")]
        public UserDTO getUserDetailsByIdAndPassword(string id, string password)
        {
             return _userBL.getUserByIdAndPassword(id, password);
        }

        [HttpGet]
        [Route("[action]")]
        public List<UserDTO> GetAllUsers()
        {
            return _userBL.GetAllUsers();
        }


        [HttpPost]
        [Route("[action]")]
        //sql יצירת משתמש חדש ושמירה ב
          public void CreateUser(UserDTO  user)
       // public void CreateUser(UserDTO user,Object obj)

        {
            _userBL.CreateUser(user);
        }

        [HttpPut]
        [Route("[action]")]
        public void UpdateUser(UserDTO userSisterli)
        {
            _userBL.UpdateUser(userSisterli);
        }

        [HttpDelete]
        [Route("[action]")]
        public void deleteUser(UserDTO userSisterli)
        {
            _userBL.deleteUser(userSisterli);
        }

    }
}
