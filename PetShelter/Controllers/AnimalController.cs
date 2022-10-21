using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllAnimals()
        {
            return Ok(AnimalData.allData);
        }
        [HttpGet("type")]
        public IActionResult GetAnimalsByType(string type)
        {
            switch (type)
            {
                case "Dog":
                    return Ok(AnimalData.allDogs);
                case "Cat":
                    return Ok(AnimalData.allCats);
                default:
                    return BadRequest("Invalid Animal Type");
            }
        }
    }
}
