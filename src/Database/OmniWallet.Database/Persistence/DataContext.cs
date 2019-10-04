using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OmniWallet.Database.Utils;
using OmniWallet.Shared.Extensions;

namespace OmniWallet.Database.Persistence
{
    internal class DataContext : DbContext
    {
        private readonly string _connectionString;
        
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public DataContext() : this(Settings.ConnectionString)
        {
            // Construtor necessário para instanciar o DbContext sem precisar adicionar 
            // a connection string diretamente no código 
        }
        
        public DataContext(string connectionString) 
            => _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

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