using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MTM.Context
{
    /// <summary>
    /// USER ESTO EN APLICACIONES DE CONSOLA SOLAMENTE!!!!!
    /// </summary>
    class FactoryMTMContext : IDesignTimeDbContextFactory<MTMContext>
    {
        // CONNECTION STRING
        // DOCKER
        // SI USO WINDOWS AUTH: Server={ACA PC NAME O SQLEXPRESS};Database=MTM;Trusted_Connection=True;
        public const string CONNECTION_STRING = "Server=localhost,11433;Database=MTM;User Id=sa;Password=yourStrong(!)Password";

        public MTMContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder build = new DbContextOptionsBuilder();
            build.UseSqlServer(CONNECTION_STRING);
            build.UseLazyLoadingProxies(); // LAZY LOADING ENABLED
            return new MTMContext(build.Options);
        }
    }
}
