namespace MovieAPI.DTO
{
    public class OrderReadOnlyDTO
    {
        public int OrderId { get; set; }
        public IList<MovieOrderDTO> Movies { get; set; } = new List<MovieOrderDTO>();
        public DateTime OrderDate { get; set; }
    }
}
