using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using System.Threading.Tasks;

public class HighSchoolPage : BasePage
{
    private readonly ILocator applyNowButton;

    public HighSchoolPage(IPage page) : base(page)
    {
        applyNowButton = page.GetByRole(AriaRole.Link, new() { Name = "Apply Now" });
    }

    public async Task ClickApplyNowAsync()
    {   
        await applyNowButton.WaitForAsync();
        await applyNowButton.ClickAsync(); 
    }
}
