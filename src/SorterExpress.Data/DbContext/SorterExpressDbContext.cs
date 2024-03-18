using Microsoft.EntityFrameworkCore;
using SorterExpress.Data.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SorterExpress.Data.DbContext
{
    public class SorterExpressDbContext(
        DbContextOptions<SorterExpressDbContext> options
    ) : Microsoft.EntityFrameworkCore.DbContext(options)
    {
        public DbSet<FileData> FileData { get; set; }

        private readonly JsonSerializerOptions jsonSerializerOptions = CreateJsonSerializerOptions();

        private static JsonSerializerOptions CreateJsonSerializerOptions()
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.Never,
                Converters =
                {
                    new JsonStringEnumConverter()
                },
            };
            return options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<FileData>()
                .Property(fi => fi.AutoClassificationWeights)
                .HasConversion(
                    v => Serialize(v),
                    v => Deserialize<AutoClassificationWeights>(v)
                );
        }

        private string Serialize<T>(T v)
        {
            return JsonSerializer.Serialize(v, jsonSerializerOptions);
        }

        private T Deserialize<T>(string v)
        {
            return JsonSerializer.Deserialize<T>(v, jsonSerializerOptions)!;
        }
    }
}