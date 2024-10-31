using bootstrap_project.Data;
using bootstrap_project.Interfaces;
using bootstrap_project.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ���������� DbContext � PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ���������� �������� ��� DI
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// ��������� ������ cookie
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true; // ��������� ������������� ��� ������������� ������ cookie
    options.MinimumSameSitePolicy = SameSiteMode.Strict; // �������� SameSite ��� �������������� CSRF-����
    options.Secure = CookieSecurePolicy.Always; // ���������� ��� ������������� HTTPS ��� cookies
});

builder.Services.AddControllersWithViews();

// ��������� ��������� ����� DataAnnotations
builder.Services.AddRazorPages().AddViewOptions(options => {
    options.HtmlHelperOptions.ClientValidationEnabled = true;
});

var app = builder.Build();

// ���������� ��������� ������
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // ����� �������� ������ ��� ����������
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ��������� ������������� �������� cookies
app.UseCookiePolicy();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Order}/{action=Index}/{id?}");

app.Run();







