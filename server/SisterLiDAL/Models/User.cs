using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SisterLiDAL.Models;

public partial class User
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
    [JsonIgnore]

    public virtual ICollection<Babysiter> Babysiters { get; } = new List<Babysiter>();
    [JsonIgnore]
    public virtual ICollection<Mom> Moms { get; } = new List<Mom>();
}
