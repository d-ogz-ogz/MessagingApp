using Angular_MessagingApp.Server;
using BUSINESS.Contracts;
using BUSINESS.hubs;
using BUSINESS.Implementtions;
using COMMON.interfaces;
using DATA.Db;
using DATA.Implemetations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(opt =>
{
    opt.Configuration = "localhost:6379";
    opt.InstanceName = "MyApp";
});
builder.Services.AddSignalR();

builder.Services.AddScoped<IUnitofWork, UnitOfWork>();
builder.Services.AddScoped<IUserEngine, UserEngine>();
builder.Services.AddScoped<IAuthEngine, AuthEngine>();
builder.Services.AddScoped<IChatEngine, ChatEngine>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IMessageEngine, MessageEngine>();
builder.Services.AddSingleton<MessagingAppDbContext>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseEndpoints(endpoints =>
endpoints.MapHub<ChatHub>("/chatHub"));
app.UseHttpsRedirection();
app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();
