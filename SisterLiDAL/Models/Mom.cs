using System;
using System.Collections.Generic;

namespace SisterLiDAL.Models;

public partial class Mom
{
    public int Id { get; set; }

    public string? IdUser { get; set; }

    public bool IsWifi { get; set; }

    public int HourlySalary { get; set; }

    public bool? IsSleep { get; set; }

    public int? IdAgeChildren { get; set; }

    public int? NumChildren { get; set; }

    public string? Comment { get; set; }

    public virtual AgeChild? IdAgeChildrenNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
