using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IRestaurantRepository _restaurantRepository;
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration, IRestaurantRepository restaurantRepository)
        {
            _configuration = configuration;
            _restaurantRepository = restaurantRepository;
        }

        public void OnGet()
        {
            Message = _configuration["Message"];
            Restaurants = _restaurantRepository.GetRestaurantsByName(SearchTerm);
        }
    }
}