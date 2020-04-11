using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantRepository : IRestaurantRepository
    {
        private readonly List<Restaurant> _restaurants;

        public InMemoryRestaurantRepository()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "Scott's Pizza",
                    Location = "Maryland",
                    Cuisine = CuisineType.Italian
                },
                new Restaurant
                {
                    Id = 2,
                    Name = "Cinnamon Club",
                    Location = "London",
                    Cuisine = CuisineType.Indian
                },
                new Restaurant
                {
                    Id = 3,
                    Name = "La Costa",
                    Location = "California",
                    Cuisine = CuisineType.Mexican
                }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return name != null
                ? _restaurants.Where(r => r.Name.Contains(name,
                    StringComparison.CurrentCultureIgnoreCase))
                : _restaurants;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            Restaurant restaurant =
                _restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null) // Use automapper here later
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public Restaurant Create(Restaurant newRestaurant)
        {
            _restaurants.Add(newRestaurant);
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant DeleteById(int id)
        {
            var restaurant = _restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                _restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int CountRestaurants()
        {
            return _restaurants.Count;
        }

        public int Commit()
        {
            return 0;
        }
    }
}