using System;
using System.Collections.Generic;
using csharp_lego_api.Models;
using csharp_lego_api.Repositories;

namespace csharp_lego_api.Services
{
  public class SetsService
  {
    private readonly SetsRepository _repo;
    public SetsService(SetsRepository sr)
    {
      _repo = sr;
    }

    internal IEnumerable<Set> GetAll()
    {
      return _repo.GetAll();
    }

    internal Set GetById(int id)
    {
      var found = _repo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal IEnumerable<Set> GetSetByBrickId(int brickId)
    {
      return _repo.GetSetByBrickId(brickId);
    }

    internal Set Create(Set newData)
    {
      _repo.Create(newData);
      return newData;
    }

    internal Set Edit(Set update)
    {
      var found = _repo.GetById(update.Id);
      if (found == null) { throw new Exception("Invalid Id"); }
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