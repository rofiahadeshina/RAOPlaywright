using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class NUnitPlaywright : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("http://eaapp.somee.com/");
    }

    [Test, Category("Eaapp1")]
    public async Task GetStartedLink()
    { 
        await Page.ClickAsync("text=Login");
        await Page.ScreenshotAsync(new PageScreenshotOptions {
            Path = "EAApp1.jpg"
        });

        await Page.FillAsync("#UserName", "admin");
        await Page.FillAsync("#Password", "password");
        await Page.ClickAsync("text=Log in");

        await Expect(Page.GetByText("Employee Details")).ToBeVisibleAsync(new() { Timeout = 10_000 });

        // var isExist = await Page.Locator("text = 'Log off'").IsVisibleAsync();
        // // Assert.IsTrue(isExist);
        // Console.WriteLine(isExist);
    } 
}