namespace anonymous_message.Application.Common.Interfaces;

public interface ICurrentUserService
{
    Guid? UserId { get; }
}
