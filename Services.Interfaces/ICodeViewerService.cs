using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using VievModels;

namespace Services.Interfaces
{
    public interface ICodeViewerService
    {
        Task<List<CodeSnippetVievmodel>> GetAllCodeSnippets();
        Task Add();
        Task<IEnumerable<CodeSnippetVievmodel>> Search(CodeViewerSearchRequest request);
    }
}
