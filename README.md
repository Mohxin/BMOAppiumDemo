# Boardmaker Appium UI Test Automation for macOS

This project contains automated UI tests for the Boardmaker Editor application using Appium and .NET.

## Prerequisites

- **macOS** (macOS 10.15 or later)
- **Xcode** (full installation, not just Command Line Tools)
- **.NET SDK 9.0** or later
- **Node.js and npm** (for Appium)
- **Appium** and **Appium Mac2 Driver**

## Setup Instructions

### 1. Install Xcode

```bash
# Install Xcode from App Store or download from Apple Developer
# After installation, set Xcode as the active developer directory:
sudo xcode-select --switch /Applications/Xcode.app/Contents/Developer

# Verify installation
xcode-select -p
# Should output: /Applications/Xcode.app/Contents/Developer
```

### 2. Install Node.js and npm

```bash
# Install using Homebrew (if not already installed)
brew install node

# Verify installation
node --version
npm --version
```

### 3. Install Appium

```bash
# Install Appium globally
npm install -g appium

# Verify installation
appium --version
```

### 4. Install Appium Mac2 Driver

```bash
# Install the Mac2 driver for macOS automation
appium driver install mac2

# Verify installation
appium driver list --installed
```

### 5. Install .NET SDK

```bash
# Install .NET SDK (if not already installed)
brew install dotnet

# Verify installation
dotnet --version
```

### 6. Grant Accessibility Permissions

1. Go to **System Settings** → **Privacy & Security** → **Accessibility**
2. Add and enable:
   - **Terminal** (or your IDE)
   - **Xcode**
3. Go to **System Settings** → **Privacy & Security** → **Automation**
4. Enable automation permissions for Terminal/IDE

## Project Structure

```
BMPAppiumDemo/
├── UITesting/                    # Test project folder
│   ├── AppiumSetup.cs           # Appium driver setup and configuration
│   ├── SampleTest.cs            # Sample test cases
│   └── UITest.csproj            # Test project configuration
└── README.md                    # This file
```

## Running the Tests

### Step 1: Start Appium Server

Open a terminal and start the Appium server:

```bash
appium
```

Keep this terminal running. You should see:
```
[Appium] Welcome to Appium v3.x.x
[Appium] Appium REST http interface listener started on http://0.0.0.0:4723
```

### Step 2: Run the Tests

In a **new terminal**, navigate to the test project and run:

```bash
cd UITesting
dotnet test
```

Or run with detailed output:

```bash
dotnet test --logger "console;verbosity=normal"
```

### Step 3: Stop Appium Server

After tests complete, stop the Appium server:

```bash
# In the terminal running Appium, press Ctrl+C

# Or find and kill the process:
ps aux | grep appium | grep -v grep
kill <PID>
```

## Configuration

### Update Target Application

Edit `UITesting/AppiumSetup.cs` to change the target application:

```csharp
var macOptions = new AppiumOptions
{
    AutomationName = "mac2",
    PlatformName = "Mac",
    BundleId = "com.your.app.bundleid"  // Change this
};
```

### Find Your App's Bundle ID

```bash
# Get bundle ID of a running application
osascript -e 'id of app "YourAppName"'

# Or check the app's Info.plist
/usr/libexec/PlistBuddy -c "Print :CFBundleIdentifier" /Applications/YourApp.app/Contents/Info.plist
```
