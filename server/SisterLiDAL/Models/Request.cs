using System;
using System.Collections.Generic;

namespace SisterLiDAL.Models;

public partial class Request
{
    public int Id { get; set; }

    public int? IdBs { get; set; }

    public int? IdMom { get; set; }
    public DateTime CreatedTime { get; set; }

    public DateTime Day { get; set; }

    public TimeSpan? BeginningTime { get; set; }

    public TimeSpan? EndTime { get; set; }

    public int? Status { get; set; }

    public bool? IsSleep { get; set; }

    public int? IdAgeChildren { get; set; }

    public int? NumChildren { get; set; }

    public string? Comment { get; set; }
    public string? MomOpinion { get; set; }

    public bool? IsWifi { get; set; }

    public int? HourlySalary { get; set; }

    public virtual AgeChild? IdAgeChildrenNavigation { get; set; }

    public virtual Babysiter? IdBsNavigation { get; set; }

    public virtual Mom? IdMomNavigation { get; set; }

    public virtual StatusRequest? StatusNavigation { get; set; }
}
