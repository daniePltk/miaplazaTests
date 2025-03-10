using Microsoft.Playwright;

public abstract class BasePage
{
    protected readonly IPage Page;

    public BasePage(IPage page)
    {
        Page = page;
    }

    public async Task GotoAsync(string url)
    {
        await Page.GotoAsync(url);
    }

    public async Task VerifyUrlAsync(string expectedUrl)
    {
        await Assertions.Expect(Page).ToHaveURLAsync(expectedUrl);
    }
}
