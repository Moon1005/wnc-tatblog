using TatBlog.WebApi.Endpoints;
using TatBlog.WebApi.Extensions;
using TatBlog.WebApi.Mapsters;
using TatBlog.WebApi.Validations;

var builder = WebApplication.CreateBuilder(args);
{
	builder.ConfigureCors()
		.ConfigureNLog()
		.ConfigureServices()
		.ConfigureSwaggerOpenApi()
		.ConfigureMapster()
		.ConfigureFluentValidation();
}

var app = builder.Build();
{
	//Configure the Http request pipeline
	app.SetupRequestPipeline();

	//Configure API endpoints
	app.MapAuthorEndpoints();

	app.Run();
}