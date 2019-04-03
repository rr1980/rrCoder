using Common;
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
            throw new System.Exception("NA NÖÖÖ!");
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
}
