using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class Repository<TEntity, TCreateDto, TUpdateDto>
    : IRepository<TEntity, TCreateDto, TUpdateDto>
    where TEntity : class, new()
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public Repository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper, IMapper mapper)
    {
        _dbContext = dbContextWrapper.DbContext;
        _mapper = mapper;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity?> AddAsync(TCreateDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);

        var item = await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return item.Entity;
    }

    public async Task<TEntity?> UpdateAsync(int id, TUpdateDto dto)
    {
        var item = await GetByIdAsync(id);
        if (item == null)
        {
            return null;
        }

        _mapper.Map(dto, item);

        await _dbContext.SaveChangesAsync();
        return item;
    }

    public async Task<bool?> DeleteAsync(int id)
    {
        var item = await GetByIdAsync(id);
        if (item == null)
        {
            return null;
        }

        _dbContext.Set<TEntity>().Remove(item);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
