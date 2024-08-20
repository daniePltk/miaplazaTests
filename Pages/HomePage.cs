using Microsoft.Playwright;
using MiaplazaTestsProject.Utilities;

public class HomePage : BasePage
{
    private readonly ILocator miaPrepLink;

    public HomePage(IPage page) : base(page)
    {
        miaPrepLink = page.Locator("a[href*='miaprep']");
    }

    public async Task NavigateToMiaPrepAsync()
    {
        await GotoAsync(AppConstants.Urls.HomePageUrl);
    }

    public async Task ClickPrepLinkAsync()
    {
        await miaPrepLink.WaitForAsync();
        await miaPrepLink.ClickAsync();
    }
}
