using SimpleHotelApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<RoomService>();
builder.Services.AddSingleton<GuestService>();
builder.Services.AddSingleton<BookingService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Room}/{action=Index}/{id?}");

app.Run();
