using NCAA.BLL;
using NFL.DAO;

namespace NFLApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<DivisionsDAO>();
            builder.Services.AddTransient<TeamsDAO>();
            builder.Services.AddTransient<ConferencesDAO>();
            builder.Services.AddTransient<StatesDAO>();

            builder.Services.AddTransient<TeamsBL>();
            builder.Services.AddTransient<ConferencesBL>();
            builder.Services.AddTransient<DivisionsBL>();
            builder.Services.AddTransient<StatesBL>();

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
        }
    }
}