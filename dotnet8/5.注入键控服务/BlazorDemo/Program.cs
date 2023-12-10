using BlazorDemo;
using BlazorDemo.Components;
using BlazorDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddKeyedScoped<MyDemoSrv>("VIP", (sp, key) => new MyDemoSrv("VIP"));
builder.Services.AddKeyedScoped<MyDemoSrv>("Customer", (sp, key) => new MyDemoSrv("Customer"));

#region

var readOptions = new DbContextOptionsBuilder<EFDemoContext>()
    .UseSqlServer(builder.Configuration.GetConnectionString("Read")).Options;
builder.Services.AddKeyedScoped<EFDemoContext>("Read", (sp, key) => new EFDemoContext(readOptions));

var writeOptions = new DbContextOptionsBuilder<EFDemoContext>()
    .UseSqlServer(builder.Configuration.GetConnectionString("Write")).Options;
builder.Services.AddKeyedScoped<EFDemoContext>("Write", (sp, key) => new EFDemoContext(writeOptions));


#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler("/Error", createScopeForErrors: true);
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
