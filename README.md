**Automation Framework (Reqnroll + MSTest + Selenium + ExtentReports)**

This framework is a UI automation solution built using:

Selenium WebDriver
MSTest
Reqnroll (BDD)
ExtentReports (HTML reporting)
Page Object Model (POM)
Custom driver factory + hooks


```text
AutomationFrameWork.slnx
│
├── AutomationFrameWork (Class Library - Core Framework)
│   ├── Configuration
│   │   └── ConfigReader.cs
│   ├── Drivers
│   │   └── WebDriverFactory.cs
│   ├── Extensions
│   │   └── WebDriverExtensions.cs
│   ├── Reporting
│   │   └── ExtentReportManager.cs
│   └── UI Driver
│       └── Browser.cs
│
└── FrameWorkl.Test (MSTest Project)
    ├── appsettings.json
    ├── MSTestSettings.cs
    ├── Test1.cs
    ├── Features
    │   ├── HomePage.feature
    │   └── HomePage.feature.cs
    ├── Hooks
    │   └── TestHooks.cs
    ├── Locators
    │   └── DynamicXPathEngine.cs
    ├── PageObjects
    │   └── HomePage.cs
    ├── StepDefination
    │   └── HomePageStepDef.cs
    └── WorkFlow
        └── CommonAppActions.cs
```


**Prerequisites**

Before starting:

* Visual Studio 2022 or later
* .NET SDK 10 installed
* Chrome or Edge browser installed
* Reqnroll Visual Studio extension (if available)

**## 1. Create Solution**

1.1 Open Visual Studio
1.2 Click:
   Create a new project
1.3 Select:
   Blank Solution
1.4 Name it:
 
1.5 Click Create

**## 2. Add Core Framework Project**

2.1 Right-click Solution → Add → New Project
2.2  Choose:
   Class Library (.NET)
2.3 Name:
   FrameWork.Core
2.4 Click Create

3. Add Test Project

3.1 Right-click Solution → Add → New Project
  3.2 Choose:
   MSTest Test Project
  3.3 Name:
   FrameWorkl.Test
  3.4 Click Create


**## 4. Add Project Reference**

4.1 Right-click `FrameWorkl.Test`
4.2 Click:
  Add → Project Reference
4.3 Select:
   FrameWork.Core
4.4 Click OK

** Install NuGet Packages (Visual Studio UI)**

## Core Project Packages

Right-click:

FrameWork.Core → Manage NuGet Packages

Install:

* Selenium.WebDriver
* Selenium.Support
* DotNetSeleniumExtras.WaitHelpers
* ExtentReports
* Microsoft.Extensions.Configuration.Json
* Microsoft.Extensions.Configuration.Binder
* Newtonsoft.Json



##  Test Project Packages

Right-click:

FrameWorkl.Test → Manage NuGet Packages

Install:

* MSTest.TestFramework
* MSTest.TestAdapter
* Microsoft.NET.Test.Sdk
* Reqnroll.MSTest



# Add Configuration File

Inside FrameWorkl.Test:

1. Right-click project → Add → New Item
2. Choose:
   JSON File
3. Name:
   appsettings.json

### Add the text below in appsettings.json starting with the curly brace and 

{
  "BrowserType": "Chrome",
  "TargetURL": "https://www.google.com",
  "TimeoutSeconds": "12"
}


**### Important:**

Set file property:
* Copy to Output Directory → **Always**



# Core Framework Components

ConfigReader
Reads settings from JSON:

  *   Browser type
  *   URL
  *   Timeout


# WebDriverFactory

  Create browser instances:

  *   Chrome
  *   Edge

Used centrally by framework.


**##  Browser Engine**

Main class controlling:

* Driver creation
* Navigation
* Waits
* Screenshot capture
* Quit browser



##  WebDriverExtensions

Adds reusable JS utilities like:

* Scroll to element


##  ExtentReportManager

Handles:

* HTML report creation
* Step logging
* Pass/Fail status
* Screenshot attachment



# Test Layer (FrameWorkl.Test)



##  Feature Files (BDD)

Right-click project:

Add → New Item → Feature File

Example:

**gherkin**

Scenario: Verify Google Search
  Given I Navigate to the Home Page
  And I Enter "Selenium WebDriver" in the Search Box
  When I Click on the Search Button
  Then I Should See Search Results for "Selenium WebDriver"


##  Step Definitions

Located in:

StepDefination/HomePageStepDef.cs

Maps Gherkin → Selenium actions.

##  Page Objects

Example:

HomePage.cs


Contains:

* Locators (By)
* WebElements
* Central UI mapping



##  Hooks (Very Important)

Located in:
Hooks/TestHooks.cs


### Execution lifecycle:

| Hook           | Purpose             |
| -------------- | ------------------- |
| BeforeTestRun  | Start Extent Report |
| BeforeScenario | Open browser        |
| AfterStep      | Log step            |
| AfterScenario  | Screenshot + result |
| AfterTestRun   | Flush report        |



#  Reporting

After execution, report is generated here:


bin/Debug/net10.0/Reports/ExecutionReport.html


Open it directly in browser.



#  Running Tests in Visual Studio

1. Open **Test Explorer**
2. Click:


   Build → Build Solution
  
3. Click:


   Run All Tests




#  Execution Flow

1. MSTest starts execution
2. Reqnroll binds feature file
3. Browser is created
4. Steps execute
5. Extent report logs everything
6. Screenshot captured on failure
7. Browser closes
8. Report generated



#  Screenshot on Failure

Automatically captured in:


AfterScenario Hook


Attached to Extent report.



#  Design Pattern Used

* Page Object Model (POM)
* Factory Pattern (Driver creation)
* Hook-based lifecycle
* Static Browser wrapper (engine style)



#  Summary

This framework supports:

 BDD with Reqnroll
 Selenium UI automation
 MSTest execution
 Extent HTML reporting
 Page Object Model
 Central driver factory
 Hook-based execution lifecycle



#  Improvements to be made in future

* Replace sleeps with explicit waits
* Add DI container (Microsoft.Extensions.DependencyInjection)
* Add parallel execution support
* Add BaseTest class instead of inheritance
* Add retry logic for flaky tests
*  Playwright migration version
*  Clean DI + BaseTest architecture
