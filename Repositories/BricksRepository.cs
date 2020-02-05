using System;
using System.Collections.Generic;
using System.Data;
using csharp_lego_api.Models;
using Dapper;

namespace csharp_lego_api.Repositories
{
  public class BricksRepository
  {
    private readonly IDbConnection _db;
    public BricksRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Brick> GetAll()
    {
      string sql = "SELECT * FROM bricks";
      return _db.Query<Brick>(sql);
    }

    internal Brick GetById(int id)
    {
      string sql = "SELECT * FROM bricks WHERE id = @id";
      return _db.QueryFirstOrDefault<Brick>(sql, new { id });
    }

    internal Brick Create(Brick newData)
    {
      string sql = @"
      INSERT INTO bricks (name, price)
      VALUES (@Name, @Price);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newData);
      newData.Id = id;
      return newData;
    }
  }
}