using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.EntityFrameworkCore;

// Инициализация билдера для веб-приложения
var builder = WebApplication.CreateBuilder(args);

// Добавление сервисов в контейнер. 
builder.Services.AddControllersWithViews();

// Добавление контекста базы данных и конфигурация его для использования SQL Server.
// Строка подключения берется из конфигурационного файла.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрация сервисов. Указываем, что при запросе IActorsServices следует предоставлять экземпляр ActorsService.
builder.Services.AddScoped<IActorsServices, ActorsService>();

// Сборка приложения.
var app = builder.Build();

// Конфигурация конвейера обработки HTTP-запросов.
// Если приложение не в режиме разработки...
if (!app.Environment.IsDevelopment())
{
    // Использовать обработчик исключений для пользовательских ошибок.
    app.UseExceptionHandler("/Home/Error");
    // Использовать HSTS (Strict Transport Security) для безопасности.
    app.UseHsts();
}

// Принудительное использование HTTPS.
app.UseHttpsRedirection();
// Разрешить обслуживание статических файлов (например, изображений, CSS, JavaScript).
app.UseStaticFiles();

// Использовать маршрутизацию.
app.UseRouting();

// Применить авторизацию к приложению.
app.UseAuthorization();

// Конфигурация маршрута по умолчанию для контроллеров.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

// Инициализация базы данных начальными данными.
ApplicationDbInitializer.Seed(app);

// Запуск приложения.
app.Run();