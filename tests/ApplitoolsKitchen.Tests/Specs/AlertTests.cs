using System.IO;
using System.Threading.Tasks;
using ApplitoolsKitchen.Tests.Pages;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;

namespace ApplitoolsKitchen.Tests.Specs;

public class AlertTests : BaseTest
{
    [SetUp]
    public void Setup()
    {
        Page.GotoAsync(Configuration["BaseUrl"]! + "/ingredients/alert");
    }

    [Test]
    public async Task Alert_TriggerAnAlert_ReturnDisplayed()    
    {
        Page.Dialog += (_, dialog) => 
        {
            dialog.DismissAsync();
            string message = dialog.Message;                        
            message.Should().Be("Airfryers can make anything!");
        };
        var alertPage = Open<AlertPage>();
        await alertPage.TriggerAnAlert();        
    }

    [Test]
    public async Task Alert_TriggerAConfirmation_Accept_ReturnYes()
    {
        Page.Dialog += (_, dialog) => 
        {
            dialog.AcceptAsync();
            string message = dialog.Message;                        
            message.Should().Be("Proceed with adding garlic?");
        };
        var alertPage = Open<AlertPage>();
        await alertPage.TriggerAConfirmation();
        var answerText = await alertPage.ConfirmAnswer();

        answerText.Should().Be("Answer: Yes");
    }

    [Test]
    public async Task Alert_TriggerAConfirmation_Cancel_ReturnNo()
    {
        Page.Dialog += (_, dialog) => 
        {
            dialog.DismissAsync();
            string message = dialog.Message;                        
            message.Should().Be("Proceed with adding garlic?");
        };
        var alertPage = Open<AlertPage>();
        await alertPage.TriggerAConfirmation();
        var answerText = await alertPage.ConfirmAnswer();

        answerText.Should().Be("Answer: No");
    }

    [Test]
    public async Task Alert_TriggerAPrompt_Accept_ReturnPromptText()
    {
        var promptText = "Pizza";

        Page.Dialog += (_, dialog) => 
        {
            dialog.AcceptAsync(promptText);
            string message = dialog.Message;                        
            message.Should().Be("What is your favorite food?");
        };
        var alertPage = Open<AlertPage>();
        await alertPage.TriggerAPrompt();
        var answerText = await alertPage.PromptAnswer();

        answerText.Should().Be("Answer: " + promptText);
    }

    [Test]
    public async Task Alert_TriggerAPrompt_Cancel_ReturnCancelled()
    {
        Page.Dialog += (_, dialog) => 
        {
            dialog.DismissAsync();
            string message = dialog.Message;                        
            message.Should().Be("What is your favorite food?");
        };
        var alertPage = Open<AlertPage>();
        await alertPage.TriggerAPrompt();
        var answerText = await alertPage.PromptAnswer();

        answerText.Should().Be("Answer: Cancelled");
    }
}