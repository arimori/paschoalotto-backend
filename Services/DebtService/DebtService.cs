using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services.DebtService
{
  public class DebtService : IDebtService
  {
    private static List<Debt> debts = new List<Debt> {
        new Debt(),
        new Debt{ id = 1 },
    };
    public async Task<ServiceResponse<List<Debt>>> AddDebt(Debt newDebt)
    {
      ServiceResponse<List<Debt>> serviceResponse = new ServiceResponse<List<Debt>>();

      debts.Add(newDebt);

      serviceResponse.Data = debts;

      return serviceResponse;
    }

    public async Task<ServiceResponse<List<Debt>>> GetAll()
    {
      ServiceResponse<List<Debt>> serviceResponse = new ServiceResponse<List<Debt>>();

      serviceResponse.Data = debts;

      return serviceResponse;
    }

    public async Task<ServiceResponse<Debt>> GetDebtById(int id)
    {
      ServiceResponse<Debt> serviceResponse = new ServiceResponse<Debt>();

      serviceResponse.Data = debts.FirstOrDefault(debt => debt.id == id);

      return serviceResponse;
    }
  }
}