using AdoptionApplication.Shared.DbModels;
using Bogus;

namespace IntegrationTests;

public class TestModelsGenerator
{
    public static Animal GenerateAnimal(int id, string gender, string healthStatus, int speciesId)
    {
        var faker = new Faker<Animal>()
            .RuleFor(d => d.Id, id)
            .RuleFor(d => d.City, f => f.Address.City())
            .RuleFor(d => d.Name, f => f.Person.FirstName)
            .RuleFor(d => d.Gender, gender)
            .RuleFor(d => d.ShortDescription, f => f.Lorem.Sentences())
            .RuleFor(d => d.Description, f => f.Lorem.Sentences())
            .RuleFor(d => d.HealthStatus, healthStatus)
            .RuleFor(d => d.Province, f => f.Address.County())
            .RuleFor(d => d.DateOfBirth, f => DateTime.SpecifyKind(f.Date.Past(4), DateTimeKind.Utc))
            .RuleFor(d => d.SpeciesId, speciesId);

        return faker;
    }

    public static Species GenerateSpecies(int id)
    {
        var faker = new Faker<Species>()
            .RuleFor(d => d.Id, id)
            .RuleFor(d => d.Name, f => f.Random.Word())
            .RuleFor(d => d.Url, f => f.Random.Word())
            .RuleFor(d => d.Icon, f => f.Random.Word());

        return faker;
    }

    public static UserAdoptionForm GenerateAdoptionForm(int animalId, string status)
    {
        var faker = new Faker<UserAdoptionForm>()
            .RuleFor(d => d.Id, f => f.Random.Int(min:1))
            .RuleFor(d => d.AnimalId, animalId)
            .RuleFor(d => d.FirstName, f => f.Person.FirstName)
            .RuleFor(d => d.LastName, f => f.Person.LastName)
            .RuleFor(d => d.Email, f => f.Person.Email)
            .RuleFor(d => d.PhoneNumber, f => f.Person.Phone)
            .RuleFor(d => d.Age, f => f.Random.Number(18, 50).ToString())
            .RuleFor(d => d.AboutMe, f => f.Lorem.Paragraphs())
            .RuleFor(d => d.Status, status);

        return faker;
    }
}