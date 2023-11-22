namespace Program
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
    
            // Add services to the container.
            builder.Services.AddControllersWithViews();
    
            var app = builder.Build();
    
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
    
            app.UseHttpsRedirection();
            app.UseStaticFiles();
    
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "department",
                    pattern: "department/{action=Index}/{id?}",
                    defaults: new { controller = "Department" });

                endpoints.MapControllerRoute(
                    name: "faculty",
                    pattern: "faculty/{action=Index}/{id?}",
                    defaults: new { controller = "Faculty" });

                endpoints.MapDefaultControllerRoute();
            });

            app.UseAuthorization();
    
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
    
            app.Run();
        }
    }
}