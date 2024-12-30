namespace WebApplication1.Models
{
    public class ListPerson
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public List<Book>? Books { get; set; }
    }
}
