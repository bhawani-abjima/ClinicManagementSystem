using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ConnectionContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IPatientRegistrationRepository, PatientRegistrationRepository>();
builder.Services.AddScoped<IPatientPortalRepository,PatientPortalRepository>();
builder.Services.AddScoped<IDoctorRegistrationRepository,DoctorRegistrationRepository>();
builder.Services.AddScoped<IDoctorPortalRepository,DoctorPortalRepository>();
builder.Services.AddScoped<IAvailableDoctorDetailsRepository,AvailableDoctorDetailsRepository>();
builder.Services.AddScoped<IBookAppointmentRepository, BookAppointmentRepository>();
builder.Services.AddScoped<IPatientAppointmentDetails,PatientAppointmentDetailsRepository>();
builder.Services.AddScoped<IEditPatientDetailsRepository, EditPatientDetailsRepository>();
builder.Services.AddScoped<IEditDoctorDetailsRepository, EditDoctorDetailsRepository>();
builder.Services.AddScoped<IAppointmentRepository,AppointmentRepository>();
builder.Services.AddScoped<IEditAppointmentDetailsRepository,EditAppointmentDetailsRepository>();


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
