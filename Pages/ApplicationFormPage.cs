using Microsoft.Playwright;
using MiaplazaTestsProject.Utilities;

public class ApplicationFormPage : BasePage
{
    private readonly ILocator firstNameInput;
    private readonly ILocator lastNameInput;
    private readonly ILocator emailInput;
    private readonly ILocator phoneNumberInput;
    private readonly ILocator firstNextButton;
    private readonly ILocator nextFormButton;
    private readonly ILocator question;
    private readonly ILocator guardianNo;
    private readonly ILocator calendar;
    private readonly ILocator headingLocator;


    public ApplicationFormPage(IPage page) : base(page)
    {
        firstNameInput = page.GetByRole(AriaRole.Textbox, new() { Name = "Name First Name Required" });
        lastNameInput = page.GetByRole(AriaRole.Textbox, new() { Name = "Name Last Name Required" });
        emailInput = page.GetByLabel("Email *");
        phoneNumberInput = page.GetByLabel("Phone *");
        firstNextButton = page.GetByLabel("Next Navigates to page 2 out of");
        nextFormButton = page.GetByLabel("Next Navigates to page 3 out of");
        question = page.GetByRole(AriaRole.Combobox, new() { Name = "-Select-" }).Locator("div");
        guardianNo = page.GetByRole(AriaRole.Treeitem, new() { Name = "No" });
        calendar = page.GetByLabel("What is your preferred start");
        headingLocator = page.GetByRole(AriaRole.Heading, new() { Name = "Student Information" }).Locator("b");

    }

    public async Task VerifyUrlAsync()
    {
        await VerifyUrlAsync(AppConstants.Urls.applicvationFormUrl);
    }

    // First step
    public async Task ClickFirstNextButtonAsync()
    {
        await firstNextButton.ClickAsync();
    }

    // Second step
    public async Task FillFirstNameAsync(string firstName)
    {
        await firstNameInput.FillAsync(firstName);
    }

    public async Task FillLastNameAsync(string lastName)
    {
        await lastNameInput.FillAsync(lastName);
    }

    public async Task FillEmailAsync(string email)
    {
        await emailInput.FillAsync(email);
    }

    public async Task FillPhoneNumberAsync(string phoneNumber)
    {
        await phoneNumberInput.FillAsync(phoneNumber);
    }

    public async Task FillGuardianNoAsync()
    {
        await question.ClickAsync();
        await guardianNo.ClickAsync();
    }

    public async Task FillCalendarAsync(string date)
    {
        await calendar.ClickAsync();
        await calendar.FillAsync(date);
    }

    public async Task FillFormAsync(string firstName, string lastName, string email, string phoneNumber, string date)
    {
        await FillFirstNameAsync(firstName);
        await FillLastNameAsync(lastName);
        await FillEmailAsync(email);

        if (!string.IsNullOrEmpty(phoneNumber))
        {
            await FillPhoneNumberAsync(phoneNumber);
        }

        await FillGuardianNoAsync();
        await FillCalendarAsync(date);
    }

    public async Task ClickNextFormButtonAsync()
    {
        await nextFormButton.ClickAsync();
    }

    public async Task VerifyStudentInformationHeadingAsync()
    {
        await Assertions.Expect(headingLocator).ToHaveTextAsync("Student Information");

    }
}
