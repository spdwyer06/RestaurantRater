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
        [HttpPost]
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
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Restaurant> restaurants = await _dbContext.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        // GET BY ID
        [HttpGet]
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
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRestaurant([FromUri]int ID, [FromBody]Restaurant model)
        {
            if(ModelState.IsValid && model != null)
            {
                // This is the entity
                Restaurant restaurant = await _dbContext.Restaurants.FindAsync(ID);
                
                if(restaurant != null)
                {
                    restaurant.Name = model.Name;
                    restaurant.FoodStyle = model.FoodStyle;
                    restaurant.Rating = model.Rating;
                    restaurant.DollarSigns = model.DollarSigns;

                    await _dbContext.SaveChangesAsync();

                    return Ok();
                }

                return NotFound();
            }

            return BadRequest(ModelState); 
        }

        // DELETE BY ID
        //[HttpDelete]
        
    }
}
