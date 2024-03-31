using System;
using System.Security.AccessControl;
using System.Runtime.Intrinsics.X86;
using GameStore.Api.Entities;
using System.IO;
using System.Text;
using GameStore.Api.Endpoints;
using GameStore.Api.Repository;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>();
var app = builder.Build();

app.MapGamesEndpoints();


app.Run();
