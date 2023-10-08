
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace ApplitoolsKitchen.Tests.Pages;

public class AlertPage
{
    private IPage _page;

    public AlertPage(IPage page)
    {
        _page = page;
    }

    public async Task TriggerAnAlert()
    {
        await _page.Locator("id=alert-button").ClickAsync();
    }

    public async Task TriggerAConfirmation()
    {
        await _page.Locator("id=confirm-button").ClickAsync();
    }

    public async Task<string> ConfirmAnswer()
    {
        return await _page.Locator("id=confirm-answer").InnerTextAsync();
    }

    public async Task TriggerAPrompt()
    {
        await _page.Locator("id=prompt-button").ClickAsync();
    }

    public async Task<string> PromptAnswer()
    {
        return await _page.Locator("id=prompt-answer").InnerTextAsync();
    }
}