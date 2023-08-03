// MVC
// Model  -  ������
// View  -  UI
// Controller  -  �����͸� ��� ����


// Razor Pages
// M
// VC
// M - V - VM

// WebAPI
// M
// C

var builder = WebApplication.CreateBuilder(args);

//����
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//����
app.MapRazorPages();


app.Run();
