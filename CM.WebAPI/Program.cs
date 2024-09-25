using CM.bll.Services;
using CM.Core.Infra.Repos;
using CM.Core.Services;
using CM.Repo;
using Microsoft.EntityFrameworkCore;

namespace CM.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CMDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddTransient<IUow, Uow>();
            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IContactRepo, ContactRepo>();

            builder.Services.AddScoped<IContactTypeService, ContactTypeService>();
            builder.Services.AddScoped<IContactTypeRepo, ContactTypeRepo>();

            builder.Services.AddScoped<IContactGroupService, ContactGroupService>();
            builder.Services.AddScoped<IContactGroupRepo, ContactGroupRepo>();


            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
