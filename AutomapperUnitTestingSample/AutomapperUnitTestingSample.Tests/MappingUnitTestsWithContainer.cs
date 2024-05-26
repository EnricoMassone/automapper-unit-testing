using AutoMapper;
using AutomapperUnitTestingSample.Mapping;
using AutomapperUnitTestingSample.Models;
using AutomapperUnitTestingSample.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace AutomapperUnitTestingSample.Tests
{
  public sealed class MappingUnitTestsWithContainer : IDisposable
  {
    private readonly IMapper _sut;
    private readonly ServiceProvider _serviceProvider;
    private readonly Mock<ISerialNumberProvider> _mockSerialNumberProvider;

    public MappingUnitTestsWithContainer()
    {
      // init mock
      _mockSerialNumberProvider = new Mock<ISerialNumberProvider>();

      // configure services
      var services = new ServiceCollection();
      services.AddAutoMapper(typeof(StudentProfile));
      services.AddSingleton<ISerialNumberProvider>(_mockSerialNumberProvider.Object);

      // build service provider
      _serviceProvider = services.BuildServiceProvider();

      // create sut
      _sut = _serviceProvider.GetRequiredService<IMapper>();
    }

    [Fact]
    public void Mapper_Configuration_Is_Valid()
    {
      // ASSERT
      _sut.ConfigurationProvider.AssertConfigurationIsValid();
    }

    [Fact]
    public void Property_BirthDate_Is_Assigned_Right_Value()
    {
      // ARRANGE
      var student = new Student
      {
        FirstName = "Mario",
        LastName = "Rossi",
        Id = 1,
        BirthDate = new DateOnly(1980, 1, 5)
      };

      // ACT
      var result = _sut.Map<StudentDto>(student);

      // ASSERT
      Assert.NotNull(result);
      Assert.Equal(student.BirthDate, result.BirthDate);
    }

    [Fact]
    public void Property_FullName_Is_Assigned_Right_Value()
    {
      // ARRANGE
      var student = new Student
      {
        FirstName = "Mario",
        LastName = "Rossi",
        Id = 1,
        BirthDate = new DateOnly(1980, 1, 5)
      };

      // ACT
      var result = _sut.Map<StudentDto>(student);

      // ASSERT
      Assert.NotNull(result);
      Assert.Equal("Mario Rossi", result.FullName);
    }

    [Fact]
    public void Property_SerialNumber_Is_Set_By_Using_SetSerialNumberAction()
    {
      // ARRANGE
      var student = new Student
      {
        FirstName = "Mario",
        LastName = "Rossi",
        Id = 1,
        BirthDate = new DateOnly(1980, 1, 5)
      };

      // setup mock
      _mockSerialNumberProvider
        .Setup(m => m.GetSerialNumber())
        .Returns("serial-number-123");

      // ACT
      var result = _sut.Map<StudentDto>(student);

      // ASSERT
      Assert.NotNull(result);
      Assert.Equal("serial-number-123", result.SerialNumber);
    }

    public void Dispose()
    {
      _serviceProvider.Dispose();
    }
  }
}
