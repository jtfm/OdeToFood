using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty] public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantRepository restaurantRepository, IHtmlHelper htmlHelper)
        {
            _restaurantRepository = restaurantRepository;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();

            Restaurant = restaurantId.HasValue
                ? _restaurantRepository.GetRestaurantById(restaurantId.Value)
                : new Restaurant();

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
                
            }

            if (Restaurant.Id > 0)
            {
                _restaurantRepository.Update(Restaurant);
            }
            else
            {
                _restaurantRepository.Create(Restaurant);
            }
            
            _restaurantRepository.Commit();
            TempData["Message"] = "Restaurant saved.";
            return RedirectToPage("./Detail",
                new { restaurantId = Restaurant.Id });
        }
    }
}