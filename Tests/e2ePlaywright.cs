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

        // Navigate to the main page
        var homePage = new HomePage(page);
        await homePage.NavigateToMiaPrepAsync();

        // Navigate to MiaPrep Online High School through the banner link
        await homePage.ClickPrepLinkAsync();

        // Apply to MiaPrep Online High School
        var highSchoolPage = new HighSchoolPage(page);
        await highSchoolPage.ClickApplyNowAsync();

        var applicationFormPage = new ApplicationFormPage(page);
        await applicationFormPage.ClickFirstNextButtonAsync();
        await applicationFormPage.VerifyUrlAsync();

        // Fill in the application form with the necessary details
        await applicationFormPage.FillFormAsync(
            "John",
            "Doe",
            "john.doe@example.com",
            "1234567890",
            "01-Sep-2024"
        );
        await applicationFormPage.ClickNextFormButtonAsync();

        // Verify we reached 'Student Information' form part
        await applicationFormPage.VerifyStudentInformationHeadingAsync();

        await browser.CloseAsync();
    }
}
