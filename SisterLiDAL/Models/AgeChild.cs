using System;
using System.Collections.Generic;

namespace SisterLiDAL.Models;

public partial class AgeChild
{
    public int Id { get; set; }

    public string? Age { get; set; }

    public virtual ICollection<Babysiter> Babysiters { get; } = new List<Babysiter>();

    public virtual ICollection<Mom> Moms { get; } = new List<Mom>();

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
