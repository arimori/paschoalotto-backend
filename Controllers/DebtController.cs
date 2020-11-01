using backend.Models;
using backend.Services.DebtService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class DebtController : ControllerBase
  {
    private readonly IDebtService _debtService;
    public DebtController(IDebtService debtService)
    {
      _debtService = debtService;
    }
    
    [EnableCors("AllowAnyOrigin")]
    [HttpGet("GetAll")]    
    public async Task<IActionResult> Get()
    {
      return Ok(await _debtService.GetAll());
    }

    [EnableCors("AllowAnyOrigin")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle(int id)
    {
      return Ok(await _debtService.GetDebtById(id));
    }

    [EnableCors("AllowAnyOrigin")]
    [HttpPost]
    public async Task<IActionResult> Add(Debt newDebt)
    {
      return Ok(await _debtService.AddDebt(newDebt));
    }

    [EnableCors("AllowAnyOrigin")]
    [HttpPut]
    public async Task<IActionResult> Update(Debt updatedDebt)
    {
      ServiceResponse<Debt> response = await _debtService.UpdateDebt(updatedDebt);

      if (response.Data == null)
      {
        return NotFound(response);
      }

      return Ok(response);
    }

    [EnableCors("AllowAnyOrigin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      ServiceResponse<List<Debt>> response = await _debtService.DeleteDebt(id);

      if (response.Data == null)
      {
        return NotFound(response);
      }

      return Ok(response);
    }
  }
}