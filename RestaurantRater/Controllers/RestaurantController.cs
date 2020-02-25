using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDbContext _dbContext = new RestaurantDbContext();

        // POST
        public async Task<IHttpActionResult> PostRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid && restaurant!=null)
            {
                _dbContext.Restaurants.Add(restaurant);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }

            return BadRequest(ModelState);
        }

        // GET ALL
        public async Task<IHttpActionResult> GetAll()
        {
            List<Restaurant> restaurants = await _dbContext.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        // GET BY ID
        public async Task<IHttpActionResult> GetByID(int ID)
        {
            Restaurant targetRestaurant = await _dbContext.Restaurants.FindAsync(ID);

            if (targetRestaurant != null)
            {
                return Ok(targetRestaurant); 
            }

            return NotFound();
        }

        // PUT (UPDATE)


        // DELETE BY ID
        

    }
}
