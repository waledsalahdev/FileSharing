using FileSharing.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Creat Service Container for Add Identuty 
// By add Two Packadge MicIdentityCore + IDentity FrameWork 
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddMvc().AddNToastNotifyToastr( new ToastrOptions    
{
    ProgressBar = true,
PositionClass = ToastPositions.TopRight,
PreventDuplicates = true,
CloseButton=true,

TimeOut=2000,
});
builder.Services.AddDbContext<AppDbContext>(options =>
    {

        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));


    });
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
app.UseNToastNotify();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
