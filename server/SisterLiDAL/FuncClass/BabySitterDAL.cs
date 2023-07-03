
using Microsoft.EntityFrameworkCore;
using SisterLiDAL.Models;

namespace SisterLiDAL
{
    public class BabySitterDAL : IBabySitterDAL
    {
        public BabySitterDAL()
        {
            Console.WriteLine("");
        }

        public List<Babysiter> GetAllBabySiters()
        {
            List<Babysiter> allBabysiters = new List<Babysiter>();

            try
            {
                using (var db = new SisterliContext())
                {
                    allBabysiters = db.Babysiters.Include(b=>b.IdUserNavigation).ToList<Babysiter>();
                    //db.SaveChanges();
                    // return allUsers;
                }
            }
            catch
            {
                Console.WriteLine("Unable to get the list of users");
            }
            return allBabysiters;
        }

        public List<Babysiter> GetBabysitersByMom(int momId) 
        {
            using (var db = new SisterliContext())
            {
                return db.Requests.Where(r => r.IdMom == momId && r.IdBs!=null).Include(r => r.IdBsNavigation.IdUserNavigation).Select(r => r.IdBsNavigation).Distinct().ToList();
            }
        }

        public bool CreateBabySitter(Babysiter myBabySiter)
        {
            try
            {
                using (var db = new SisterliContext())
                {
                    try
                    {
                        db.Babysiters.Add(myBabySiter);
                        db.SaveChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("myBabySiter not captured or already exists");
                        return false;
                    }
                }
            }
            catch
            {
                Console.WriteLine("myBabySiter not captured or already exists");
                return false;
            }
            return false;

        }

        public List<string> GetRecomendsByUserId(string idNum) 
        {
            using (var db = new SisterliContext())
            {
                return db.Babysiters.Where(u => u.IdUser == idNum).Select(u=>u.Opinion).ToList();
            }
        }


        public Babysiter getBabysiterById(string idUser, string password)
        {
            try
            {
                User user;
                using (var db = new SisterliContext())
                {
                    user = db.Users.Where(u => u.Id == idUser && u.Password == password).FirstOrDefault();

                }
                if (user != null)
                {
                    using (var db = new SisterliContext())
                    {
                        var myBabySitter = db.Babysiters.Include(y => y.IdUserNavigation).FirstOrDefault(x => x.IdUser == idUser);
                        return myBabySitter;
                    }
                }
                else
                    return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine("myBabySitter does not exist or was not found");
                return null;
            }
        }

        public bool UpdateBabySitter(Babysiter myBabySitter)
        {
            try
            {
                using (var db = new SisterliContext())
                {
                    var bs = db.Babysiters.Where(x => x.Id == myBabySitter.Id).AsNoTracking().FirstOrDefault();
                    if (bs != null)
                    {
                        try
                        {
                            db.Babysiters.Update(myBabySitter);
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
    }
}
