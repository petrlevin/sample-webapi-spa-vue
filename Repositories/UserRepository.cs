using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Common;
using Dapper;

namespace Repositories
{
    public class UserRepository : Repository<User>
    {

        public UserRepository(string connectionString) :base(connectionString)
        {
        }

        protected override string SelectAllQuery => "SELECT * FROM dbo.Users";
        protected override string SelectQuery => "SELECT* FROM dbo.Users WHERE Id = @id";
        protected override string DeleteQuery => "DELETE FROM dbo.Users WHERE Id = @id";
        protected override string InsertQuery => "INSERT INTO dbo.Users (DepartmentId, UserName) VALUES(@DepartmentId, @UserName); SELECT CAST(SCOPE_IDENTITY() as int)";
        protected override string UpdateQuery => "UPDATE dbo.Users SET DepartmentId = @DepartmentId, UserName = @UserName WHERE Id = @Id";


    }
}
