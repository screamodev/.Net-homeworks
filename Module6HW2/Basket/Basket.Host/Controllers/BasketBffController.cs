using System.Net;
using Basket.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class BasketBffController : ControllerBase
{
    private readonly IBasketService _basketService;

    public BasketBffController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    public string GetAll()
    {
        _basketService.GetAllAsync();
        return "test";
    }

    [HttpGet]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public IActionResult GetOne()
    {
        var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        _basketService.GetOneAsync(basketId!);
        return Ok(basketId);
    }
}