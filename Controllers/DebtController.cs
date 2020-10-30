using backend.Dtos.Debt;
using backend.Models;
using backend.Services.DebtService;
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

    [HttpGet("GetAll")]
    public async Task<IActionResult> Get()
    {
      return Ok(await _debtService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle(int id)
    {
      return Ok(await _debtService.GetDebtById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddDebtDto newDebt)
    {
      return Ok(await _debtService.AddDebt(newDebt));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateDebtDto updatedDebt)
    {
      ServiceResponse<GetDebtDto> response = await _debtService.UpdateDebt(updatedDebt);

      if (response.Data == null)
      {
        return NotFound(response);
      }

      return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      ServiceResponse<List<GetDebtDto>> response = await _debtService.DeleteDebt(id);

      if (response.Data == null)
      {
        return NotFound(response);
      }

      return Ok(response);
    }
  }
}