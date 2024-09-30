using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainifider
{
    public class PlugData
    {
#pragma warning disable
        public required string authors { get; init; }
        public required string id { get; init; }
        public required string name { get; init; }
        public required string version { get; init; }
        public string? description { get; init; }
        public string? target_game_version { get; init; }
        public string? youtube_trailer_id { get; init;}
        public Array? requirements { get; init;}
        public Array? requirements_names { get; init;}
        public Array? priorities { get; init; }
        public Array? tags { get; init; }
        public bool? checksum_override_version { get; init; }
        public PlugData()
        {
            this.description = "";
            this.target_game_version = "";
            this.youtube_trailer_id = "";
            this.requirements = Array.CreateInstance(typeof(string),0);
            this.requirements_names = Array.CreateInstance(typeof(string), 0);
            this.priorities = Array.CreateInstance(typeof(string), 0);
            this.tags = Array.CreateInstance(typeof(string), 0);
            this.checksum_override_version = false;
        }
    }
}
