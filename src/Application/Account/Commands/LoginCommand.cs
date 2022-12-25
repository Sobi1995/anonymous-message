using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using anonymous_message.Application.Responses;
using MediatR;

namespace anonymous_message.Application.Account.Commands;
public class LoginCommand : IRequest<AuthenticationResponse>
{
    public string UserId { get; set; }
    public string Password { get; set; }
}