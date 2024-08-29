﻿namespace MovieAPI.DTO
{
    public class MovieOrderDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
