using System;
using System.Collections.Generic;
using csharp_lego_api.Models;
using csharp_lego_api.Repositories;

namespace csharp_lego_api.Services
{
  public class BricksService
  {
    private readonly BricksRepository _repo;
    public BricksService(BricksRepository br)
    {
      _repo = br;
    }
    internal IEnumerable<Brick> GetAll()
    {
      return _repo.GetAll();
    }

    internal Brick GetById(int id)
    {

      var found = _repo.GetById(id);
      if (found == null) { throw new Exception("Invalid Id"); }
      return found;
    }

    internal Brick Create(Brick newData)
    {
      _repo.Create(newData);
      return newData;
    }

    internal Brick Edit(Brick update)
    {
      var found = _repo.GetById(update.Id);
      if (found == null) { throw new Exception("Invalid Id bro"); }
      //update.AuthorId = found.AuthorId;
      _repo.Edit(update);
      return update;
    }

    internal String Delete(int id)
    {
      var found = _repo.GetById(id);
      if (found == null) { throw new Exception("Invalid Id"); }
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}