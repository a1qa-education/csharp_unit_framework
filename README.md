# User Interface — UI Automation Test Suite (C#)

Automated UI tests for [userinyerface.com](https://userinyerface.com/game.html), built with **.NET 10**, **NUnit** and **Aquality.Selenium**. The suite follows the Page Object Model and reads its settings and test data from JSON files in `ExampleProject/Resources`.

## Requirements

- .NET SDK 10
- Google Chrome

## Run the tests

```bash
dotnet test
```

Run a single test class:

```bash
dotnet test --filter "FullyQualifiedName~CookiesPolicyTests"
```

## Notes

- The starter suite has no reporter. Add Allure yourself as part of the Unit 4 task.
- Browser settings (timeouts, logging) are in `ExampleProject/Resources/settings.json`; the application URL is in `ExampleProject/Resources/config.json`.
