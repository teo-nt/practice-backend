namespace MovieAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<OrderMovie> OrderMovies { get; set; }
    }
}
