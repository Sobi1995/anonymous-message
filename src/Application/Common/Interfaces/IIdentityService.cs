using anonymous_message.Application.Account.Commands;
using anonymous_message.Application.Common.Models;
using anonymous_message.Application.Responses;

namespace anonymous_message.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string> GetUserNameAsync(Guid userId);

    Task<bool> IsInRoleAsync(Guid userId, string role);

    Task<bool> AuthorizeAsync(Guid userId, string policyName);

    Task<(Result Result, Guid UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(Guid userId);

    Task<AuthenticationResponse> LoginAsync(LoginCommand user);
 


}
