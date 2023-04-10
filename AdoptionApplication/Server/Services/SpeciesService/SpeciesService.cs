using AdoptionApplication.Server.Data;
using AdoptionApplication.Shared;
using AdoptionApplication.Shared.DbModels;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AdoptionApplication.Server.Services.SpeciesService
{
    public class SpeciesService : ISpeciesService
    {
        public ICollection<Species> Species { get; set; } = new List<Species>();
        private readonly DataContext _dataContext;
        private readonly IValidator<Species> _validator;

        public SpeciesService(DataContext dataContext, IValidator<Species> validator)
        {
            _dataContext = dataContext;
            _validator = validator;
        }

        public async Task<ICollection<Species>> GetSpeciesAsync()
        {
            return await _dataContext.Species.AsNoTracking().Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<Species> GetSpeciesByUrlAsync(string speciesUrl)
        {
            return await _dataContext.Species.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Url.ToLower() == speciesUrl.ToLower() && x.Deleted == false) 
                   ?? new Species{ErrorMessage = "Gatunek nie odnaleziony"};
        }

        public async Task<Species> GetSingleSpeciesAsync(int id)
        {
            var species = await _dataContext.Species
                              .AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id) 
                          ?? new Species{ErrorMessage = "Gatunek nie odnaleziony"};
            return species;
        }

        public async Task<Species> UpsertNewSpecies(Species species)
        {
            try
            {
                var validation = _validator.Validate(species);
                if (!validation.IsValid)
                    return new Species{ErrorMessage = string.Join(", ", validation.Errors.Select(x => x.ErrorMessage).ToList())};
                
                if (species.Id > 0)
                {
                    var dbSpecies = await _dataContext.Species.FirstOrDefaultAsync(x => x.Id == species.Id);
                    if (dbSpecies != null)
                    {
                        dbSpecies.Url = species.Url;
                        dbSpecies.Name = species.Name;
                        dbSpecies.Icon = species.Icon;
                        species = dbSpecies;
                    }
                    else
                        _dataContext.Species.Add(species);
                }
                else if (species.Id == 0 || species.Id == null)
                {
                    var isSpeciesExists =
                        await _dataContext.Species.FirstOrDefaultAsync(x => x.Name.ToLower() == species.Name.ToLower() && x.Deleted == false);
                    if (isSpeciesExists != null)
                    {
                        isSpeciesExists.Url = species.Url;
                        isSpeciesExists.Name = species.Name;
                        isSpeciesExists.Icon = species.Icon;
                    }
                    else
                        _dataContext.Species.Add(species);
                }

                await _dataContext.SaveChangesAsync();
                return species;
            }
            catch (Exception ex)
            {
                return new Species { ErrorMessage = ex.Message };
            }
        }

        public async Task<Species> DeleteSpecies(int id)
        {
            var species = await _dataContext.Species
                .Include(x => x.Animals.Where(x => x.Deleted == false))
                .FirstOrDefaultAsync(x => x.Id == id);

            if (species == null)
                return new Species();
            if (species.Animals != null && species.Animals.Any())
                return new Species { ErrorMessage = "Nie można usunąć gatunku, który jest przypisany do innych zwierząt" };
            
            species.Deleted = true;
            await _dataContext.SaveChangesAsync();
            return species;
        }
    }
}
