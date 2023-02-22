using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CleanArchExample.Domain.Entities;
using CleanArchExample.Infrastructure.Persistence.Interceptors;
using CleanArchExample.Application.Common.Interfaces;
using Microsoft.Extensions.Options;

namespace CleanArchExample.Infrastructure.Persistence
{
    public class DataContext : DbContext, IApplicationDbContext
    {
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

        public DataContext(DbContextOptions options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NotConfiguredDB");

            options.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
