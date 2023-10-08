using APINewG.Entities;
using APINewG.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
//    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddCors(p => p.AddPolicy("MyCors", build => {
    build.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
}));
builder.Services.AddDbContext<testpbldbContext>(option => option.UseSqlServer
    (builder.Configuration.GetConnectionString("MyAzureConnection")));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseSwagger();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
