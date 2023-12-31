﻿namespace Disc.Domain.Entities
{
    public class ArtistMusicLabel
    {
        public uint ArtistId { get; set; }
        public uint MusicLabelId { get; set; }
        public Artist? Artist { get; set; } 
        public MusicLabel? MusicLabel { get; set; }
    }
}
