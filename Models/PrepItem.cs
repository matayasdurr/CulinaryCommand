namespace CulinaryCommand.Models;

public enum PrepStatus { NotStarted, InProgress, Complete, NeedsOrder }

public class PrepItem
{
  public int    Id         { get; set; }
  public string Name       { get; set; } = string.Empty;    // ← default
  public string Category   { get; set; } = string.Empty;    // ← default
  public int    Par        { get; set; }
  public int    Count      { get; set; }
  public int    Prep       { get; set; }
  public string AssignedTo { get; set; } = string.Empty;    // ← default
  public PrepStatus Status { get; set; }
}
