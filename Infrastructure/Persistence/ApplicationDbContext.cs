using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IDateTime _dateTime;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options, 
            ICurrentUserService currentUser, 
            IDateTime dateTime) : base(options)
        {
            _currentUser = currentUser;
            _dateTime = dateTime;
        }

        public DbSet<News> News { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<UrlModel> UrlModels { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            cancellationToken = new CancellationToken();

            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = _currentUser?.Username ?? "APP";
                    entry.Entity.Created = _dateTime.Now;
                }
                else if(entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModifiedBy = _currentUser.UserId;
                    entry.Entity.LastModified = _dateTime.Now;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }



    }
}
