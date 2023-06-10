using System;
using System.Collections.Generic;

namespace SisterLiDAL.Models;

public partial class HoursAvailble
{
    public int Id { get; set; }

    public string? Availble { get; set; }

    public virtual ICollection<Babysiter> Babysiters { get; } = new List<Babysiter>();
}
