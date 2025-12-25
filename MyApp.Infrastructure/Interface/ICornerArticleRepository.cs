using MyApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Interface
{
    public interface ICornerArticleRepository
    {
        Task<IEnumerable<CSharpCornerArticle>> GetAllAsync();
        Task AddAsync(CSharpCornerArticle article);
        Task<CSharpCornerArticle?> GetByIdAsync(int id);
    }
}
