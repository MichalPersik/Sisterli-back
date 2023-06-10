using System;
using System.Collections.Generic;

namespace SisterLiDAL.Models;

public partial class StatusRequest
{
    public int Id { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
