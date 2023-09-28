using Microsoft.EntityFrameworkCore;

class CTodo
{
  public async Task<IResult> GetAllTodos(TodoDb db)
  {
    return TypedResults.Ok(await db.Todos.ToArrayAsync());
  }

  public async Task<IResult> GetCompleteTodos(TodoDb db)
  {
    return TypedResults.Ok(await db.Todos.Where(t => t.IsComplete).ToListAsync());
  }

  public async Task<IResult> GetTodo(int id, TodoDb db)
  {
    return await db.Todos.FindAsync(id)
        is Todo todo
            ? TypedResults.Ok(todo)
            : TypedResults.NotFound();
  }

  public async Task<IResult> CreateTodo(Todo todo, TodoDb db)
  {
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return TypedResults.Created($"/todoitems/{todo.Id}", todo);
  }

  public async Task<IResult> UpdateTodo(int id, Todo inputTodo, TodoDb db)
  {
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return TypedResults.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();

    return TypedResults.NoContent();
  }

  public async Task<IResult> DeleteTodo(int id, TodoDb db)
  {
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
      db.Todos.Remove(todo);
      await db.SaveChangesAsync();
      return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
  }
}
