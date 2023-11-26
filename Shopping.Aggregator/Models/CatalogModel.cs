﻿namespace Shopping.Aggregator.Models
{
    public class CatalogModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Cover { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}