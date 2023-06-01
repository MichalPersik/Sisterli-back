using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using SisterliBL;
using SisterliBL.FuncClass;
using SisterliBL.FuncInterface;
using SisterLiDAL;
using SisterLiDAL.FuncClass;
using SisterLiDAL.FuncInterface;
using SisterliDTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IUserDAL), typeof(UserDAL));
builder.Services.AddScoped(typeof(IUserBL), typeof(UserBL));
builder.Services.AddScoped(typeof(IMomBL), typeof(MomBL));
builder.Services.AddScoped(typeof(IMomDAL), typeof(MomDAL));
builder.Services.AddScoped(typeof(IBabysiterBL), typeof(BabysiterBL));
builder.Services.AddScoped(typeof(IBabySitterDAL), typeof(BabySitterDAL));
builder.Services.AddScoped(typeof(IRequestBL), typeof(RequestBL));
builder.Services.AddScoped(typeof(IRequestDAL), typeof(RequestDAL));
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));


builder.Services.AddControllers();


builder.Services.AddAutoMapper(typeof(SisterliAutoMapper));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

