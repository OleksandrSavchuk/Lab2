namespace WebApplication3.Models
{
    public class Category
    {
        public Category()
        {
            Movies = new List<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
