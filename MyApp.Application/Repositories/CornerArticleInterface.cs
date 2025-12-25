using MyApp.Application.Interfaces;
using MyApp.Core.Entities;
using MyApp.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Repositories
{
    public class CornerArticleInterface : ICornerArticleInterface
    {
        private readonly ICornerArticleRepository _empRepos;

        public CornerArticleInterface(ICornerArticleRepository empRepos)
        {
            _empRepos = empRepos;
        }
        public Task AddAsync(CSharpCornerArticle article)
        {
            return _empRepos.AddAsync(article);
           
        }

        public async Task<IEnumerable<CSharpCornerArticle>> GetAllAsync()
        {
           return await _empRepos.GetAllAsync();
        }

        public Task<CSharpCornerArticle?> GetByIdAsync(int id)
        {
            return _empRepos.GetByIdAsync(id);
        }
    }
}
