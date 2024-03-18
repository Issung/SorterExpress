using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SorterExpress.Data.DbContext
{
    /// <summary>
    /// SorterExpress.Data is a separate project because the main project imports windows COM objects which .NET Core refuses to compile.<br/>
    /// Then because we're in our own project with no Startup.cs to setup DbContext options, we need this class to do so.<br/>
    /// Useful commands (every one must specify the data project):
    /// <list type="bullet">
    /// <item>dotnet ef migrations add NewMigrationName --project SorterExpress.Data</item>
    /// <item>dotnet ef migrations remove --project SorterExpress.Data</item>
    /// </list>
    /// </summary>
    public class Designer : IDesignTimeDbContextFactory<SorterExpressDbContext>
    {
        /// <summary>
        /// Ew.
        /// </summary>
        public static string PROGRAMDATA_PATH { get; } = "C:\\ProgramData\\SorterExpress\\SorterExpress\\0.3.0";

        public SorterExpressDbContext CreateDbContext(string[] args)
        {
            return CreateDbContext();
        }

        public static SorterExpressDbContext CreateDbContext()
        {
            var path = Path.Combine(PROGRAMDATA_PATH, "SorterExpress.db");
            var optionsBuilder = new DbContextOptionsBuilder<SorterExpressDbContext>();
            optionsBuilder.UseSqlite($"Data Source={path}");

            return new SorterExpressDbContext(optionsBuilder.Options);
        }
    }
}
