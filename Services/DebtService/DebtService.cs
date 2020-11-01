using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Models;

namespace backend.Services.DebtService
{
  public class DebtService : IDebtService
  {
    private static List<Debt> debts = new List<Debt> {
        new Debt{},
        new Debt{ id = 1 },
    };

    private static List<Portion> portions = new List<Portion>
    {
      new Portion{id = 2},
    };
    private readonly IMapper _mapper;

    public DebtService(IMapper mapper)
    {
      _mapper = mapper;
    }
    public async Task<ServiceResponse<List<Debt>>> AddDebt(Debt newDebt)
    {
      ServiceResponse<List<Debt>> serviceResponse = new ServiceResponse<List<Debt>>();

      Debt debt = _mapper.Map<Debt>(newDebt);
      debt.id = debts.Max(d => d.id) + 1;      

      debts.Add(debt);

      serviceResponse.Data = (debts.Select(c => _mapper.Map<Debt>(c))).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<Debt>>> DeleteDebt(int id)
    {
      ServiceResponse<List<Debt>> serviceResponse = new ServiceResponse<List<Debt>>();
      try
      {
        Debt debt = debts.First(d => d.id == id);
        debts.Remove(debt);

        serviceResponse.Data = (debts.Select(d => _mapper.Map<Debt>(d))).ToList();

      }
      catch (Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<Debt>>> GetAll()
    {
      ServiceResponse<List<Debt>> serviceResponse = new ServiceResponse<List<Debt>>();

      serviceResponse.Data = (debts.Select(d => _mapper.Map<Debt>(d))).ToList();

      return serviceResponse;
    }

    public async Task<ServiceResponse<Debt>> GetDebtById(int id)
    {
      ServiceResponse<Debt> serviceResponse = new ServiceResponse<Debt>();

      serviceResponse.Data = _mapper.Map<Debt>(debts.FirstOrDefault(debt => debt.id == id));

      return serviceResponse;
    }

    public async Task<ServiceResponse<Debt>> UpdateDebt(Debt updatedDebt)
    {
      ServiceResponse<Debt> serviceResponse = new ServiceResponse<Debt>();
      try
      {
        Debt debt = debts.FirstOrDefault(d => d.id == updatedDebt.id);
        debt.maxPortions = updatedDebt.maxPortions;
        debt.commissionPercentage = updatedDebt.commissionPercentage;
        debt.dueDate = updatedDebt.dueDate;
        debt.originalValue = updatedDebt.originalValue;
        debt.interestValue = updatedDebt.interestValue;
        debt.calculatedValue = updatedDebt.calculatedValue;
        debt.interestType = updatedDebt.interestType;
        debt.customerId = updatedDebt.customerId;
        debt.coworkerPhone = updatedDebt.coworkerPhone;
        debt.interestRate = updatedDebt.interestRate;
        debt.delayDays = updatedDebt.delayDays;

        serviceResponse.Data = _mapper.Map<Debt>(debt);
      }
      catch (Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
      return serviceResponse;

    }
  }
}