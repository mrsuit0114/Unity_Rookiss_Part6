using BlazorApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//Dependency Injection
builder.Services.AddSingleton<IFoodService, FoodService>();
// 생성자에서 알아서 연결해준다..?
builder.Services.AddSingleton<PaymentService>();

// 3가지 모드
// Singleton  -  서버를 껐다 키지 않는이상 고정
// Transient  -  요청마다 변함
// Scoped  -  둘의 중간, 새로고침은 변경인데, 다른 탭을 이용하는 과정에서는 안변함

var app = builder.Build();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
