using FluentAssertions;
using NUnit.Framework;

namespace IntegrationTests.Tests;

public class SpeciesServiceTests : TestFixture
{
    [Test]
    public async Task GetSingleSpeciesAsync_SpeciesDoesNotExist_ReturnErrorMessage()
    {
        // ACT
        var result = await _speciesService.GetSingleSpeciesAsync(10);
        
        // ASSERT
        result.ErrorMessage.Should().Be("Gatunek nie odnaleziony");
    }

    [Test]
    public async Task UpsertNewSpecies_CorrectParametersSupplied_ShouldUpdateSpecies()
    {
        // ARRANGE
        var updateSpecies = TestModelsGenerator.GenerateSpecies(1);
        
        // ACT
        var expectedResult = await _speciesService.UpsertNewSpecies(updateSpecies);
        var result = await _dataContext.Species.FindAsync(1);
        
        // ASSERT
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public async Task DeleteSpecies_AnimalsAreAlreadyAssigned_ShouldReturnErrorMessage()
    {
        // ACT
        var result = await _speciesService.DeleteSpecies(1);
        
        // ASSERT
        result.ErrorMessage.Should().Be("Nie można usunąć gatunku, który jest przypisany do innych zwierząt");
    }
}