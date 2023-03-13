using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Quartz;
using System.Configuration;
using WebApiTesting.Models;
using static WebApiTesting.Schedular.BirthdayNotiSchedular;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<ApiTestingContext>(opt =>
//    opt.UseInMemoryDatabase("BirthdayInfoList"));
builder.Services.AddDbContext<ApiTestingContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionScopedJobFactory();
    // Just use the name of your job that you created in the Jobs folder.
    var jobKey = new JobKey("BirthdayNoti");
    q.AddJob<BirthdayNoti>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("BirthdayNoti-trigger")
        //This Cron interval can be described as "run every minute" (when second is zero)
        .WithCronSchedule("0 * * ? * *")
    );
});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
