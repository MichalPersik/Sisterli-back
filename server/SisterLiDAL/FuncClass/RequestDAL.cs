using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SisterLiDAL.FuncInterface;
using SisterLiDAL.Models;
using Microsoft.EntityFrameworkCore;


namespace SisterLiDAL.FuncClass
{
    public class RequestDAL : IRequestDAL
    {
        public bool CreateRequest(Request myRequest)
        {
            try
            {
                using (var db = new SisterliContext())
                {
                  //  myRequest.NumChildren = null;
                  //  myRequest.Status = 0;
                  //  myRequest.IdAgeChildren = null;

                    var user = db.Requests.Where
                        (u => u.Day == myRequest.Day &&
                        myRequest.BeginningTime.ToString() == u.BeginningTime.ToString() &&
                        myRequest.EndTime.ToString() == u.EndTime.ToString() &&
                        u.IdMom == myRequest.IdMom).FirstOrDefault();
                    if (user == null)
                    {
                        try
                        {
                            db.Requests.Add(myRequest);
                            db.SaveChanges();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("myRequest not captured or already exists");
                            return false;
                        }
                    }
                    else { return false; }
                }
            }
            catch
            {
                Console.WriteLine("myRequest not captured or already exists");
                return false;
            }

        }

        //public bool DeleteRequest(Request myRequest)
        //{
        //    try
        //    {
        //        using (var db = new SisterliContext())
        //        {
        //            try
        //            {
        //                db.Requests.Remove(myRequest);
        //                db.SaveChanges();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine("myRequest not captured or already exists");
        //                return false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("myRequest not captured or already exists");
        //        return false;
        //    }
        //    return false;
        //}


        public List<Request> GetAllRequests()
        {
            List<Request> allRequest = new List<Request>();

            try
            {
                using (var db = new SisterliContext())
                {
                    allRequest = db.Requests.Include(r=>r.IdMomNavigation).Include(m=>m.IdMomNavigation.IdUserNavigation).ToList<Request>();
                    //db.SaveChanges();
                    // return allUsers;
                }
            }
            catch
            {
                Console.WriteLine("Unable to get the list of Request");
            }
            return allRequest;
        }




        public Request getRequestById(int id)
        {
            try
            {
                using (var db = new SisterliContext())
                {

                    //  var myRequest = db.Requests.Include(y=>y.IdMom).FirstOrDefault(x => x.Id==id);
                    var myRequest = db.Requests.Include(y => y.IdAgeChildrenNavigation)
                                               .Include(y => y.IdBsNavigation)
                                               .Include(y => y.IdMomNavigation)//.Select(i => i.Id);
                                                                               // .Include(y => y.StatusNavigation)

                    .FirstOrDefault(x => x.Id == id);
                    ////////  myRequest.FirstOrDefault(x => (x as Request).Id == id);
                    if (myRequest != null)
                        return myRequest;//// myRequest;
                    return null;
                    //return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("myRequest does not exist or was not found");
                return null;
            }
        }

        public bool UpdateRequest(Request myRequest)
        {
            try
            {
                using (var db = new SisterliContext())
                {
                    var request = db.Requests.Where(u => u.Id == myRequest.Id).AsNoTracking().FirstOrDefault();
                    //  var mom = db.Moms.Where()
                   if (request != null)
                    {
                        try
                        {
                            db.Requests.Update(myRequest);


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