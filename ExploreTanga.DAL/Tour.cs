namespace ExploreTanga.DAL
{
    using System;
    using System.Collections.Generic;

    public partial class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public decimal Price { get; set; }
        public int RatingId { get; set; }
        public bool IncludesMeals { get; set; }

        public virtual Rating Rating { get; set; }
    }
}