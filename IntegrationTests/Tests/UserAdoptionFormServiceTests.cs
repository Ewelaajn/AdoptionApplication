using AdoptionApplication.Shared.Constants;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace IntegrationTests.Tests;

public class UserAdoptionFormTests : TestFixture
{
    [Test]
    public async Task UpsertAdoptionForm_FormToChosenAnimalWithTheSameEmailExists_ShouldNotAddNewForm()
    {
        // ARRANGE
        var newForm = TestModelsGenerator.GenerateAdoptionForm(1, AdoptionFormStatusConstants.New);
        _dataContext.AdoptionForms.Add(newForm);
        _dataContext.SaveChanges();
        var secondForm = TestModelsGenerator.GenerateAdoptionForm(1, AdoptionFormStatusConstants.New);
        secondForm.Email = newForm.Email;
        
        // ACT
        await _userAdoptionFormService.UpsertUserForm(secondForm);
        var result = await _dataContext.AdoptionForms
            .Where(x => x.AnimalId == 1 && x.Email == newForm.Email)
            .ToListAsync();
        
        // ASSERT
        result.Count.Should().Be(1);
    }
    
    [Test]
    public async Task ChangeFormStatus_DifferentStatusParameterApplied_FormStatusShouldChange()
    {
        // ARRANGE
        var newForm = TestModelsGenerator.GenerateAdoptionForm(1, AdoptionFormStatusConstants.New);
        _dataContext.AdoptionForms.Add(newForm);
        _dataContext.SaveChanges();
        var status = AdoptionFormStatusConstants.Rejected;
        
        // ACT
        await _userAdoptionFormService.ChangeFormStatus(newForm.Id, status);
        var result = await _dataContext.AdoptionForms.FindAsync(newForm.Id);
        
        // ASSERT
        result?.Status.Should().Be(status);
    }
}