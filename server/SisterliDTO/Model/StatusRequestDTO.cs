using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisterliDTO.Model
{
    public class StatusRequestDTO
    {
        public int Id { get; set; }

        public string? Status { get; set; }

       // public virtual ICollection<Request> Requests { get; } = new List<Request>();
    }
}
