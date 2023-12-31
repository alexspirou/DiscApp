﻿namespace Disc.Domain.Entities
{
    public class ArtistLink
    {
        public uint ArtistId { get; set; }
        public uint LinkId { get; set; }
        public Artist? Artist { get; set; } 
        public Link? Link { get; set; }
    }
}
