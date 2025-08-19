
using Microsoft.EntityFrameworkCore;
using MovieSystem.Infrastructure.Data;

namespace MovieSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MovieSystemContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();

        }
    }
}
