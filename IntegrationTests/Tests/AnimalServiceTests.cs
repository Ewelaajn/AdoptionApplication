using AdoptionApplication.Shared.Constants;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace IntegrationTests.Tests;

public class AnimalTests : TestFixture
{
    [Test]
    public async Task GetAnimalsAsync_CorrectParametersApplied_ShouldReturnBatchAnimals()
    {
        // ACT
        var result = await _animalService
            .GetAnimalsAsync(1, default, default, default);
        var total = result.Animals.Count;
        
        // ASSERT
        result.Animals.Count.Should().BeGreaterThan(0);
        result.Total.Should().BeGreaterOrEqualTo(total);
        result.ErrorMessage.Should().BeEmpty();
    }

    [Test]
    public async Task UpsertAnimalAsync_NewParametersForAnimalApplied_ShouldUpdateAnimalData()
    {
        // ARRANGE
        var newDataAnimal = TestModelsGenerator
                .GenerateAnimal(1, GenderContants.Undefined, HealthStatusContants.Unhealthy, 1);

        // ACT
        var expectedResult = await _animalService.UpsertAnimalAsync(newDataAnimal);
        var result = await _dataContext.Animals.FindAsync(expectedResult.Id);
        
        // ASSERT
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public async Task DeleteAnimal_AnimalExists_DeletedEqualsTrue()
    {
        // ACT
        await _animalService.DeleteAnimal(1);
        var result = await _dataContext.Animals.FindAsync(1);
        
        // ASSERT
        result?.Deleted.Should().BeTrue();
    }
    
    [Test]
    public async Task DeleteAnimal_FormsForAnimalAreCreated_ShouldDeleteAllFormsForAnimal()
    {
        // ARRANGE
        var form = TestModelsGenerator.GenerateAdoptionForm(1, AdoptionFormStatusConstants.New);
        _dataContext.AdoptionForms.Add(form);
        _dataContext.SaveChanges();
        
        // ACT
        await _animalService.DeleteAnimal(1);
        var result = await _dataContext.AdoptionForms
            .Where(x => x.AnimalId == 1 && x.Deleted == false).ToListAsync();

        // ASSERT
        result.Count.Should().Be(0);
    }
}