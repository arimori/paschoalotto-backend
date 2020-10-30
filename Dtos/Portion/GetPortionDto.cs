using System;
using backend.Models;

namespace backend.Dtos.Portion
{
  public class GetPortionDto
  {
    public int id { get; set; }
    public decimal portionValue { get; set; }
    public int overdueDays { get; set; }
    public int debtId { get; set; }
  }
}