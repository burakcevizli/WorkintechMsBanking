
using MsBanking.Common.Dto;
using MsBanking.Core.Apis;
using MsBanking.Core.Domain;
using MsBanking.Core.Services;

namespace MsBanking.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<DatabaseOption>(builder.Configuration.GetSection("DatabaseOptions"));
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            //automapper
            builder.Services.AddAutoMapper(typeof(CustomerDtoProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapGroup("/api/v1/")
                .WithTags("Core Banking Api v1")
                .MapCustomerApi();


            app.UseHttpsRedirection();

            app.UseAuthorization();
          
            app.Run();
        }
    }
}
