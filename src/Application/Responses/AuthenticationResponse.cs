using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anonymous_message.Application.Responses;
public class AuthenticationResponse
{
    public bool IsSuccess { get; set; }
    public string Token { get; set; }
    public string[] Errors { get; set; }
}
