namespace AutomapperUnitTestingSample.Services
{
  public sealed class RandomSerialNumberProvider : ISerialNumberProvider
  {
    public string GetSerialNumber() => $"Serial-Number-{Random.Shared.Next()}";
  }
}
