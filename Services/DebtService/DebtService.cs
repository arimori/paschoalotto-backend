using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Dtos.Debt;
using backend.Models;

namespace backend.Services.DebtService
{
  public class DebtService : IDebtService
  {
    private static List<Debt> debts = new List<Debt> {
        new Debt(),
        new Debt{ id = 1 },
    };
    private readonly IMapper _mapper;

    public DebtService(IMapper mapper)
    {
      _mapper = mapper;

    }
    public async Task<ServiceResponse<List<GetDebtDto>>> AddDebt(AddDebtDto newDebt)
    {
      ServiceResponse<List<GetDebtDto>> serviceResponse = new ServiceResponse<List<GetDebtDto>>();

      Debt debt = _mapper.Map<Debt>(newDebt);

      debt.id = debts.Max(d => d.id) + 1;

      debts.Add(debt);

      serviceResponse.Data = (debts.Select(c => _mapper.Map<GetDebtDto>(c))).ToList();

      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetDebtDto>>> DeleteDebt(int id)
    {
      ServiceResponse<List<GetDebtDto>> serviceResponse = new ServiceResponse<List<GetDebtDto>>();
      try
      {
        Debt debt = debts.First(d => d.id == id);
        debts.Remove(debt);

        serviceResponse.Data = (debts.Select(d => _mapper.Map<GetDebtDto>(d))).ToList();
      }
      catch (Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetDebtDto>>> GetAll()
    {
      ServiceResponse<List<GetDebtDto>> serviceResponse = new ServiceResponse<List<GetDebtDto>>();

      serviceResponse.Data = (debts.Select(d => _mapper.Map<GetDebtDto>(d))).ToList();

      return serviceResponse;
    }

    public async Task<ServiceResponse<GetDebtDto>> GetDebtById(int id)
    {
      ServiceResponse<GetDebtDto> serviceResponse = new ServiceResponse<GetDebtDto>();

      serviceResponse.Data = _mapper.Map<GetDebtDto>(debts.FirstOrDefault(debt => debt.id == id));

      return serviceResponse;
    }

    public async Task<ServiceResponse<GetDebtDto>> UpdateDebt(UpdateDebtDto updatedDebt)
    {
      ServiceResponse<GetDebtDto> serviceResponse = new ServiceResponse<GetDebtDto>();
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

        serviceResponse.Data = _mapper.Map<GetDebtDto>(debt);
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