using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SisterLiDAL.Models;

namespace SisterliDTO.Model
{
    public class RequestDTO
    {
        public int Id { get; set; }
        //[JsonIgnore]
        public int? IdBs { get; set; }
    
        public int? IdMom { get; set; }
        public DateTime CreatedTime { get; set; }

        public DateTime Day { get; set; }

        public TimeSpan BeginningTime { get; set; }

        public TimeSpan EndTime { get; set; }
    
        public int Status { get; set; }

        public bool? IsSleep { get; set; }
    
        public int? IdAgeChildren { get; set; }
    
        public int? NumChildren { get; set; }
 
        public string? Comment { get; set; }
  
        public bool? IsWifi { get; set; }
     
        public int? HourlySalary { get; set; }
        public string City { get; set; }
        public string LastName { get; set; }
        // [JsonIgnore]

        // public virtual AgeChild? IdAgeChildrenNavigation { get; set; }
        // [JsonIgnore]

        //public virtual Babysiter? IdBsNavigation { get; set; }
        // [JsonIgnore]


        public virtual MomDTO IdMomNavigation { get; set; }
        // [JsonIgnore]


        // public virtual StatusRequest StatusNavigation { get; set; }
    }
}
