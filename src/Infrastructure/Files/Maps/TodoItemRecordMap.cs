using System.Globalization;
using anonymous_message.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace anonymous_message.Infrastructure.Files.Maps;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}
