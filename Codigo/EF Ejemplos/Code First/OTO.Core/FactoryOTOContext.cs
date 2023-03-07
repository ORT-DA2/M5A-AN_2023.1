using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OTO.Library.Context;

namespace OTO.Core
{
    /// <summary>
    /// USER ESTO EN APLICACIONES DE CONSOLA SOLAMENTE!!!!!
    /// </summary>
    class FactoryOTOContext : IDesignTimeDbContextFactory<OTOContext>
    {
        // CONNECTION STRING
        // DOCKER
        // SI USO WINDOWS AUTH: Server={ACA PC NAME O SQLEXPRESS};Database=MTM;Trusted_Connection=True;
        public const string CONNECTION_STRING = "Server=localhost,11433;Database=OTO;User Id=sa;Password=yourStrong(!)Password";

        public OTOContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder build = new DbContextOptionsBuilder();
            build.UseSqlServer(CONNECTION_STRING);
            return new OTOContext(build.Options);
        }
    }
}
