using Microsoft.EntityFrameworkCore;
using PetStore.Data;
using PetStore.Models;
using PetStore.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<PetContext>(options => options.UseLazyLoadingProxies().UseSqlite(connectionString));
builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Default", "{controller=Animals}/{action=HomePage}/{id?}");

});

app.Run();
