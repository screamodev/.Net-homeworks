using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Dtos;
using ALevelSample.Dtos.Responses;

namespace ALevelSample.Services.Abstractions;

public interface IUserService
{
    Task<UserDto> GetUserById(int id);
    Task<UserResponse> CreateUser(string name, string job);
    Task<List<UserDto>> GetUsers(int page);
    Task<UserResponse> UpdateUser(int id, string name = null, string job = null);
    Task<UserResponse> UpdateUserPatch(int id, string name = null, string job = null);
    Task<bool> DeleteUser(int id);
}