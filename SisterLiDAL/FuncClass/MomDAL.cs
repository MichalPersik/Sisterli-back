using System.Linq;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SisterLiDAL.Models;

namespace SisterLiDAL
{
    public class MomDAL : IMomDAL
    {
        public MomDAL()
        {

        }

        //sql יצירת משתמש חדש ושמירה ב
        public bool CreateMom(Mom myMom)
        {
            try
            {
                using (var db = new SisterliContext())
                {
                    var user = db.Users.Where(u => u.Id == myMom.IdUserNavigation.Id).FirstOrDefault();
                    if (user == null)
                    {
                        try
                        {
                            db.Moms.Add(myMom);
                            db.SaveChanges();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Mom not captured or already exists");
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Mom not captured or already exists");
                return false;
            }

        }

        public bool UpdateMom(Mom myMom)
        {
            try
            {
                using (var db = new SisterliContext())
                {
                    var mom = db.Moms.Where(x => x.Id == myMom.Id).AsNoTracking().FirstOrDefault();
                    if (mom != null)
                    {
                        try
                        {
                            db.Moms.Update(myMom);
                            db.SaveChanges();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            return false;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public Mom getMomById(string idUser, string password)
        {
            try
            {
                User user;
                using (var db = new SisterliContext())
                {
                    user = db.Users.FirstOrDefault(x => x.Id == idUser && x.Password == password);
                }
                if (user != null)
                {
                    using (var db = new SisterliContext())
                    {
                        var myMom = db.Moms.Include(y => y.IdUserNavigation).FirstOrDefault(x => x.IdUser == idUser);
                        return myMom;
                    }
                }
                else
                    return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Mom does not exist or was not found");
                return null;
            }
        }

    }
}