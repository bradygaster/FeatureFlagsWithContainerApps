using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

string config = builder.Configuration.GetValue<string>("AzureAppConfig");
builder.Configuration.AddAzureAppConfiguration(options =>
    options
        .Connect(config)
            .UseFeatureFlags(featureFlagOptions => featureFlagOptions.Label = builder.Configuration.GetValue<string>("RevisionLabel")));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddFeatureManagement();


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

app.Run();

public enum MyFeatureFlags
{
    Beta
}