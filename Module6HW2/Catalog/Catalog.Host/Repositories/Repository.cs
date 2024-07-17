// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Catalog.Host.Data;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Logging;
//
// public class Repository<TEntity, TDtoCreate, TDtoUpdate> : IRepository<TEntity, TDtoCreate, TDtoUpdate>
//     where TEntity : class, new()
// {
//     private readonly ApplicationDbContext _dbContext;
//
//     public Repository(ApplicationDbContext dbContext)
//     {
//         _dbContext = dbContext;
//     }
//
//     public async Task<List<TEntity>> GetAllAsync()
//     {
//         return await _dbContext.Set<TEntity>().ToListAsync();
//     }
//
//     public async Task<TEntity?> GetByIdAsync(int id)
//     {
//         return await _dbContext.Set<TEntity>().FindAsync(id);
//     }
//
//     public async Task<TEntity> AddAsync(TDtoCreate dtoCreate)
//     {
//         var entity = new TEntity();
//
//         var addedEntity = await _dbContext.Set<TEntity>().AddAsync(entity);
//         await _dbContext.SaveChangesAsync();
//         return addedEntity.Entity;
//     }
//
//     public async Task<TEntity?> UpdateAsync(int id, TDtoUpdate dtoUpdate)
//     {
//         var entity = await GetByIdAsync(id);
//         if (entity == null)
//         {
//             return null;
//         }
//         await _dbContext.SaveChangesAsync();
//         return entity;
//     }
//
//     public async Task<bool?> DeleteAsync(int id)
//     {
//         var entity = await GetByIdAsync(id);
//         if (entity == null)
//         {
//             return null;
//         }
//         _dbContext.Set<TEntity>().Remove(entity);
//         await _dbContext.SaveChangesAsync();
//         return true;
//     }
// }