using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using System.Threading.Tasks;

public class HomePage : BasePage
{
    private readonly ILocator miaPrepLink;

    public HomePage(IPage page) : base(page)
    {
        miaPrepLink = page.Locator("a[href*='miaprep']");
    }

    public async Task NavigateToMiaPrepAsync()
    {
        await GotoAsync("https://miacademy.co/#/");

    }

    public async Task ClickApplyNowAsync()
    {   
        await miaPrepLink.WaitForAsync();
        await miaPrepLink.ClickAsync(); 
    }
}
