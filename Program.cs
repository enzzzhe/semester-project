var builder = WebApplication.CreateBuilder(args); // Создаем экземпляр WebApplicationBuilder для создания и конфигурации хоста приложения.

// Add services to the container.
builder.Services.AddControllersWithViews(); // Расширяем сервисы контейнера зависимостей, добавляя службу контроллеров MVC и представлений.

var app = builder.Build(); // Создаем экземпляр веб-приложения, используя конфигурацию, созданную с помощью WebApplicationBuilder.

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Устанавливаем обработчик исключений для перенаправления на страницу ошибки в случае исключения.
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts(); // Включаем использование HTTP Strict Transport Security (HSTS) для защиты приложения от атак.
}

app.UseHttpsRedirection(); // Включаем перенаправление с HTTP на HTTPS для безопасного соединения.
app.UseStaticFiles(); // Разрешаем использование статических файлов в приложении.

app.UseRouting(); // Включаем маршрутизацию запросов в приложении.
app.UseAuthorization(); // Включаем авторизацию для приложения.

app.MapControllerRoute( // Устанавливаем маршруты контроллера по умолчанию для обработки запросов к контроллерам и их действиям.
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Запускаем обработчик запросов приложения.
