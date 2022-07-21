using ApiBooks.Repositories;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ApiBooks.DataAccess
{
    public class Repository<T> : IRepository<T> where T:class
    {
        protected string _connectionString;
        public Repository(string connectionString)
        {
            _connectionString = connectionString;
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{type.Name}"; };
        }
        public bool Delete(T entity)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Delete(entity);
            }
        }

        public T GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Get<T>(id);
            }
        }

        public IEnumerable<T> GetList()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.GetAll<T>();
            }
        }

        public int Insert(T entity)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return Convert.ToInt32(conn.Insert<T>(entity));
            }
        }

        public bool Update(T entity)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Update(entity);
            }
        }
    }
}
