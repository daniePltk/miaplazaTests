# Project MiaplazaTests

This project is a .NET test suite configured with Playwright and xUnit for automated testing. The project is targeted at .NET 8.0 and includes the necessary packages to facilitate testing using these tools.

## Project Structure

This project is structured as a test suite and is not packable (`IsPackable=false`). It is specifically designed to run tests with the following features enabled:

- **Target Framework**: .NET 8.0 (`net8.0`)
- **Implicit Usings**: Enabled to automatically include common namespaces.
- **Nullable Reference Types**: Enabled to enforce nullable reference types.

## Installation

To set up the project locally, follow these steps:

1. **Clone the repository**:
   ```bash
   git clone https://github.com/daniePltk/miaplazaTests.git
   ```

2. **Navigate to the project directory**:
    ```bash
    cd miaplazaTests
    ```
3. **Restore the necessary packages**:
    ```
    dotnet restore
    ```

## Running Tests

The project is configured with specific targets to run individual tests or the entire test suite.

### Run a Specific Test

To run a specific test, such as `MiaAcademyTests.ApplyToMiaPrepOnlineHighSchool`, use the following command:

```bash
dotnet msbuild -t:RunSpecificTest
```
This command runs the test with the fully qualified name that matches MiaAcademyTests.ApplyToMiaPrepOnlineHighSchool.

### Run All Tests

To run all tests in the project, use the following command:

```bash
dotnet msbuild -t:RunAllTests
```
Alternatively, you can run all tests directly using the .NET CLI:
```bash
dotnet test
```
