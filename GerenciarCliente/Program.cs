

using Microsoft.EntityFrameworkCore;

namespace GerenciarCliente
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Conexao>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source = localhost; Persist Security Info = True; User ID = padrao; Password = 123456;TrustServerCertificate=True;")));
 
            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<ClienteDAO>();

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