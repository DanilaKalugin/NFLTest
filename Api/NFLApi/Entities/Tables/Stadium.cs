using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Tables
{
    public class Stadium
    {
        public byte StadiumId { get; set; }
        public string StadiumTitle { get; set; }
        public City StadiumLocation { get; set; }
        [JsonIgnore]
        public short StadiumLocationId { get; set; }
        [JsonIgnore]
        public virtual List<Team> Teams { get; set; } = new();
    }
}
