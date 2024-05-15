using System;
using System.Threading.Tasks;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ALevelSample;

public class App
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly IResourceService _resourceService;
    private readonly ILogger<App> _logger;

    public App(IAuthService authService, IUserService userService, IResourceService resourceService, ILogger<App> logger)
    {
        _authService = authService;
        _userService = userService;
        _resourceService = resourceService;
        _logger = logger;
    }

    public async Task Start()
    {
        var foundedUsers = await _userService.GetUsers(1);
        var foundedUser = await _userService.GetUserById(2);
        var userNotFound = await _userService.GetUserById(23);
        var createdUser = await _userService.CreateUser("morpheus", "leader");
        var updatedUserPut = await _userService.UpdateUser(2, "morpheus", "zion resident");
        var updatedUserPatch = await _userService.UpdateUserPatch(2, "morpheus", "zion resident");
        var isUserDeleted = await _userService.DeleteUser(1);

        var resources = await _resourceService.GetResources();
        var foundedResource = await _resourceService.GetResourceById(2);
        var resourceNotFounded = await _resourceService.GetResourceById(23);

        var register = await _authService.Register("eve.holt@reqres.in", "pistol");
        var failedRegister = await _authService.Register("sydney@fife");

        var login = await _authService.Login("eve.holt@reqres.in", "cityslicka");
        var failedLogin = await _authService.Login("peter@klaven");

        _logger.LogInformation($"First page of users: {JsonConvert.SerializeObject(foundedUsers)}");
        _logger.LogInformation($"Founded user: {JsonConvert.SerializeObject(foundedUser)}");
        _logger.LogInformation($"User not found: {JsonConvert.SerializeObject(userNotFound)}");
        _logger.LogInformation($"Created user: {JsonConvert.SerializeObject(createdUser)}");
        _logger.LogInformation($"Updated user: {JsonConvert.SerializeObject(updatedUserPut)}");
        _logger.LogInformation($"Updated user: {JsonConvert.SerializeObject(updatedUserPatch)}");
        _logger.LogInformation($"Is user deleted?: {JsonConvert.SerializeObject(isUserDeleted)}");

        _logger.LogInformation($"All resources: {JsonConvert.SerializeObject(resources)}");
        _logger.LogInformation($"Founded resource: {JsonConvert.SerializeObject(foundedResource)}");
        _logger.LogInformation($"Resource not found: {JsonConvert.SerializeObject(resourceNotFounded)}");

        _logger.LogInformation($"Registration response: {JsonConvert.SerializeObject(register)}");

        _logger.LogInformation($"Registration response: {JsonConvert.SerializeObject(login)}");
    }
}