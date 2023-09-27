using G_Pigmy.App.LookUp;
using G_Pigmy.App.DataControl;
using GLib.Repository.Azure.TableStorage.Extensions;
using Azure.Data.Tables;
using GLib.Repository.Azure.TableStorage.Implementations;
using G_Pigmy.App.Validators;
using G_Pigmy.App.Mutation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("AzTableStorage");

if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Connection string is missing ...!");
}


builder.Services.AddAutoMapper(typeof(DataControlConfigurationService));
builder.Services.AddAutoMapper(typeof(ServiceCollectionExtensionLookUp));
builder.Services.AddAutoMapper(typeof(ServiceCollectionExtensionMutation));



builder.Services.AddServices<GLibRepositoryConfiguration, TableServiceClient>(connectionString);

builder.Services.AddDataControlServiceConfiguration();
builder.Services.AddLookUpServices();
builder.Services.AddMutation();
builder.Services.AddValidators();


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
