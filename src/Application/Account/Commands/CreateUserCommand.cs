using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using anonymous_message.Application.Responses;
using MediatR;

namespace anonymous_message.Application.Account.Commands;
public class CreateUserCommand : IRequest<Guid>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
