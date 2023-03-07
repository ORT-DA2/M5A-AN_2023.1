using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OTM.Context
{
    /// <summary>
    /// USER ESTO EN APLICACIONES DE CONSOLA SOLAMENTE!!!!!
    /// </summary>
    class FactoryOTMContext : IDesignTimeDbContextFactory<OTMContext>
    {
        // CONNECTION STRING
        // DOCKER
        // SI USO WINDOWS AUTH: Server={ACA PC NAME O SQLEXPRESS};Database=MTM;Trusted_Connection=True;
        public const string CONNECTION_STRING = "Server=localhost,11433;Database=OTM;User Id=sa;Password=yourStrong(!)Password";

        public OTMContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder build = new DbContextOptionsBuilder();
            build.UseSqlServer(CONNECTION_STRING);
            return new OTMContext(build.Options);
        }
    }
}
