using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using AdoptionApplication.Server.Services.AdoptionForm;
using AdoptionApplication.Shared;

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

        [HttpPost]
        public async Task<ActionResult<UserAdoptionForm>> AddNewForm([FromBody] UserAdoptionForm form)
        {
            var result = await _userAdoptionFormService.AddNewForm(form);
            if(result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
