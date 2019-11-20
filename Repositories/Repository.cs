using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Common;
using Dapper;

namespace Repositories
{
    public abstract class Repository<T>:IRepository<T>
    {

        private readonly string _connectionString;


        protected abstract string SelectAllQuery { get; }
        protected abstract string SelectQuery { get; }
        protected abstract string DeleteQuery { get; }
        protected abstract string InsertQuery { get; }
        protected abstract string UpdateQuery { get; }

        protected Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<T> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<T>(SelectAllQuery).ToList();
            }
        }

        public T Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<T>(SelectQuery, new { id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
              
                db.Execute(DeleteQuery, new { id });
            }
        }

        public int Add(T item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return  db.Query<int>(InsertQuery, item).FirstOrDefault();
             
            }
        }

        public void Update(T item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(UpdateQuery, item);
            }
        }
    }
}
