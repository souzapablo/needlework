using Microsoft.Data.SqlClient;

namespace NeedleWork.Infrastructure.Persistence.Repositories.Interfaces;
public interface ISqlConnectionFactory
{
    SqlConnection CreateConnection();
}
