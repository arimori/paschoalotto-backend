using AutoMapper;
using backend.Dtos.Debt;
using backend.Models;

namespace backend
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Debt, GetDebtDto>();
      CreateMap<AddDebtDto, Debt>();
    }
  }
}