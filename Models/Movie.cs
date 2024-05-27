namespace WebApplication3.Models
{
    public class Movie
    {
        public Movie()
        {
            DirectorMovies = new List<DirectorMovie>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<DirectorMovie> DirectorMovies { get; set; }
    }
}
