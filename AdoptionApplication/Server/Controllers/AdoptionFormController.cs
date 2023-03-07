using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using AdoptionApplication.Server.Services.AdoptionForm;
using AdoptionApplication.Shared;
using AdoptionApplication.Shared.DTO;

namespace AdoptionApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptionFormController : ControllerBase
    {
        private readonly IUserAdoptionFormService _userAdoptionFormService;

        public AdoptionFormController(IUserAdoptionFormService userAdoptionFormService)
        {
            _userAdoptionFormService = userAdoptionFormService;
        }

        [HttpGet]
        public async Task<ActionResult<BatchAdoptionForm>> GetForms([FromQuery] int? page, [FromQuery] int? animalId, [FromQuery] string? email)
        {
            var forms = await _userAdoptionFormService.GetUserAdoptionFormsAsync(page, email, animalId);
            return Ok(forms);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAdoptionForm>> GetForm(int id)
        {
            var form = await _userAdoptionFormService.GetUserAdoptionFormAsync(id);
            if (form == null)
                return NotFound();
            return Ok(form);
        }

        [HttpPut]
        public async Task<ActionResult<UserAdoptionForm>> AddNewForm([FromBody] UserAdoptionForm form)
        {
            var result = await _userAdoptionFormService.UpsertUserForm(form);
            if(result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UserAdoptionForm>> UpdateFormStatus([FromBody] UserAdoptionForm form)
        {
            var result = await _userAdoptionFormService.ChangeFormStatus(form.Id, form.Status);
            return Ok(result);
        }
    }
}
