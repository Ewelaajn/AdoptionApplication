﻿using AdoptionApplication.Shared;
using AdoptionApplication.Shared.DTO;

namespace AdoptionApplication.Server.Services.AdoptionForm
{
    public interface IUserAdoptionFormService
    {
        Task<BatchAdoptionForm> GetUserAdoptionFormsAsync(int? page);
        Task<UserAdoptionForm> GetUserAdoptionFormAsync(int id);
        Task<UserAdoptionForm> ChangeFormStatus(int formId, string status);
        Task<UserAdoptionForm> UpsertUserForm(UserAdoptionForm newForm);
        Task DeleteForm(int id);
    }
}
