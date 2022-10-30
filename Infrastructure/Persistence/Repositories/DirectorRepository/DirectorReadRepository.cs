using Application.Repositories.IDirectorRepositories;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.DirectorRepository
{
    public class DirectorReadRepository : ReadRepository<Director>, IDirectorReadRepository
    {
        public DirectorReadRepository(MovieDbContext db) : base(db)
        {
        }
    }
}
