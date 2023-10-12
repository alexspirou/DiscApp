using Disc.Domain.Abstractions.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Disc.Infrastructure.Database.Repositories;

public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
{

    private DbSet<T> _entities;
    private bool _isDisposed;

    public DiscAppContext Context { get; set; }

    public GenericRepository(DiscAppContext discAppDbContext)
    {
        Context = discAppDbContext;
    }

    public GenericRepository()
    {

    }

    protected virtual DbSet<T> Entities
    {
        get { return _entities ?? (_entities = Context.Set<T>() ); }
    }

    public void Dispose()
    {
        if (Context is not null)
        {
            Context.Dispose();
        }
        _isDisposed = true;
    }
    public async Task DisposeAsync()
    {
        if (Context is not null)
        {
            await Context.DisposeAsync();
        }
        _isDisposed = true;
    }


    public IEnumerable<T> GetAll()
    {
        return GetAllAsync().Result;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Entities.ToListAsync();
    }


    public async Task<T> GetByIdAsync(uint id)
    {
        try
        {
            T entry = await Entities.FindAsync(id);
            if (entry is null)
            {
                throw new NullReferenceException($"{typeof(T)} is null.");
            }
            return entry;
        }
        catch (Exception ex)
        {
            throw new Exception($"{typeof(T)} exception is thrown.", ex);
        }

    }

    public void Insert(T entity)
    {
        try
        {
            Entities.Add(entity);
            Save();
        }
        catch (Exception ex)
        {
            throw new Exception($"Cannot insert the {typeof(T).Name} entity", ex);
        }
    }

    public async Task InsertAsync(T entity)
    {
        try
        {
            Entities.Add(entity);
            await SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Cannot insert the {typeof(T).Name} entity", ex);
        }
    }

    public void Update(T entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException("Entity");
        }

        Context.Entry(entity).State = EntityState.Modified;
        Save();
    }
    public async Task UpdateAsync(T entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException("Entity");
        }


        Context.Entry(entity).State = EntityState.Modified;
        await SaveAsync();
    }

    public virtual void Delete(T entity)
    {
        try
        {
            if (entity is null)
            {
                throw new ArgumentNullException("Entity");
            }

            Entities.Remove(entity);
            Save();
        }
        catch (Exception ex)
        {
            throw new Exception($"Cannot delete the {typeof(T).Name} entity", ex);
        }

    }
    public virtual async Task DeleteAsync(T entity)
    {
        try
        {
            if (entity is null)
            {
                throw new ArgumentNullException("Entity");
            }

            Entities.Remove(entity);
            await SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Cannot delete the {typeof(T).Name} entity", ex);
        }

    }

    public void Save()
    {
        try
        {
            Context.SaveChanges();
        }
        catch (Exception ex)
        {

            throw new Exception($"Cannot save the {typeof(T).Name} entity", ex);

        }
    }

    public async Task SaveAsync()
    {
        try
        {
            await Context.SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Cannot save the {typeof(T).Name} entity", ex);

        }
    }
}
