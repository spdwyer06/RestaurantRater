using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class Restaurant
    {
        // ID is the Primary Key
        // A key is a required field by default
        [Key]
        public int ID { get; set; }
        
        [Required]
        public string FoodStyle { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        [Range(0, 5)]
        public float Rating { get; set; }
        
        [Required]
        // Only allows the values between 1-5 to be a valid input for the property
        [Range(1, 5)]
        public int DollarSigns { get; set; }
    }
}