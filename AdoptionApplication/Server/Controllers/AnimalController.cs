using AdoptionApplication.Server.Services.Animals;
using AdoptionApplication.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AdoptionApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Animal>>> GetAnimals()
        {
            var animals = await _animalService.GetAnimalsAsync();
            return Ok(animals);

        }

        [HttpGet("Species/{speciesUrl}")]
        public async Task<ActionResult<ICollection<Animal>>> GetAnimalsBySpecies(string speciesUrl)
        {
            var animals = await _animalService.GetAnimalsBySpeciesAsync(speciesUrl);
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            var animal = await _animalService.GetAnimalByIdAsync(id);
            return Ok(animal);
        }
        /*[HttpPost]
        [HttpPut]
        [HttpDelete]*/
    }
}
