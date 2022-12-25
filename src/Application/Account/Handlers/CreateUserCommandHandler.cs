using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using anonymous_message.Application.Account.Commands;
using anonymous_message.Application.Common.Interfaces;
using anonymous_message.Application.Responses;
using MediatR;

namespace anonymous_message.Application.Account.Handlers;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IIdentityService _identityService;
    public CreateUserCommandHandler(IIdentityService identityService) => _identityService = identityService;


    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        return (await _identityService.CreateUserAsync(request.UserName,request.Password)).UserId;
    }
}