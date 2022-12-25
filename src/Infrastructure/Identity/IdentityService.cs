using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using anonymous_message.Application;
using anonymous_message.Application.Account.Commands;
using anonymous_message.Application.Common.Interfaces;
using anonymous_message.Application.Common.Models;
using anonymous_message.Application.Responses;
using CryptoHashVerify;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace anonymous_message.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;
    private readonly IIdentity _identity;
    private readonly JwtSettings _jwtSettings;
    public IdentityService(
        UserManager<ApplicationUser> userManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService,
        IIdentity identity,
        JwtSettings jwtSettings)
    {
        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
        _identity = identity;
        _jwtSettings = jwtSettings;
    }

    public async Task<string> GetUserNameAsync(Guid userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        return user.UserName;
    }

    public async Task<(Result Result, Guid UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = userName,
        };

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<bool> IsInRoleAsync(Guid userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(Guid userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(Guid  userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

            public async Task<AuthenticationResponse> LoginAsync(LoginCommand user)
        {
            var existingUser = await _userManager.FindByIdAsync(user.UserId);

            if (existingUser == null)
            {
                return new AuthenticationResponse
                {
                    Errors = new[] { "Username / password incorrect" }
                };
            }

            //if (CheckPasswordAsync(existingUser.Password, existingUser.Salt, user.Password))
            //{
            //    return new AuthenticationResponse
            //    {
            //        Errors = new[] { "Username / password incorrect" }
            //    };
            //}

            return await GenerateAuthenticationResponseForUserAsync(existingUser);
        }
        private bool CheckPasswordAsync(string hashPassword, string salt, string password)
        {
            return HashVerify.VerifyHashString(hashPassword, salt, password);
        }

        private Task<AuthenticationResponse> GenerateAuthenticationResponseForUserAsync(ApplicationUser user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>
            {
               //new Claim(ClaimTypes.Role, user.Role),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim("id", user.Id.ToString()),
               new Claim("userId", user.Id.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = "http://dev.chandu.com",
                Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = jwtHandler.CreateToken(tokenDescriptor);

            return Task.FromResult(new AuthenticationResponse
            {
                IsSuccess = true,
                Token = jwtHandler.WriteToken(token)
            });
        }

      
        
}
