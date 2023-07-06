using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ConnectionContext>();
builder.Services.AddScoped<IUser, UserRepo>();
builder.Services.AddScoped<ILogin, LoginRepo>();
builder.Services.AddScoped<IPatient, PatientRepo>();
builder.Services.AddScoped<IDoctor,DoctorRepo>();
builder.Services.AddScoped<IAppointment, AppointmentRepo>();
builder.Services.AddScoped<IAvailableDoctor, AvailableDoctorRepo>();



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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
