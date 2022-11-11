using anonymous_message.Application.Common.Interfaces;

namespace anonymous_message.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
