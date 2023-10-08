using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using ApplitoolsKitchen.Tests.Pages;

namespace ApplitoolsKitchen.Tests.Specs;

[Parallelizable(ParallelScope.Self)]
public class BaseTest : PageTest
{
    private IConfiguration _configuration;
    private IServiceProvider _pageProvider;

    public BaseTest()
    {
        _configuration = BuildConfiguration();
        _pageProvider = BuildPages();
    }
    
    private static IConfiguration BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .AddJsonFile("appsettings.dev.json", optional: true);

        return builder.Build();
    }

    private IServiceProvider BuildPages()
    {
        var services = new ServiceCollection();
        services.AddSingleton(_configuration);

        // Register your page objects here
        services.AddTransient(page => Page);
        services.AddTransient<FilePickerPage>();

        return services.BuildServiceProvider();
    }

    public IConfiguration Configuration => _configuration;
    public T Open<T>() => _pageProvider.GetService<T>() ?? throw new NullReferenceException("Do not forget to register your page objects");
}