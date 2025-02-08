using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ExampleTest : PageTest
{
    [Test, Category("Velo")]
    public async Task HasTitle()
    {
        await Page.GotoAsync("https://veloremit.com/");

        await Page
        .GetByRole(AriaRole.Button)
        .Filter(new() { HasText = "Accept" }).ClickAsync();

        await Page
        .GetByRole(AriaRole.Button)
        .Filter(new() { HasText = "Currency Converter" }).ClickAsync();

        await Page.Locator("div.mx-5 section div.m_e2f5cd4e  input[id='mantine-ucmtmghxl']").FillAsync("1000");

        
        // // Expect a title "to contain" a substring.
        // await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
    }

    [Test, Category("Eaapp")]
    public async Task GetStartedLink()
    {
    
        var page = await Browser.NewPageAsync();

        await page.GotoAsync("http://eaapp.somee.com/");
        await page.ClickAsync("text=Login");
        await page.ScreenshotAsync(new PageScreenshotOptions {
            Path = "EAApp.jpg"
        });

        await page.FillAsync("#UserName", "admin");
        await page.FillAsync("#Password", "password");
        await page.ClickAsync("text=Log in");

        var isExist = await page.Locator("text = 'Log off'").IsVisibleAsync();
        // Assert.IsTrue(isExist);
        Console.WriteLine(isExist);
    } 
}