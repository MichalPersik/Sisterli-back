using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SisterliDTO.Model
{
    public class MomDTO 
    {

        public int Id { get; set; }

        public string IdUser { get; set; } = null!;

        public bool IsWifi { get; set; }

        public int HourlySalary { get; set; }

        public bool? IsSleep { get; set; }

        public int? IdAgeChildren { get; set; }

        public int? NumChildren { get; set; }

        public string? Comment { get; set; }

        public virtual AgeChildDTO? IdAgeChildrenNavigation { get; set; }

        public virtual UserDTO IdUserNavigation { get; set; }

        //public virtual ICollection<RequestDTO> Requests { get; } = new List<RequestDTO>();
    }
}
