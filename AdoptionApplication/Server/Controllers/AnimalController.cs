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
        public async Task<ActionResult<BatchAnimal>> GetAnimals([FromQuery] int? page, [FromQuery]bool? isAdopted, [FromQuery]string? city, [FromQuery]string? province)
        {
            var animals = await _animalService.GetAnimalsAsync(page, isAdopted, city, province);
            return Ok(animals);

        }

        [HttpGet("Species/{speciesUrl}")]
        public async Task<ActionResult<BatchAnimal>> GetAnimalsBySpecies(string speciesUrl, [FromQuery] int? page, [FromQuery]bool? isAdopted, [FromQuery]string? city, [FromQuery]string? province)
        {
            var animals = await _animalService.GetAnimalsBySpeciesAsync(speciesUrl, page, isAdopted, city, province);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAnimal(int id)
        {
            await _animalService.DeleteAnimal(id);
            return Ok();
        }
    }
}
