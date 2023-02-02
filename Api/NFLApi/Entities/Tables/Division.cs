using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Tables
{
    public class Division
    {
        public byte Number { get; set; }
        public string DivisionTitle { get; set; }
        [JsonIgnore]
        public virtual List<Team> Teams { get; set; } = new();
        [JsonIgnore]
        public Conference Conference { get; set; }
        public byte? ConferenceId { get; set; }
    }
}
