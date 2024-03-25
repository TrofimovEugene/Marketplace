using Marketplace.Context.EFCode;
using Marketplace.DTO.Repositories.Category;
using Marketplace.DTO.Repositories.GlobalCategory;
using Marketplace.DTO.Repositories.Subcategory;
using Marketplace.DTO.Services;
using Microsoft.EntityFrameworkCore;

namespace Marketplace
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

			var connection = builder.Configuration.GetConnectionString("DefaultConnection");

			builder.Services.AddDbContext<MarketplaceDbContext>(options => options.UseSqlServer(connection));

			builder.Services.AddScoped<IGlobalCategoryRepository, GlobalCategoryRepository>();
			builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>( );
			builder.Services.AddScoped<ISubcategoryRepository, SubcategoryRepository>( );

			builder.Services.AddScoped<ICategoriesService, CategoriesService>( );

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
