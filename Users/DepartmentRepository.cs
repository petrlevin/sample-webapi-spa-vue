using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Common;
using Dapper;

namespace Repositories
{
    public class DepartmentRepository : Repository<Department>
    {

        public DepartmentRepository(string connectionString) :base(connectionString)
        {
        }

        protected override string SelectAllQuery => "SELECT * FROM dbo.Departments";
        protected override string SelectQuery => "SELECT* FROM dbo.Departments WHERE Id = @id";
        protected override string DeleteQuery => "DELETE FROM dbo.Departments WHERE Id = @id";
        protected override string InsertQuery => "INSERT INTO dbo.Departments  (Title) VALUES( @Title); SELECT CAST(SCOPE_IDENTITY() as int)";
        protected override string UpdateQuery => "UPDATE dbo.Departments SET Title = @Title WHERE Id = @Id";


    }
}
