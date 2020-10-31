using AutoMapper;
using backend.Models;

namespace backend
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Debt, Debt>();
    }
  }
}