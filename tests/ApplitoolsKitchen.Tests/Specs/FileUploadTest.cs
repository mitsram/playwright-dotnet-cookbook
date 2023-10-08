using System.Threading.Tasks;
using ApplitoolsKitchen.Tests.Pages;
using FluentAssertions;
using NUnit.Framework;

namespace ApplitoolsKitchen.Tests.Specs;

public class FileUploadTest : BaseTest
{
    [SetUp]
    public void Setup()
    {
        Page.GotoAsync(Configuration["BaseUrl"]! + "/ingredients/file-picker");
    }

    [Test]    
    public async Task FileUpload_ValidFile_UploadSuccessful()    
    {
        var filePickerPage = Open<FilePickerPage>();
        var fileUploaded = await filePickerPage.UploadFile("Assets/dice.jpg");

        fileUploaded.Should().BeTrue();
    }

}