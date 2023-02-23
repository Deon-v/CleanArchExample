using CleanArchExample.Application.Common.Interfaces;
using CleanArchExample.Domain.Entities;
using CleanArchExample.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArchExample.Infrastructure.Persistence
{
    public class DataContext : DbContext, IApplicationDbContext
    {
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

        public DataContext()
        {
            
        }

        public DataContext(DbContextOptions options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
        {
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NotConfiguredDB");

            options.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        public DbSet<WeatherForecast> WeatherHistory => Set<WeatherForecast>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
