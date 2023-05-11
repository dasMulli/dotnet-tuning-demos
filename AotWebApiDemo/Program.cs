using AotWebApiDemo;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Logging.AddConsole();


var app = builder.Build();

var sampleTodos = TodoGenerator.GenerateTodos().ToArray();

var todosApi = app.MapGroup("/todos");
todosApi.MapGet("/", () => sampleTodos);
todosApi.MapGet("/{id}", (int id) =>
    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.Run();

// [JsonSerializable(typeof(Todo))]
// [JsonSerializable(typeof(Todo[]))]
// internal partial class TodoJsonContext : JsonSerializerContext
// {
// }





// builder.Services.ConfigureHttpJsonOptions(options =>
// {
//     options.SerializerOptions.AddContext<TodoJsonContext>();
// });

