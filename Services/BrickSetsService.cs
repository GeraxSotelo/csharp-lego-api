using System;
using csharp_lego_api.Models;
using csharp_lego_api.Repositories;

namespace csharp_lego_api.Services
{
  public class BrickSetsService
  {
    private readonly BrickSetsRepository _repo;
    public BrickSetsService(BrickSetsRepository bsr)
    {
      _repo = bsr;
    }
    internal void Create(BrickSet newData)
    {
      BrickSet exists = _repo.Find(newData);
      if (exists != null) { throw new Exception("Brick already part of set."); }
      _repo.Create(newData);
    }

    internal string Delete(BrickSet bs)
    {
      BrickSet exists = _repo.Find(bs);
      if (bs == null) { throw new Exception("Invalid Id Combination"); }
      _repo.Delete(bs.Id);
      return "Successfully Deleted";
    }
  }
}