using AdoptionApplication.Server.Services.SpeciesService;
using AdoptionApplication.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AdoptionApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private readonly ISpeciesService _speciesService;

        public SpeciesController(ISpeciesService speciesService)
        {
            _speciesService = speciesService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Species>>> GetSpecies()
        {
            var species = await _speciesService.GetSpeciesAsync();

            return Ok(species);
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Species>> GetSingleSpecies(int id)
        {
            var species = await _speciesService.GetSingleSpeciesAsync(id);
            return Ok(species);
        }

        [HttpPut]
        public async Task<ActionResult<Species>> UpsertSpecies([FromBody] Species species)
        {
            try
            {
                var result = await _speciesService.UpsertNewSpecies(species);
                return Accepted(result);
            }
            catch(Exception ex)
            {
                return BadRequest($"{ex.Message}, {ex.StackTrace}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSpecies(int id)
        {
            await _speciesService.DeleteSpecies(id);
            return Accepted();
        }
    }
}
