using System;
using System.Data;
using csharp_lego_api.Models;
using Dapper;

namespace csharp_lego_api.Repositories
{
  public class BrickSetsRepository
  {
    private readonly IDbConnection _db;
    public BrickSetsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal BrickSet Find(BrickSet newData)
    {
      string sql = @"
      SELECT * FROM bricksets
      WHERE (brickId = @BrickId AND setId = @SetId)";
      return _db.QueryFirstOrDefault<BrickSet>(sql, newData);
    }

    internal BrickSet Create(BrickSet newData)
    {
      string sql = @"
      INSERT INTO bricksets (brickId, setId)
      VALUES (@BrickId, @SetId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newData);
      newData.Id = id;
      return newData;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM bricksets WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}