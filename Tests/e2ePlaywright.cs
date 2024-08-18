using Microsoft.Playwright;
using Xunit;
using System.Threading.Tasks;

public class MiaAcademyTests
{
    [Fact]
    public async Task ApplyToMiaPrepOnlineHighSchool()
    {
        // Create an instance of Playwright and launch the browser
        using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        var page = await browser.NewPageAsync();

        // Step 1: Navigate to the main page
        await page.GotoAsync("https://miacademy.co/#/");
        
        // Step 2: Navigate to MiaPrep Online High School through the banner link
        var miaPrepLink = await page?.WaitForSelectorAsync("a[href*='miaprep']");
        await miaPrepLink?.ClickAsync();

        // Step 3: Apply to MiaPrep Online High School
        var applyButton = await page.WaitForSelectorAsync("a:has-text('Apply Now')"); // Update the selector if needed
        await applyButton.ClickAsync();
        
        var applicationFormPage = new ApplicationFormPage(page);
        await applicationFormPage.ClickFirstNextButtonAsync();

        await applicationFormPage.VerifyUrlAsync();

        // Step 4: Fill in the application form with the necessary details
        await applicationFormPage.FillFormAsync(
            "John",
            "Doe",
            "john.doe@example.com",
            "555-555-5555",
            "01-Sep-2024"
        );

        // Step 5: Click the "Next" button on the second page of the form
        await applicationFormPage.ClickNextFormButtonAsync();

        // Close the browser at the end of the test
        await browser.CloseAsync();
    }
}
