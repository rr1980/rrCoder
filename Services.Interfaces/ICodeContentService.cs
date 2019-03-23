﻿using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using VievModels;

namespace Services.Interfaces
{
    public interface ICodeContentService
    {
        Task<List<CodeContentVievmodel>> GetAllCodeContent();
        Task Add();

    }
}
