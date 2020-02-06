using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_lego_api.Models;
using csharp_lego_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace csharp_lego_api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BricksController : ControllerBase
  {
    private readonly BricksService _bs;
    private readonly SetsService _ss;
    public BricksController(BricksService bs, SetsService ss)
    {
      _bs = bs;
      _ss = ss;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Brick>> GetAll()
    {
      try
      {
        return Ok(_bs.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Brick> GetById(int id)
    {
      try
      {
        return Ok(_bs.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/sets")]
    public ActionResult<IEnumerable<Set>> GetSetByBrickId(int id)
    {
      try
      {
        return Ok(_ss.GetSetByBrickId(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Brick> Create([FromBody] Brick newData)
    {
      try
      {
        return Ok(_bs.Create(newData));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Brick> Edit([FromBody] Brick update, int id)
    {
      try
      {
        update.Id = id;
        return Ok(_bs.Edit(update));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
