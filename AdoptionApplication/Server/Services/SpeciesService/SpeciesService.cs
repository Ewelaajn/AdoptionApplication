using AdoptionApplication.Server.Data;
using AdoptionApplication.Shared;
using Microsoft.EntityFrameworkCore;

namespace AdoptionApplication.Server.Services.SpeciesService
{
    public class SpeciesService : ISpeciesService
    {
        public ICollection<Species> Species { get; set; } = new List<Species>();
        private readonly DataContext _dataContext;

        public SpeciesService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ICollection<Species>> GetSpeciesAsync()
        {
            return await _dataContext.Species.AsNoTracking().ToListAsync();
        }

        public async Task<Species> GetSpeciesByUrlAsync(string speciesUrl)
        {
            return await _dataContext.Species.AsNoTracking().FirstOrDefaultAsync(x => x.Url.ToLower() == speciesUrl.ToLower());
        }
    }
}
