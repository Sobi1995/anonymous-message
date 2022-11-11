using anonymous_message.Application.Common.Mappings;
using anonymous_message.Domain.Entities;

namespace anonymous_message.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
