using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepository<TEntity, TDtoCreate, TDtoUpdate>
    where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task<TEntity> AddAsync(TDtoCreate dtoCreate);
    Task<TEntity?> UpdateAsync(int id, TDtoUpdate dtoUpdate);
    Task<bool?> DeleteAsync(int id);
}