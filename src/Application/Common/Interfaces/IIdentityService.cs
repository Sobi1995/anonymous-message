using anonymous_message.Application.Common.Models;
using anonymous_message.Application.Common.Models.Identity;
using anonymous_message.Application.Common.Models.User;

namespace anonymous_message.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userId);


    Task<string> RegisterAsync(RegisterModel model);
    Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model);
    Task<string> AddRoleAsync(AddRoleModel model);

    Task<AuthenticationModel> RefreshTokenAsync(string jwtToken);

    bool RevokeToken(string token);

    //TODO
    object GetById(string id);
}
