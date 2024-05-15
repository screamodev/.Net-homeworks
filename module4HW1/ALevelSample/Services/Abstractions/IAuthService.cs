using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Dtos;
using ALevelSample.Dtos.Responses;

namespace ALevelSample.Services.Abstractions;

public interface IAuthService
{
    Task<AuthResponse> Register(string email, string password = null);
    Task<AuthResponse> Login(string email, string password = null);
}