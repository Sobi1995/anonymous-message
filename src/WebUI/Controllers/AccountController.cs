

using anonymous_message.Application.Account.Commands;
using anonymous_message.Application.Common.Security;
using anonymous_message.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Mvc;

namespace anonymous_message.WebUI.Controllers;

[Authorize]
public class AccountController : ApiControllerBase
{
    [HttpPost("createuser")]
   
    public async Task<IActionResult>
         CreateuserAsync([FromBody] CreateUserCommand createUser)
    {
        var result = await Mediator.Send(createUser);
        return result != null ? Created("", result) : (IActionResult)BadRequest(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult>
     LoginAsync([FromBody] LoginCommand login)
    {
        var result = await Mediator.Send(login);
        return result != null ? Created("", result) : (IActionResult)BadRequest(result);
    }


  
 
}
