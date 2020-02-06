using System;
using System.Collections.Generic;
using csharp_lego_api.Models;
using csharp_lego_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace csharp_lego_api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SetsController : ControllerBase
  {
    private readonly SetsService _ss;
    public SetsController(SetsService ss)
    {
      _ss = ss;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Set>> GetAll()
    {
      try
      {
        return Ok(_ss.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Set> GetById(int id)
    {
      try
      {
        return Ok(_ss.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Set> Create([FromBody] Set newData)
    {
      try
      {
        return Ok(_ss.Create(newData));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Set> Edit([FromBody] Set update, int id)
    {
      try
      {
        update.Id = id;
        return Ok(_ss.Edit(update));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        return Ok(_ss.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}