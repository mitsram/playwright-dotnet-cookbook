using System.Threading.Tasks;
using Microsoft.Playwright;

namespace SauceDemo.Tests.Pages;

public class LoginPage
{
    private IPage _page;

    public LoginPage(IPage page)
    {
        _page = page;
    }

    private ILocator _txtUsername => _page.Locator("id=user-name");
    private ILocator _txtPassword => _page.Locator("id=password");
    private ILocator _btnLogin => _page.Locator("id=login-button");

    public async Task<ProductsPage> Login(string username, string password)
    {
        await _txtUsername.FillAsync(username);
        await _txtPassword.FillAsync(password);
        await _btnLogin.ClickAsync();
        return new ProductsPage(_page);
    }
}