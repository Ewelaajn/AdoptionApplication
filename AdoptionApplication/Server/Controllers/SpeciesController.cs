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
            var result = await _speciesService.GetSingleSpeciesAsync(id);
            if(!string.IsNullOrWhiteSpace(result.ErrorMessage))
                return Conflict(result);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Species>> UpsertSpecies([FromBody] Species species)
        {
            var result = await _speciesService.UpsertNewSpecies(species);
            if(!string.IsNullOrWhiteSpace(result.ErrorMessage))
                return Conflict(result);
            return Accepted(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSpecies(int id)
        {
            var result = await _speciesService.DeleteSpecies(id);
            if(!string.IsNullOrWhiteSpace(result.ErrorMessage))
                return Conflict(result);
            return Accepted();
        }
    }
}
