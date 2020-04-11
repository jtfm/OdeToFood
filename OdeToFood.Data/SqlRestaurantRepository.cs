using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class SqlRestaurantRepository : IRestaurantRepository
    {
        private readonly OdeToFoodDbContext _dbContext;

        public SqlRestaurantRepository(OdeToFoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string searchTerm)
        {
            return _dbContext.Restaurants.Where(r =>
                    string.IsNullOrEmpty(searchTerm) ||
                    r.Name.Contains(searchTerm))
                .OrderByDescending(r => r.Name);
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _dbContext.Restaurants.Find(id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            EntityEntry<Restaurant> entity =
                _dbContext.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }

        public Restaurant Create(Restaurant newRestaurant)
        {
            _dbContext.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant DeleteById(int id)
        {
            Restaurant restaurant = GetRestaurantById(id);
            if (restaurant != null)
            {
                _dbContext.Remove(restaurant);
            }

            return restaurant;
        }

        public int CountRestaurants()
        {
            return _dbContext.Restaurants.Count();
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
    }
}