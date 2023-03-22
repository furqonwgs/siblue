using HR_Service.Data;
using HR_Service.Models.Enitty;
using HR_Service.Services.Positions.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HR_Service.Controllers.Positions;

[Route("api/[controller]")]
[ApiController]
public class PositionController : ControllerBase
{
  private readonly IPosition _position;

  public PositionController(IPosition position)
  {
    _position = position;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<Position>>> GetPostions()
  {
    try
    {
      return Ok(await _position.GetAll());
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Position>> GetPosition(Guid id)
  {
    try
    {
      return Ok(await _position.GetById(id));
    }
    catch (System.Exception)
    {

      return NotFound();
    }
  }
  [HttpPost]
  public async Task<ActionResult<Position>> PostPosition([FromBody] PositionInput input)
  {
    try
    {
      var result = await _position.Insert(input);
      return Created("GetPosition", result);
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPut("{id}")]
  public async Task<ActionResult<Position>> PutPosition(Guid id, [FromBody] PositionInput input)
  {
    try
    {
      await _position.Update(id, input);
      return Ok();
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPut("updateStatus/{id}")]
  public async Task<ActionResult<Position>> PutStatus(Guid id, [FromBody] bool is_active)
  {
    try
    {
      await _position.UpdateStatus(id, is_active);
      return Ok();
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }






}