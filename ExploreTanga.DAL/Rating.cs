namespace ExploreTanga.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Rating
    {
        public Rating()
        {
            this.Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }

        [Display(Name = "Rating")]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}