using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantRepository.GetRestaurantById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            Restaurant restaurant = _restaurantRepository.DeleteById(restaurantId);
            _restaurantRepository.Commit();

            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{restaurant.Name} deleted.";
            return RedirectToPage("./List");
        }
    }
}