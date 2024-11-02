using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EliteAthleteApp.Configurations;
using EliteAthleteApp.Configurations.Entities;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;
using EliteAthleteApp.Repositories;
using EliteAthleteApp.Services;
using EliteAthleteApp.Contracts.Services;
using EliteAthleteApp.Contracts.Repositories;
using Microsoft.Build.Execution;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DataBaseConnectionString") ?? throw new InvalidOperationException("Connection string 'DataBaseConnectionString' not found.");
string blobConnectionString = builder.Configuration.GetConnectionString("BlobConnectionString");
string sendGridConnectionString = builder.Configuration.GetConnectionString("SendGridConnectionString");

string blobContainerExerciseImage = builder.Configuration.GetSection("ContainerNames")["BlobContainerExerciseImage"];
string blobContainerExerciseVideo = builder.Configuration.GetSection("ContainerNames")["BlobContainerExerciseVideo"];
string blobContainerUserImage = builder.Configuration.GetSection("ContainerNames")["BlobContainerUserImage"];
string blobContainerMedicalTestImage = builder.Configuration.GetSection("ContainerNames")["BlobContainerMedicalTestImage"];
string blobContainerBodyAnalysisImage = builder.Configuration.GetSection("ContainerNames")["BlobContainerBodyAnalysisImage"];

string sendFromEmailAddress = builder.Configuration.GetValue<string>("Email");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddRoles<IdentityRole>() 
	.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserBodyMeasurementsRepository, UserBodyMeasurementsRepository>();
builder.Services.AddScoped<IUserMedicalTestRepository, UserMedicalTestRepository>();
builder.Services.AddScoped<IUserBodyAnalysisRepository, UserBodyAnalysisRepository>();

builder.Services.AddScoped<ITrainingExerciseRepository, TrainingExerciseRepository>();
builder.Services.AddScoped<ITrainingExerciseMediaRepository, TrainingExerciseMediaRepository>();
builder.Services.AddScoped<ITrainingExerciseCategoryRepository, TrainingExerciseCategoryRepository>();
builder.Services.AddScoped<ITrainingExerciseMuscleGroupRepository, TrainingExerciseMuscleGroupRepository>();

builder.Services.AddScoped<ITrainingPlanRepository, TrainingPlanRepository>();
builder.Services.AddScoped<ITrainingPlanExerciseDetailRepository, TrainingPlanExerciseDetailRepository>();
builder.Services.AddScoped<ITrainingPlanPhaseRepository, TrainingPlanPhaseRepository>();

builder.Services.AddScoped<ITrainingModuleRepository, TrainingModuleRepository>();
builder.Services.AddScoped<ITrainingOrmRepository, TrainingOrmRepository>();

builder.Services.AddScoped<IBlobStorageService, BlobStorageService>(provider =>	new BlobStorageService(blobConnectionString, blobContainerExerciseImage, blobContainerExerciseVideo, blobContainerUserImage, blobContainerMedicalTestImage, blobContainerBodyAnalysisImage));
builder.Services.AddScoped<IPdfService, PdfService>();
builder.Services.AddScoped<IYoutubeService, YoutubeService>();

builder.Services.AddTransient<IEmailSender, EmailSenderService>(provider => new EmailSenderService(sendGridConnectionString, sendFromEmailAddress));

builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
