using System;
using System.Collections.Generic;


namespace SisterliDTO.Model
{
    public partial class BabysiterDTO
    {
        public int Id { get; set; }

        public string IdUser { get; set; } = null!;

        public int Age { get; set; }

        public string? School { get; set; }

        public int? AgesChildrenId { get; set; }

        public int? HoursAvailble { get; set; }

        public int? HourlySalary { get; set; }

        public string? Opinion { get; set; }

        //public virtual AgeChildDTO? AgesChildren { get; set; }

        //public virtual HoursAvailble? HoursAvailbleNavigation { get; set; }

        public virtual UserDTO IdUserNavigation { get; set; } = null!;

    }
}