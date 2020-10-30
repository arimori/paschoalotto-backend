using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Dtos.Debt;
using backend.Models;

namespace backend.Services.DebtService
{
  public interface IDebtService
  {
    Task<ServiceResponse<List<GetDebtDto>>> GetAll();
    Task<ServiceResponse<GetDebtDto>> GetDebtById(int id);
    Task<ServiceResponse<List<GetDebtDto>>> AddDebt(AddDebtDto newDebt);
    Task<ServiceResponse<GetDebtDto>> UpdateDebt(UpdateDebtDto updatedDebt);
    Task<ServiceResponse<List<GetDebtDto>>> DeleteDebt(int id);

  }
}