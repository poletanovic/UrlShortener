using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NewsEntity = Domain.Entities.News;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<NewsEntity> News { get; set; }

        DbSet<Author> Authors { get; set; }

        DbSet<UrlModel> UrlModels { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
