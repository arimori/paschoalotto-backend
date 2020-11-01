using System;

namespace backend.Models
{
  public class Portion
  {
    public Portion() { }
    public Portion(int id, decimal value, int overdueDays, int debtId)
    {
      this.id = id;
      this.value = value;
      this.overdueDays = overdueDays;
      this.debtId = debtId;
    }
    public int id { get; set; }
    public decimal value { get; set; }
    public int overdueDays { get; set; }
    public int debtId { get; set; }
  }
}