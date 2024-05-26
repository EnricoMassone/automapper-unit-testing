using AutoMapper;
using AutomapperUnitTestingSample.Models;

namespace AutomapperUnitTestingSample.Mapping
{
  public sealed class StudentProfile : Profile
  {
    public StudentProfile()
    {
      CreateMap<Student, StudentDto>()
        .ForMember(
          studentDto => studentDto.FullName,
          options => options.MapFrom(student => $"{student.FirstName} {student.LastName}")
        )
        .ForMember(
          studentDto => studentDto.SerialNumber,
          options => options.Ignore()
        )
        .AfterMap<SetSerialNumberAction>();
    }
  }
}
