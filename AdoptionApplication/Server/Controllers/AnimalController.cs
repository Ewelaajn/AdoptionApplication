using AdoptionApplication.Server.Services.Animals;
using AdoptionApplication.Shared;
using AdoptionApplication.Shared.DTO;
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
        public async Task<ActionResult<BatchAnimal>> GetAnimals([FromQuery] int? page)
        {
            var animals = await _animalService.GetAnimalsAsync(page);
            return Ok(animals);

        }

        [HttpGet("Species/{speciesUrl}")]
        public async Task<ActionResult<BatchAnimal>> GetAnimalsBySpecies(string speciesUrl, [FromQuery] int? page)
        {
            var animals = await _animalService.GetAnimalsBySpeciesAsync(speciesUrl, page);
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            var animal = await _animalService.GetAnimalByIdAsync(id);
            return Ok(animal);
        }

        [HttpPut]
        public async Task<ActionResult<Animal>> UpsertAnimal([FromBody] Animal animal)
        {
            try
            {
                var result = await _animalService.UpsertAnimalAsync(animal);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}, {ex.StackTrace}");
            }
        }
        /*[HttpPost]
        [HttpPut]
        [HttpDelete]*/
    }
}
