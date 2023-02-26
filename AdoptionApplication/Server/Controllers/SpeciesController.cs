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

        [HttpPost]
        public async Task<ActionResult<Species>> AddSpecies([FromBody] Species species)
        {
            var result = await _speciesService.UpsertNewSpecies(null, species);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Species>> UpsertSpecies(int id, [FromBody] Species species)
        {
            var result = await _speciesService.UpsertNewSpecies(id, species);
            return Ok(result);
        }
        /*[HttpPut]
        [HttpDelete]*/
    }
}
