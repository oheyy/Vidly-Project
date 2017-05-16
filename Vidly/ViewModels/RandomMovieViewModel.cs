using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Controllers;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RandomMovieViewModel
    {
        public Customer Customers { get; set; }
        public List<Movie> Movies { get; set; }       
        
    }
}