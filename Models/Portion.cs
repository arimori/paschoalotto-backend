using System;

namespace backend.Models
{
  public class Portion
  {
    public Portion() { }
    public Portion(int id, decimal portionValue, int overdueDays, int debtId)
    {
      this.id = id;
      this.portionValue = portionValue;
      this.overdueDays = overdueDays;
      this.debtId = debtId;
    }
    public int id { get; set; }
    public decimal portionValue { get; set; }
    public int overdueDays { get; set; }
    public int debtId { get; set; }
  }
}