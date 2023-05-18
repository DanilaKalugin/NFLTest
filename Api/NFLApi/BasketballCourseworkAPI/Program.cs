using System.Text;
using Coursework.BLL;
using Coursework.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CourseworkApi
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

            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            builder.Services.AddDbContext<CourseworkApplicationContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddTransient<DivisionsDAO>();
            builder.Services.AddTransient<TeamsDAO>();
            builder.Services.AddTransient<ConferencesDAO>();
            builder.Services.AddTransient<StatesDAO>();
            builder.Services.AddTransient<UserDAO>();
            builder.Services.AddTransient<MatchesDAO>();
            builder.Services.AddTransient<StadiumsDAO>();

            builder.Services.AddTransient<TeamsBL>();
            builder.Services.AddTransient<ConferencesBL>();
            builder.Services.AddTransient<DivisionsBL>();
            builder.Services.AddTransient<StatesBL>();
            builder.Services.AddTransient<UserBL>();
            builder.Services.AddTransient<MatchesBL>();
            builder.Services.AddTransient<TicketsBL>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthentication();

            app.UseCors("MyPolicy");
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}