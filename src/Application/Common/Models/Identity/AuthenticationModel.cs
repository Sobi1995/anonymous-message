using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace anonymous_message.Application.Common.Models.Identity;
public class AuthenticationModel
{
    public string Message { get; set; } = default!;
    public bool IsAuthenticated { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public List<string> Roles { get; set; } = new List<string>();
    public string Token { get; set; } = default!;
    [JsonIgnore]
    public string RefreshToken { get; set; } = default!;
    public DateTime RefreshTokenExpiration { get; set; }
}
