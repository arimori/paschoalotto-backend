using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services.DebtService
{
  public interface IDebtService
  {
    Task<ServiceResponse<List<Debt>>> GetAll();
    Task<ServiceResponse<Debt>> GetDebtById(int id);
    Task<ServiceResponse<List<Debt>>> AddDebt(Debt newDebt);

  }
}