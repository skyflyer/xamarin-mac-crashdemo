namespace CrashDemo;

[Register ("AppDelegate")]
public class AppDelegate : NSApplicationDelegate {
	NSStatusItem? _statusBarItem = null;

	public override void DidFinishLaunching (NSNotification notification)
	{
        // Get reference to system status bar
        var systemBar = NSStatusBar.SystemStatusBar;

        // Create a new status bar item
        _statusBarItem = systemBar.CreateStatusItem(NSStatusItemLength.Variable);

        // Set the alternate title (in case image cannot be loaded)
        _statusBarItem.Button.AlternateTitle = "xx";

        // Set icon for status bar item button
        _statusBarItem.Button.Image = NSImage.ImageNamed("sn-idle");
        if (_statusBarItem.Button.Image != null) {
            _statusBarItem.Button.Image.Template = true;
        }

        // Create the menu
        NSMenu statusBarMenu = new("");
        _statusBarItem.Menu = statusBarMenu;

        statusBarMenu.AddItem("About", new ObjCRuntime.Selector("About"), string.Empty);
        statusBarMenu.AddItem("Quit", new ObjCRuntime.Selector("Quit"), string.Empty);
	}

	public override void WillTerminate (NSNotification notification)
	{
		// Insert code here to tear down your application
	}

    [Export("About")]
    public void About()
    {
        try {
			var alert = new NSAlert {
				AlertStyle = NSAlertStyle.Informational,
				InformativeText = "Copyright © 2023 Company, LLC. All Rights Reserved",
				MessageText = $"Company Edit\nVersion 1.2.3",
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
    public void Quit()
    {
        NSApplication.SharedApplication.Terminate(this);
    }
}
