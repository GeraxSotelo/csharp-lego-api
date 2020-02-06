using System;
using System.Collections.Generic;
using csharp_lego_api.Models;
using csharp_lego_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace csharp_lego_api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BrickSetsController : ControllerBase
  {
    private readonly BrickSetsService _bss;
    public BrickSetsController(BrickSetsService bss)
    {
      _bss = bss;
    }

    [HttpPost]
    public ActionResult<String> Create([FromBody] BrickSet newData)
    {
      try
      {
        _bss.Create(newData);
        return Ok("Success");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("/removeBrick")]
    public ActionResult<String> Edit([FromBody] BrickSet bs)
    {
      try
      {
        return Ok(_bss.Delete(bs));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}