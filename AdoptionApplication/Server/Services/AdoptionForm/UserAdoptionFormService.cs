using AdoptionApplication.Server.Data;
using AdoptionApplication.Shared;
using AdoptionApplication.Shared.Constants;
using AdoptionApplication.Shared.DTO;
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

        public async Task<UserAdoptionForm> UpsertUserForm(UserAdoptionForm newForm)
        {
            var validation = await _validator.ValidateAsync(newForm);
            if (!validation.IsValid)
                return new UserAdoptionForm{ErrorMessage = string.Join(", ", validation.Errors.Select(x => x.ErrorMessage).ToList())};

            var alreadyExists = await _dataContext.AdoptionForms
                .FirstOrDefaultAsync(x => x.Email == newForm.Email && x.AnimalId == newForm.AnimalId);
            if (alreadyExists != null)
                return newForm;

            newForm.Status = AdoptionFormStatusConstants.New;
            _dataContext.AdoptionForms.Add(newForm);
            await _dataContext.SaveChangesAsync();

            return newForm;
        }

        public async Task<UserAdoptionForm> ChangeFormStatus(int id, string status)
        {
            var form = await _dataContext.AdoptionForms.FirstOrDefaultAsync(x => x.Id == id);

            if (form == null)
                return new UserAdoptionForm{ErrorMessage = "Formularz nie znaleziony"};

            form.Status = status;
            if(status == AdoptionFormStatusConstants.Finished)
            {
                var animal = await _dataContext.Animals.FirstOrDefaultAsync(x => x.Id == form.AnimalId);
                if (animal != null)
                    animal.IsAdopted = true;
                else
                    form.ErrorMessage = "Zwierzę dla tego formularza nie istnieje";
            }
            await _dataContext.SaveChangesAsync();

            return form;
        }

        public async Task<UserAdoptionForm> GetUserAdoptionFormAsync(int id)
        {
            var form = await _dataContext.AdoptionForms.AsNoTracking()
                .Include(x => x.Animal)
                .FirstOrDefaultAsync(x => x.Id == id);
            return form ?? new UserAdoptionForm{ErrorMessage = "Formularz nie znaleziony"};
        }

        public async Task<BatchAdoptionForm> GetUserAdoptionFormsAsync(int? page, string? email, int? animalId, string status)
        {
            var query = _dataContext.AdoptionForms.AsNoTracking()
                .Include(x => x.Animal)
                .OrderBy(x => x.Id)
                .Where(x => x.Deleted == false);
            query = PrepareQuery(query, email, animalId, status);
            var total = await query.CountAsync();
            query = ApplyPagination(query, page);
            
            return new BatchAdoptionForm { Total = total, AdoptionForms = await query.ToListAsync() };
        }
        
        private IQueryable<UserAdoptionForm> PrepareQuery(IQueryable<UserAdoptionForm> query, string? email, int? animalId, string status)
        {
            if (!string.IsNullOrWhiteSpace(email))
                query = query.Where(x => x.Email == email);
            if (animalId.HasValue)
                query = query.Where(x => x.AnimalId == animalId);
            if(!string.IsNullOrWhiteSpace(status))
                query = query.Where(x => x.Status == status);

            return query;
        }
        
        private IQueryable<UserAdoptionForm> ApplyPagination(IQueryable<UserAdoptionForm> query, int? page)
        {
            var toSkip = PaginationService.HowManyItemsSkip(page);
            if (toSkip != null)
                query = query.Skip(toSkip.Value).Take(PaginationService.PageItems);

            return query;
        }
    }
}
