namespace MovieAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public double Price { get; set; }
        public decimal Rate {  get; set; }
        public DateOnly ReleaseDate { get; set; }
        public int ScreenYear { get; set; }
        public string? Genre { get; set; }
        public string? Director { get; set; }
        public string? Plot { get; set; }
        public string? Country { get; set; }
        public string? Writer { get; set; }
        public string? Language { get; set; }
        public string? Description { get; set; }
        public string? LeadActor { get; set; }   
        public string? Type { get; set; }

        public virtual ICollection<OrderMovie> OrderMovies { get; set; } = new HashSet<OrderMovie>();
    }
}
