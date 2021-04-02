using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CastRepository : EFRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Cast> GetByIdAsync(int id)
        {
            var cast = await _dbContext.Casts.Where(c => c.Id == id).Include(c => c.MovieCasts)
                .ThenInclude(c => c.Movie).FirstOrDefaultAsync();
            return cast;
        }
    }
}
