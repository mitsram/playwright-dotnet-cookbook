using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Microsoft.VisualBasic;
using NUnit.Framework;
using SauceDemo.Tests.Pages;

namespace SauceDemo.Tests.Specs;

public class LoginTests : BaseTest
{

    [Test]
    public async Task Login_ValidCredentials_ReturnsSuccessful()
    {
        var loginPage = Open<LoginPage>();
        var productsPage = await loginPage.Login("standard_user", "secret_sauce");

        var isPageLoaded = await productsPage.IsPageLoaded();
        isPageLoaded.Should().BeTrue();
    }

    [Test]
    public async Task Login_InvalidCredentials_ReturnsFailure()
    {
        var loginPage = Open<LoginPage>();
        var productsPage = await loginPage.Login("standard_user", "invalid");

        var isPageLoaded = await productsPage.IsPageLoaded();
        isPageLoaded.Should().NotBe(true);
    }

}