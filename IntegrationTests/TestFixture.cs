using AdoptionApplication.Server.Data;
using AdoptionApplication.Server.Services.AdoptionForm;
using AdoptionApplication.Server.Services.Animals;
using AdoptionApplication.Server.Services.SpeciesService;
using AdoptionApplication.Shared.Constants;
using AdoptionApplication.Shared.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace IntegrationTests;

[TestFixture]
public class TestFixture
{
    public DataContext _dataContext;
    public AnimalService _animalService;
    public SpeciesService _speciesService;
    public UserAdoptionFormService _userAdoptionFormService;

    /*public TestFixture(DataContext dataContext)
    {
        _dataContext = dataContext;
    }*/

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _dataContext = CreateDbContext();
        _speciesService = new SpeciesService(_dataContext, new SpeciesValidator());
        _animalService = new AnimalService(_speciesService, _dataContext, new AnimalValidator());
        _userAdoptionFormService = new UserAdoptionFormService(_dataContext, new UserAdoptionFormValidator());
    }

    [SetUp]
    public void SetUp()
    {
        AddAnimalAndSpeciesWithId1();
    }

    [TearDown]
    public void OneTimeTearDown()
    {
       _dataContext.AdoptionForms.Clear();
       _dataContext.Animals.Clear();
       _dataContext.Species.Clear();
       _dataContext.SaveChanges();
    }
    
    private void AddAnimalAndSpeciesWithId1()
    {
        var species = TestModelsGenerator.GenerateSpecies(1);
        _dataContext.Species.Add(species);

        var dbAnimal = TestModelsGenerator
            .GenerateAnimal(1, GenderContants.Female, HealthStatusContants.Healthy, 1);
        _dataContext.Animals.Add(dbAnimal);
        _dataContext.SaveChanges();
    }
    
    private DataContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=adoption_db_test;Connection Lifetime=0;")
            .Options;

        var context = new DataContext(options);
        context.Database.EnsureCreated();
        return context;
    }
}