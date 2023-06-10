using System.Linq;
using Microsoft.EntityFrameworkCore;
using SisterLiDAL.Models;

namespace SisterLiDAL
{
    public class UserDAL : IUserDAL
    {

        //SisterliContext _Sisterli;
        User myUser = new User(); // אוביקט מסוג משתמש גלובלי לכל השיכבה
        public List<AgeChild> GetAllAgeChild()
        {
            try
            {
                using (var db = new SisterliContext())
                {
                    List<AgeChild> lac= db.AgeChildren.ToList();
                    return lac;
                }
            }
            catch
            {
                Console.WriteLine("User not captured or already exists");
                return null;
            }
        }

        public List<HoursAvailble> GetAllhoursAvailble()
        {
            try
            {
                using (var db = new SisterliContext())
                {
                    List<HoursAvailble> ha = db.HoursAvailbles.ToList();
                    return ha;
                }
            }
            catch
            {
                Console.WriteLine("User not captured or already exists");
                return null;
            }
        }



        //  קבלת ת"ז וסיסמה והחזרת פרטים של משתמש
        public User getUserByIdAndPassword(string id, string password)
        {
            //bool flag = true;
           
            //try
            //{
            //    if (id.Length == 9)
            //    {
            //        using (var db = new SisterliContext())
            //        {
            //            Mom m = db.Moms.Where(x => x.IdUser == id).SingleOrDefault();
            //            if (m != null)
            //            {
            //                myUser = db.Users.Where(x => x.Id == id && x.Password == password).SingleOrDefault();
            //               // returen m + myUser
            //            }
            //            else
            //              //  Babysiter b = db.Babysiters.Where(x => x.IdUser == id).SingleOrDefault();
            //              Babysiter b=db.Babysiters.Where() 
            //        }
            //    }
            //}
            //catch
            //{
            //    Console.WriteLine("User does not exist or was not found");
            //}
            return null;

        }

        //sql יצירת משתמש חדש ושמירה ב

        public void CreateUser(User userSisterli)
        {
            try
            {
                using (var db = new SisterliContext())
                {
                    db.Users.Add(userSisterli);
                    db.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("User not captured or already exists");
            }
        }

        // עדכון משתמש ושמירה ב sql 
        public void UpdateUser(User userSisterli)
        {
            try
            {
                using (var db = new SisterliContext())
                {
                    // myUser = db.Users.Where(x => x.Id == userSisterli.Id).SingleOrDefault();
                    db.Users.Update(userSisterli);
                    db.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("User not captured or already exists");
            }
        }

        // מחיקת משתמש מ- SQL
        public void deleteUser(User userSisterli)
        {
            try
            {
                using (var db = new SisterliContext())
                {
                    db.Users.Remove(userSisterli);
                    db.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("User not removed");
            }

        }

        // קבלת כל המשתמשים 
        public List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();

            try
            {
                using (var db = new SisterliContext())
                {
                    allUsers = db.Users.ToList<User>();
                    //db.SaveChanges();
                   // return allUsers;
                }
            }
            catch
            {
                Console.WriteLine("Unable to get the list of users");
            }
            return allUsers ;
        }


    }
}
