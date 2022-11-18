using anonymous_message.Domain.Entities;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;

namespace anonymous_message.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = default!;
    public List<RefreshTokenModel> RefreshTokens { get; set; } = new List<RefreshTokenModel>();
}
