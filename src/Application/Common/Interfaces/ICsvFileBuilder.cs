using anonymous_message.Application.TodoLists.Queries.ExportTodos;

namespace anonymous_message.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
