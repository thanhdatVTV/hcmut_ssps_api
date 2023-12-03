using HCMUT_SSPS.Interfaces;
using HCMUT_SSPS.Models;
using HCMUT_SSPS.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFileTypeRepository, FileTypeRepository>();
builder.Services.AddScoped<IPageSizeRepository, PageSizeRepository>();
builder.Services.AddScoped<IPrinterRepository, PrinterRepository>();
builder.Services.AddScoped<IPagePurchaseRepository, PagePurchaseRepository>();
builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>
{
    //build.WithOrigins("http://localhost:3000/");
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HcmutSspsContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("MyCors");
app.MapControllers();

app.Run();
