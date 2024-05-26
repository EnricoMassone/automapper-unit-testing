using AutomapperUnitTestingSample.Mapping;
using AutomapperUnitTestingSample.Services;

namespace AutomapperUnitTestingSample
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.

      builder.Services.AddControllers();

      builder.Services.AddAutoMapper(typeof(StudentProfile));

      builder.Services.AddSingleton<ISerialNumberProvider, RandomSerialNumberProvider>();

      var app = builder.Build();

      // Configure the HTTP request pipeline.

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
    }
  }
}
