using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EliteAthleteApp.Configurations;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;
using EliteAthleteApp.Repositories;
using EliteAthleteApp.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnectionString") ?? throw new InvalidOperationException("Connection string 'DataBaseConnectionString' not found.");
string sendGridConnectionString = builder.Configuration.GetConnectionString("SendGridConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddRoles<IdentityRole>() 
	.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserChartService, UserChartService>();

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


builder.Services.AddScoped<IGoogleDriveService, GoogleDriveService>(provider =>
{
	// Przeka¿ je do konstruktora GoogleDriveService
	return new GoogleDriveService(
		builder.Configuration["GoogleFolders:userimage"],
		builder.Configuration["GoogleFolders:exerciseimage"],
		builder.Configuration["GoogleFolders:exercisevideo"],
		builder.Configuration["GoogleFolders:medicaltestimage"],
		builder.Configuration["GoogleFolders:bodyanalysisimage"]
	);
});

/*string blobConnectionString = builder.Configuration.GetConnectionString("BlobConnectionString");
string blobContainer = builder.Configuration.GetSection("ContainerNames")["BlobContainer"];
builder.Services.AddScoped<IBlobStorageService, BlobStorageService>(provider =>	new BlobStorageService(blobConnectionString, blobContainer));*/

builder.Services.AddScoped<IPdfService, PdfService>();
builder.Services.AddScoped<IYoutubeService, YoutubeService>();

string sendFromEmailAddress = builder.Configuration.GetValue<string>("Email");
builder.Services.AddTransient<IEmailSender, EmailSenderService>(provider => new EmailSenderService(sendGridConnectionString, sendFromEmailAddress));

builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddControllersWithViews();

builder.Services.AddSignalR();

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

app.UseEndpoints(endpoints => { endpoints.MapHub<UserChatHubService>("/chat"); });

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
