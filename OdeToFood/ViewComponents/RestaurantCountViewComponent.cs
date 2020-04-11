using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantCountViewComponent(
            IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public IViewComponentResult Invoke()
        {
            var count = _restaurantRepository.CountRestaurants();
            return View(count);
        }
    }
}