using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SisterLiDAL.Models;
using SisterliDTO.Model;

namespace SisterliBL.FuncClass
{
    public class FullUser : UserDTO
    {
        public MomDTO mom { get; set; }
        [AllowNull]
        [JsonProperty(Required = Required.AllowNull)]
        public Babysiter bs { get; set;}
        
    }
}
