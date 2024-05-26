using AutoMapper;
using AutomapperUnitTestingSample.Models;
using AutomapperUnitTestingSample.Services;

namespace AutomapperUnitTestingSample.Mapping
{
  public sealed class SetSerialNumberAction : IMappingAction<Student, StudentDto>
  {
    private readonly ISerialNumberProvider _serialNumberProvider;

    public SetSerialNumberAction(ISerialNumberProvider serialNumberProvider)
    {
      _serialNumberProvider = serialNumberProvider ?? throw new ArgumentNullException(nameof(serialNumberProvider));
    }

    public void Process(Student source, StudentDto destination, ResolutionContext context)
    {
      ArgumentNullException.ThrowIfNull(destination);

      destination.SerialNumber = _serialNumberProvider.GetSerialNumber();
    }
  }
}
