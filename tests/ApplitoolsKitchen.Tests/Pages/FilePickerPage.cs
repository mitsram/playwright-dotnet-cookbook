
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace ApplitoolsKitchen.Tests.Pages;

public class FilePickerPage
{
    private IPage _page;

    public FilePickerPage(IPage page)
    {
        _page = page;
    }

    public async Task<bool> UploadFile(string filename)
    {
        await _page.SetInputFilesAsync("id=photo-upload", filename);
        return await _page.Locator("figure").IsVisibleAsync();
    }

}