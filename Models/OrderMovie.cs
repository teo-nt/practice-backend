namespace MovieAPI.Models
{
    public class OrderMovie
    {
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }

        public virtual Movie Movie { get; set; }
        public int MovieId { get; set; }

        public int Quantity { get; set; }
    }
}
