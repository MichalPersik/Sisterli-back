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
                    var user = db.Requests.Where
                    (u => u.Day == myRequest.Day &&
                    myRequest.BeginningTime.ToString().Equals(u.BeginningTime.ToString()) &&
                    myRequest.EndTime.ToString().Equals(u.EndTime.ToString()) &&
                    u.IdMom == myRequest.IdMom).FirstOrDefault();
                    if (user == null)
                    {
                        try
                        {
                            myRequest.CreatedTime = DateTime.Now;
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
        public List<StatusRequest> getAllStatus()
        {
            using (var db = new SisterliContext())
            {
                var allstatus = db.StatusRequests.ToList();
                return allstatus;
            }

        }

        public List<Request> GetAllRequests()
        {
            List<Request> allRequest = new List<Request>();

            try
            {
                using (var db = new SisterliContext())
                {
                    allRequest = db.Requests.Include(r => r.IdMomNavigation).Include(m => m.IdMomNavigation.IdUserNavigation)
                        .ToList<Request>().FindAll(x => x.Status == 1 && !CheckTimeIsHover(x.Day));
                    //allRequest = db.Requests.Where(r => r.Status == 1 && !(r.Day < DateTime.Today))
                    //    .Select(r => new Request
                    //    {
                    //        Id = r.Id,
                    //        IdBs = r.IdBs,
                    //        IdMom = r.IdMom,
                    //        CreatedTime = r.CreatedTime,
                    //        Day = r.Day,
                    //        BeginningTime = r.BeginningTime,
                    //        EndTime = r.EndTime,
                    //        Status = r.Status,
                    //        IsSleep = r.IsSleep,
                    //        IdAgeChildren = r.IdAgeChildren,
                    //        NumChildren = r.NumChildren,
                    //        Comment = r.Comment,
                    //        IsWifi = r.IsWifi,
                    //        HourlySalary = r.HourlySalary,
                    //        IdAgeChildrenNavigation = r.IdAgeChildrenNavigation,
                    //        StatusNavigation = r.StatusNavigation
                    //    })
                    //    .ToList<Request>();
                    //.FindAll(r=>!CheckTimeIsHover(r.Day));
                    //db.SaveChanges();
                    // return allUsers;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to get the list of Request", ex.Message);
            }
            return allRequest;
        }

        public List<Request> GetClosedRequestsToBs(int babysiterId)
        {
            List<Request> allRequest = new List<Request>();

            try
            {
                using (var db = new SisterliContext())
                {
                    allRequest = db.Requests.Include(r => r.IdMomNavigation).Include(m => m.IdMomNavigation.IdUserNavigation)
                        .ToList<Request>().FindAll(x => x.IdBs == babysiterId && !CheckTimeIsHover(x.Day));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to get the list of Request", ex.Message);
            }
            return allRequest;
        }

        public List<Request> getAllRequestsOfMom(int momId)
        {
            List<Request> allRequest = new List<Request>();

            try
            {
                using (var db = new SisterliContext())
                {
                    allRequest = db.Requests.Include(r => r.IdMomNavigation).Include(m => m.IdMomNavigation.IdUserNavigation)
                        .ToList<Request>().FindAll(x => x.IdMom == momId && !CheckTimeIsHover(x.Day));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to get the list of Request", ex.Message);
            }
            return allRequest;
        }

        private bool CheckTimeIsHover(DateTime date)
        {
            var dateToDay = DateTime.Today;
            return date.Date < dateToDay;
        }



        //if (myRequest != null)
        //{
        //    var mom = myRequest.IdMomNavigation;
        //    var bs = myRequest.IdBsNavigation;
        //    //myRequest.IdBsNavigation.Requests = null;
        //    myRequest.IdMomNavigation = new Mom
        //    {
        //        Id = mom.Id,
        //        IdUser = mom.IdUser,
        //        IsWifi = mom.IsWifi,
        //        HourlySalary = mom.HourlySalary,
        //        IsSleep = mom.IsSleep,
        //        IdAgeChildren = mom.IdAgeChildren,
        //        NumChildren = mom.NumChildren,
        //        Comment = mom.Comment,
        //        IdAgeChildrenNavigation = mom.IdAgeChildrenNavigation,
        //        IdUserNavigation = new User
        //        {
        //            Id = mom.IdUserNavigation.Id,
        //            LastName = mom.IdUserNavigation.LastName,
        //            FristName = mom.IdUserNavigation.FristName,
        //            Tel = mom.IdUserNavigation.Tel,
        //            City = mom.IdUserNavigation.City,
        //            Street = mom.IdUserNavigation.Street,
        //            GeneryInfo = mom.IdUserNavigation.GeneryInfo,
        //            Email = mom.IdUserNavigation.Email,
        //            Password = mom.IdUserNavigation.Password
        //        }
        //    };
        //    myRequest.IdBsNavigation = new Babysiter
        //    {

        //    };
        //    return myRequest;
        //}
        //return null;

        public Request getRequestById(int id)
        {
            try
            {
                using (var db = new SisterliContext())
                {
                    var myRequest = db.Requests.Include(y => y.IdAgeChildrenNavigation)
                             .Include(y => y.IdBsNavigation)
                             .ThenInclude(y => y.IdUserNavigation)
                             .Include(y => y.IdMomNavigation)
                             .ThenInclude(y => y.IdUserNavigation)
                             .FirstOrDefault(x => x.Id == id);
                    return myRequest;
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