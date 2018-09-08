using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OtherPerspectivesWebApp.Models
{
    public class Painting
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public IEnumerable<Painting> GetAllPaintings()
        {
//            using (var context = new OtherPerspectivesContext())
//            {
//                return context.Paintings.ToList();
//            }
            return new List<Painting>();
        }
    }
}