using System;
using System.Collections.Generic;

namespace SisterLiDAL.Models;

public partial class Babysiter
{
    public int Id { get; set; }

    public string IdUser { get; set; } = null!;

    public int Age { get; set; }

    public string? School { get; set; }

    public int? AgesChildrenId { get; set; }

    public int? HoursAvailble { get; set; }

    public int? HourlySalary { get; set; }

    public string? Opinion { get; set; }

    public virtual AgeChild? AgesChildren { get; set; }

    public virtual HoursAvailble? HoursAvailbleNavigation { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
