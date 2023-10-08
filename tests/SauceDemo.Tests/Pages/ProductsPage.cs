
using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace SauceDemo.Tests.Pages;

public class ProductsPage
{
    private IPage _page;

    public ProductsPage(IPage page)
    {
        _page = page;
    }

    public async Task<bool> IsPageLoaded()
    {
        return await _page.GetByText("Products").IsVisibleAsync();
    }
}
