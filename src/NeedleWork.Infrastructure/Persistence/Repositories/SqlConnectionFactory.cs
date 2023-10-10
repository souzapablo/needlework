using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NeedleWork.Infrastructure.Persistence.Repositories.Interfaces;

namespace NeedleWork.Infrastructure.Persistence.Repositories;
internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string  _connectionString;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("NeedleWorkCs")!;
    }

    public SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
