using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
ConfigurationManager configuration = builder.Configuration;
ConfigureServices(builder.Services, configuration);
var app = builder.Build();

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<SmartContext>();
    context.Database.Migrate();
}

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapRazorPages();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
                   .UseSwaggerUI(options =>
                   {
                       foreach (var description in provider.ApiVersionDescriptions)
                       {
                           options.SwaggerEndpoint(
                               $"/swagger/{description.GroupName}/swagger.json",
                               description.GroupName.ToUpperInvariant());
                       }
                       options.RoutePrefix = "";
                   });
}
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();

void ConfigureServices(IServiceCollection services, ConfigurationManager Configuration)
{
    {
        services.AddDbContext<SmartContext>(
            ctx => ctx.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

        services.AddControllers();

        services.AddMvcCore().AddApiExplorer();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<IRepository, Repository>();

        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        })
        .AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        });

        var apiProviderDescription = services.BuildServiceProvider()
                                             .GetService<IApiVersionDescriptionProvider>();

        services.AddSwaggerGen(options =>
        {
            foreach (var description in apiProviderDescription.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "SmartSchool API",
                        Version = description.ApiVersion.ToString(),
                        TermsOfService = new Uri("http://SeusTermosDeUso.com"),
                        Description = "A descrição da WebAPI do SmartSchool",
                        License = new Microsoft.OpenApi.Models.OpenApiLicense
                        {
                            Name = "SmartSchool License",
                            Url = new Uri("http://mit.com")
                        },
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Junior Tristão",
                            Email = "",
                            Url = new Uri("https://github.com/juniortristao")
                        }
                    }
                );
            }

            //var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

            //options.IncludeXmlComments(xmlCommentsFullPath);
        });
        services.AddCors();
    }

}
