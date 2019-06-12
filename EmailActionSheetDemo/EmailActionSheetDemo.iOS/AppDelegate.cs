using System;
using System.Security.Policy;
using EmailAction.Shared;
using Foundation;
using Prism;
using Prism.Ioc;
using UIKit;


namespace EmailActionSheetDemo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(new iOSInitializer()));

			Window.RootViewController.PresentViewController(SetupChooseEmailActionSheet(), true, null);
            return base.FinishedLaunching(app, options);
        }

        UIAlertController SetupChooseEmailActionSheet(string title = "Choose Email", string emailString = null, string subjectString= null)
        {
        
	        var emailActionSheet = UIAlertController.Create(title: title, message: null, preferredStyle: UIAlertControllerStyle.ActionSheet);


	        var escapedSubjectString = subjectString == null ? null : Uri.EscapeDataString(subjectString);


	        var actionArray = ChooseEmailActionSheetPresenter.PopulateAppActionArray(emailString, escapedSubjectString);
        
	        if (actionArray.Count == 0)  {

		        emailActionSheet.AddAction(ChooseEmailActionSheetPresenter.OpenSafariAction(null));
	        } else {
		        foreach (var action in actionArray)
		        {
			        emailActionSheet.AddAction(action);
		        }
	        }

	        emailActionSheet.AddAction(UIAlertAction.Create(title: "Cancel", style: UIAlertActionStyle.Cancel, null));

	        return emailActionSheet;
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}
