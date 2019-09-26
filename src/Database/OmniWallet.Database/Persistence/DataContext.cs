using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OmniWallet.Shared.Extensions;

namespace OmniWallet.Database.Persistence
{
    public class DataContext : DbContext
    {
        private readonly string _connectionString;

        public DataContext()
        {
            // TODO: Alterar método que as migrations são implementadas
            _connectionString = "Host=Localhost;Database=omniwallet;Port=5432;User Id=postgres;Password=master;";
//            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseNpgsql(_connectionString);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Lower case all columns and tables (configuration for PostgreSQL)
            foreach(var entity in builder.Model.GetEntityTypes())
            {
                // Replace table names
                entity.Relational().TableName = entity.Relational().TableName.ToSnakeCase();

                // Replace column names            
                foreach(var property in entity.GetProperties())
                    property.Relational().ColumnName = property.Relational().ColumnName.ToSnakeCase();
                

                foreach(var key in entity.GetKeys())
                    key.Relational().Name = key.Relational().Name.ToSnakeCase();

                foreach(var key in entity.GetForeignKeys())
                    key.Relational().Name = key.Relational().Name.ToSnakeCase();

                foreach(var index in entity.GetIndexes())
                    index.Relational().Name = index.Relational().Name.ToSnakeCase();
            }
        }

    }
}