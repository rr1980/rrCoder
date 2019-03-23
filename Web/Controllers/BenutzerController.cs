using Common;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CodeContentController : ControllerBase
    {
        private readonly ICodeContentService _codeContentService;

        public CodeContentController(ICodeContentService codeContentService)
        {
            _codeContentService = codeContentService;
        }
        [Authorize(Roles = Role.Admin)]
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _codeContentService.GetAllCodeContent();
            return Ok(values);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost("Add")]
        public async Task Add()
        {
            await _codeContentService.Add();
        }

    }

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BenutzerController : ControllerBase
    {
        private readonly IBenutzerService _benutzeService;

        public BenutzerController(IBenutzerService userService)
        {
            _benutzeService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]Benutzer userParam)
        {
            var user = await _benutzeService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _benutzeService.GetAll();
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // only allow admins to access other user records
            var currentBenutzerId = int.Parse(User.Identity.Name);
            if (id != currentBenutzerId && !User.IsInRole(Role.Admin))
            {
                return Forbid();
            }

            var benutzer = await _benutzeService.GetById(id);

            if (benutzer == null)
            {
                return NotFound();
            }

            return Ok(benutzer);
        }
    }
}
