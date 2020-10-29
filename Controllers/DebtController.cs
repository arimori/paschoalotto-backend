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

    [HttpGet("{codigo}")]
    public async Task<IActionResult> GetSingle(int id)
    {
      return Ok(await _debtService.GetDebtById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Add(Debt newDebt)
    {
      return Ok(await _debtService.AddDebt(newDebt));
    }
  }
}