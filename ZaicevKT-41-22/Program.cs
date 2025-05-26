using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using ZaicevAntonKt_41_22.Database;
using ZaicevAntonKt_41_22.Interfaces;
using ZaicevAntonKt_41_22.Services;

var builder = WebApplication.CreateBuilder(args);   

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger(); 

try
{
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<PrepodDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddScoped<IDepartmentService, DepartmentService>();
    builder.Services.AddScoped<ITeacherService, TeacherService>();
    builder.Services.AddScoped<IAcademicDegreeService, AcademicDegreeService>();
    builder.Services.AddScoped<IPositionService, PositionService>();
    builder.Services.AddScoped<IDisciplineService, DisciplineService>();
    builder.Services.AddScoped<IWorkloadService, WorkloadService>();
   
   

    var app = builder.Build();
    
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();

    }
    app.UseAuthentication();
    app.MapControllers();
    app.Run();

}
catch(Exception ex)
{
    logger.Error(ex, "Stoped program because of exception");
}
finally
{
    LogManager.Shutdown();
}