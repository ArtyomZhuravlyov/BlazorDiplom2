
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BlazorDiplom2.Data;
using Microsoft.Extensions.DependencyInjection;
using BlazorDiplom2.Areas.Identity.Pages.Account;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<DB>(options =>
//    options.UseSqlServer(connectionString));
//builder.Services.AddDbContext<DB>(options =>
//    options.UseSqlServer(connection));builder.Services.AddDefaultIdentity<AspNetUsers>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<DB>();
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<DB>();



//�������� ��������� �������� ������. .AddDefaultIdentity<AspNetUsers>
builder.Services.AddDefaultIdentity<AspNetUsers>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
}
).AddRoles<IdentityRole>().AddEntityFrameworkStores<DB>();

//builder.Services.AddIdentity<AspNetUsers, IdentityRole>(options => { 
//    options.SignIn.RequireConfirmedAccount = false;
//options.Password.RequiredLength = 6;
//options.Password.RequiredUniqueChars = 0;
//options.Password.RequireLowercase = false;
//options.Password.RequireUppercase = false;
//options.Password.RequireNonAlphanumeric = false;
//}
//).AddEntityFrameworkStores<DB>();      

builder.Services.AddDbContext<DB>(options => options.UseSqlServer(connection));//.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 25)))); //.UseSqlServer(connection));

//builder.Services.AddHttpContextAccessor();//cookies
builder.Services.AddHttpClient(); //для инпутфаил
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; }); ;
builder.Services.AddStorage();

builder.Services.AddSingleton<CompileService>();
//builder.Services.AddScoped<IRepository, SQLRepository>();

//builder.Services.AddSingleton<RegisterModel>();

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

app.UseAuthentication(); // <- Add this
app.UseAuthorization();  // <- Add this

//app.MapControllers();

app.MapRazorPages(); // <- Add this

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
