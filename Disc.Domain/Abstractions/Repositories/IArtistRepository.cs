﻿using Disc.Domain.Entities;
using System.Collections;

namespace Disc.Domain.Abstractions.Repositories
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        Task<Artist?> CreateArtistAsync(Artist newArtist);
        Task<string?> GetNameByArtistIdAsync(uint id);
        Task<string?> GetRealNameByArtistIdAsync(uint id);
        Task<IEnumerable<Link?>> GetLinksByArtistIDAsync(uint id);
        Task<IEnumerable<MusicLabel?>> GetMusicLabelByArtistIDAsync(uint id);
        Task<IEnumerable<Release?>> GetReleaseByArtistIDAsync(uint id);
        Task<Artist?> GetArtistByNameAsync(string name);
        Task<IEnumerable> GetAllArtistsAsync();

    }
}

