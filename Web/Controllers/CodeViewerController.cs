using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Threading.Tasks;
using VievModels;

namespace Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CodeViewerController : ControllerBase
    {
        private readonly ICodeViewerService _codeContentService;

        public CodeViewerController(ICodeViewerService codeContentService)
        {
            _codeContentService = codeContentService;
        }
        [Authorize]
        [HttpPost("Search")]
        public async Task<IActionResult> Search(CodeViewerSearchRequest request)
        {
            var result = await _codeContentService.Search(request);

            return Ok(new {
                Request = request,
                Result = result
            });
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost("Add")]
        public async Task Add()
        {
            await _codeContentService.Add();
        }

    }
}
