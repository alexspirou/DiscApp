namespace Disc.Domain.Abstractions.Repositories
{
    public interface ILinkRepository
    {
        public Task<string?> GetUrlByIdAsync(uint id);
    }
}

