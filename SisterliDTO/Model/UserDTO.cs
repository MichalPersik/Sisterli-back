using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisterLiDAL.Models;

namespace SisterliDTO.Model
{
    public class UserDTO
    {
        public string Id { get; set; } = null!;

        public string? LastName { get; set; }

        public string? FristName { get; set; }

        public string? Tel { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public string? GeneryInfo { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        //public virtual ICollection<Babysiter> Babysiters { get; } = new List<Babysiter>();

        //public virtual ICollection<Mom> Moms { get; } = new List<Mom>();
    }
}
