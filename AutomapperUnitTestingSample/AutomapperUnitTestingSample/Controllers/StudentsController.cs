using AutoMapper;
using AutomapperUnitTestingSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace AutomapperUnitTestingSample.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class StudentsController : ControllerBase
  {
    private static readonly ImmutableArray<Student> s_students =
    [
      new Student { Id = 1, BirthDate = new DateOnly(1988, 2, 6), FirstName = "Bob", LastName = "Brown" },
      new Student { Id = 2, BirthDate = new DateOnly(1991, 8, 4), FirstName = "Alice", LastName = "Red" },
    ];

    private readonly IMapper _mapper;

    public StudentsController(IMapper mapper)
    {
      _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<StudentDto> Get()
    {
      return s_students
        .Select(_mapper.Map<StudentDto>)
        .ToArray();
    }
  }
}
