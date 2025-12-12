var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseExceptionHandler("/Home/Error");
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.Run();
