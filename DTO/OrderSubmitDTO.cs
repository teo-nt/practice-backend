namespace MovieAPI.DTO
{
    public class OrderSubmitDTO
    {
        public int UserId { get; set; }
        public IList<MovieOrderDTO> MoviesToOrder { get; set; } = new List<MovieOrderDTO>();
    }
}
