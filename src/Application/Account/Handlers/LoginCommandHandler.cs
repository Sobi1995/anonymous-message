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
public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationResponse>
{
    private readonly IIdentityService _identityService;
    public LoginCommandHandler(IIdentityService identityService) => _identityService = identityService;

    public async Task<AuthenticationResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _identityService.LoginAsync(request);
    }
}
 