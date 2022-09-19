using CardProject.Api.Infrastructure.Extensions;
using CardProject.Bl.Services.Implementations.Card.Debit;
using CardProject.Bl.Services.Interfaces.Card.Debit;
using CardProject.Data.Config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddSingleton<DbContext,CardProjectDataContext>();
services.ConfigureServices();
services.ConfigureRepositories();
services.ConfigureHelpers();

var app = builder.Build();

app.ConfigureMapping();
app.Run();
