using bootstrap_project.Data;
using bootstrap_project.Interfaces;
using bootstrap_project.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Добавление DbContext с PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавление сервисов для DI
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Настройка файлов cookie
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true; // Требуется подтверждение для использования файлов cookie
    options.MinimumSameSitePolicy = SameSiteMode.Strict; // Политика SameSite для предотвращения CSRF-атак
    options.Secure = CookieSecurePolicy.Always; // Требование для использования HTTPS для cookies
});

builder.Services.AddControllersWithViews();

// Добавляем валидацию через DataAnnotations
builder.Services.AddRazorPages().AddViewOptions(options => {
    options.HtmlHelperOptions.ClientValidationEnabled = true;
});

var app = builder.Build();

// Добавление обработки ошибок
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Вывод страницы ошибок для разработки
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Включение использования политики cookies
app.UseCookiePolicy();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Order}/{action=Index}/{id?}");

app.Run();







