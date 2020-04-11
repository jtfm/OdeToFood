using System;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public enum CuisineType
    {
        None,
        Mexican,
        Italian,
        Indian
    }

    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
