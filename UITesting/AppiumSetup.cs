using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Mac;

namespace UITests;

[SetUpFixture]
public class AppiumSetup
{
    private static MacDriver? driver;

    public static AppiumDriver App => driver ?? throw new InvalidOperationException("Driver not initialized");

    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        var macOptions = new AppiumOptions
        {
            AutomationName = "mac2",
            PlatformName = "Mac"
        };
        
        // Use bundle identifier instead of app path for more reliable launching
        macOptions.AddAdditionalAppiumOption("bundleId", "com.boardmaker.rubicon-mac");
        
        // Enable server logs to see what's going wrong
        macOptions.AddAdditionalAppiumOption("showServerLogs", true);

        // Connect to the already-running Appium server at http://127.0.0.1:4723
        driver = new MacDriver(new Uri("http://127.0.0.1:4723"), macOptions);
    }

    [OneTimeTearDown]
    public void RunAfterAnyTests()
    {
        driver?.Quit();
    }
}
