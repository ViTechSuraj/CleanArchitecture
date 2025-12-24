using Microsoft.EntityFrameworkCore;
using MyApp.Core.Entities;
using MyApp.Core.Interface;
using MyApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositories
{

    public class EmpolyeeRepositorory : IEmpolyeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmpolyeeRepositorory(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<CSharpCornerArticle>> GetAllAsync()
        {

            return await _db.CSharpCornerArticles
            .FromSqlRaw("CALL sp_GetAllArticles()")
            .ToListAsync();
        }
        public async Task AddAsync(CSharpCornerArticle article)
        {

            await _db.Database.ExecuteSqlRawAsync(
                "CALL sp_InsertArticle({0}, {1}, {2})",
                article.Title,
                article.Content,
                DateTime.Now
            );
        }
        public async Task<CSharpCornerArticle?> GetByIdAsync(int id)
        {
            var list = await _db.CSharpCornerArticles
                .FromSqlRaw("CALL sp_GetArticleById({0})", id)
                .AsNoTracking()
                .ToListAsync();   // ✅ MySQL-safe

            return list.FirstOrDefault(); // ✅ in-memory
        }


    }
}
