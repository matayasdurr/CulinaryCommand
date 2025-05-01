using System;

namespace CulinaryCommand.Models
{
    public enum StockLevel
    {
        Complete,
        Low,
        OutOfStock
    }

    public class OrderItem
{
  public int      Id          { get; set; }
  public string   Name        { get; set; } = string.Empty;  // ← default
  public DateTime LastOrdered { get; set; }
  public StockLevel Level     { get; set; }
}

}
