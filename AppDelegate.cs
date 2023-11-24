namespace CrashDemo;

[Register ("AppDelegate")]
public class AppDelegate : NSApplicationDelegate {
	NSStatusItem? _statusBarItem = null;

	public override void DidFinishLaunching (NSNotification notification)
	{
        Console.WriteLine($"1");
        
        // Get reference to system status bar
        var systemBar = NSStatusBar.SystemStatusBar;
        Console.WriteLine($"1");

        // Create a new status bar item
        _statusBarItem = systemBar.CreateStatusItem(NSStatusItemLength.Variable);
        Console.WriteLine($"3");

        // Set the alternate title (in case image cannot be loaded)
        _statusBarItem.Button.AlternateTitle = "SN";
        Console.WriteLine($"4");

        // Set icon for status bar item button
        _statusBarItem.Button.Image = NSImage.ImageNamed("sn-idle");
        if (_statusBarItem.Button.Image != null) {
            _statusBarItem.Button.Image.Template = true;
        }
        Console.WriteLine($"5");

        // Create the menu
        NSMenu statusBarMenu = new("");
        _statusBarItem.Menu = statusBarMenu;
        Console.WriteLine($"6");

        statusBarMenu.AddItem("Synchronize", new ObjCRuntime.Selector("RunSync"), string.Empty);
        statusBarMenu.AddItem("Clear local cache", new ObjCRuntime.Selector("ClearLocalCache"), string.Empty);
        statusBarMenu.AddItem("About", new ObjCRuntime.Selector("About"), string.Empty);
        statusBarMenu.AddItem("Quit", new ObjCRuntime.Selector("Quit"), string.Empty);
        Console.WriteLine($"7");
	}

	public override void WillTerminate (NSNotification notification)
	{
		// Insert code here to tear down your application
	}

    [Export("RunSync")]
    public void RunSync()
    {
		Console.WriteLine($"Sync");
	}

    [Export("ClearLocalCache")]
    public void ClearLocalCache()
    {
		Console.WriteLine($"ClearLocalCache");
	}

    [Export("About")]
    public void About()
    {
        try {
        Console.WriteLine($"1");
        var messageText = $"Company Edit\nVersion 1.2.3";
        Console.WriteLine($"2");
        var alert = new NSAlert {
            AlertStyle = NSAlertStyle.Informational,
            InformativeText = "Copyright © 2023 Company, LLC. All Rights Reserved",
            MessageText = messageText,
            Icon = NSImage.ImageNamed("AppIcon")!,
        };
        Console.WriteLine($"3");

        alert.RunModal();
        Console.WriteLine($"4");
        } catch (Exception x) {
            Console.WriteLine(x);
        }
    }

    [Export("Quit")]
    public async void Quit()
    {
        NSApplication.SharedApplication.Terminate(this);
    }
}
