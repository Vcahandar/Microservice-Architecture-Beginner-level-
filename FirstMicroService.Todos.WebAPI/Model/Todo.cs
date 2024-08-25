namespace FirstMicroService.Todos.WebAPI.Model
{
	public sealed class Todo
	{
        public int Id { get; set; }
        public string Work { get; set; } = default!;
    }
}
