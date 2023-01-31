using Bulletinboard.CommonLibrary;
using Bulletinboard.Back.DataAccess;
using Bulletinboard.Back.WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

APISetting.Configuration = app.Configuration;

CommonSetting.BulletinboardConnectString = iConvert.ToString(app.Configuration.GetValue(typeof(string),APISetting.KEY_CONNECTSTR));
CommonSetting.PackageConnectSting = iConvert.ToString(app.Configuration.GetValue(typeof(string),APISetting.KEY_CONNECTSTR_PACKAGE));
CommonSetting.LogOutputDirectory = iConvert.ToString(app.Configuration.GetValue(typeof(string),APISetting.KEY_LOGDIRECTORY));
CommonSetting.Log = new iLog(180,CommonSetting.LogOutputDirectory);

// Configure the HTTP request pipeline.
app.UseAuthorization();
app.MapControllers();

app.Run();
