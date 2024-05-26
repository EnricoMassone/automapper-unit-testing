namespace AutomapperUnitTestingSample.Models
{
  public sealed class StudentDto
  {
    public string FullName { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public string SerialNumber { get; set; } = string.Empty;
  }
}
