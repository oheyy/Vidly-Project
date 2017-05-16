using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    //Pure view Model so the inputs in the MovieForm.cshtml can be nullable types
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres{ get; set; }

        //Nullable for the MovieForm.cshtml 
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release date")]
        public DateTime? ReleaseDate { get; set; }


        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public byte? NumberInStock { get; set; }

        public string Title
        {
            get { return Id != 0 ? "Edit Movie" : "New Movie"; }
            
        }
        //For New movie
        public MovieFormViewModel()
        {
            Id = 0;
        }
        //For Edit and Existing 
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock= movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}