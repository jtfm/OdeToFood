using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string searchTerm);

        Restaurant GetRestaurantById(int id);

        Restaurant Update(Restaurant updatedRestaurant);

        Restaurant Create(Restaurant newRestaurant);

        Restaurant DeleteById(int id);

        int CountRestaurants();
        int Commit();
    }
}
