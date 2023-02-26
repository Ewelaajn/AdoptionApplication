using AdoptionApplication.Server.Data;
using AdoptionApplication.Shared;
using AdoptionApplication.Shared.Constants;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AdoptionApplication.Server.Services.AdoptionForm
{
    public class UserAdoptionFormService : IUserAdoptionFormService
    {
        private readonly DataContext _dataContext;
        private readonly IValidator<UserAdoptionForm> _validator;

        public UserAdoptionFormService(DataContext dataContext, IValidator<UserAdoptionForm> validator)
        {
            _dataContext = dataContext;
            _validator = validator;
        }

        public async Task<UserAdoptionForm> AddNewForm(UserAdoptionForm newForm)
        {
            var validation = _validator.Validate(newForm);
            if (!validation.IsValid)
                return null;

            var alreadyExists = await _dataContext.AdoptionForms.FirstOrDefaultAsync(x => x.Email == newForm.Email && x.AnimalId == newForm.AnimalId);
            if (alreadyExists != null)
                return newForm;

            newForm.Deleted = false;
            newForm.Status = AdoptionFormStatusConstants.New;
            _dataContext.AdoptionForms.Add(newForm);
            await _dataContext.SaveChangesAsync();

            return newForm;
        }

        public async Task<UserAdoptionForm> ChangeFormStatus(int id, string status)
        {
            var form = await _dataContext.AdoptionForms.FirstOrDefaultAsync(x => x.Id == id);

            if (form == null)
                return null;

            form.Status = status;
            if(status == AdoptionFormStatusConstants.Finished)
            {
                var animal = await _dataContext.Animals.FirstOrDefaultAsync(x => x.Id == form.AnimalId);
                animal.IsAdopted = true;
            }
            await _dataContext.SaveChangesAsync();

            return form;
        }

        public async Task DeleteForm(int id)
        {
            var form = await _dataContext.AdoptionForms.FirstOrDefaultAsync(x => x.Id == id);
            if(form == null) return;

            form.Deleted = true;
            await _dataContext.SaveChangesAsync();
        }

        public async Task<UserAdoptionForm> GetUserAdoptionFormAsync(int id)
        {
            var form = await _dataContext.AdoptionForms.FirstOrDefaultAsync(x => x.Id == id);
            if (form == null)
                return null;

            return form;
        }

        public async Task<ICollection<UserAdoptionForm>> GetUserAdoptionFormsAsync()
        {
            return await _dataContext.AdoptionForms.ToListAsync();
        }
    }
}
