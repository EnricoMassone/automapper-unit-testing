using AutoMapper;
using AutomapperUnitTestingSample.Mapping;
using AutomapperUnitTestingSample.Models;

namespace AutomapperUnitTestingSample.Tests
{
  public sealed class MappingUnitTests
  {
    private readonly MapperConfiguration _configuration;
    private readonly IMapper _sut;

    public MappingUnitTests()
    {
      _configuration = new MapperConfiguration(config =>
      {
        config.AddProfile<StudentProfile>();
      });

      _sut = _configuration.CreateMapper();
    }

    [Fact]
    public void Mapper_Configuration_Is_Valid()
    {
      // ASSERT
      _configuration.AssertConfigurationIsValid();
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
  }
}