using System;
using System.Collections.Generic;
using System.Data;
using csharp_lego_api.Models;
using Dapper;

namespace csharp_lego_api.Repositories
{
  public class SetsRepository
  {
    private readonly IDbConnection _db;
    public SetsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Set> GetAll()
    {
      string sql = "SELECT * FROM bsets";
      return _db.Query<Set>(sql);
    }

    internal Set GetById(int id)
    {
      string sql = "SELECT * FROM bsets WHERE id = @id";
      return _db.QueryFirstOrDefault<Set>(sql, new { id });
    }

    internal Set Create(Set newData)
    {
      string sql = @"
      INSERT INTO bsets (name, price)
      VALUES (@Name, @Price);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newData);
      newData.Id = id;
      return newData;
    }

    internal void Edit(Set update)
    {
      string sql = @"
      UPDATE bsets
      SET name = @Name, price = @Price
      WHERE id = @Id";
      _db.Execute(sql, update);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM bsets WHERE id = @id";
      _db.Execute(sql, new { id });
    }

  }
}