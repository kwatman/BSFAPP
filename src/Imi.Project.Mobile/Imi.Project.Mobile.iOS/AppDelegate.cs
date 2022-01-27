using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Syncfusion.ListView.XForms.iOS;
using UIKit;

namespace Imi.Project.Mobile.iOS
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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTEyMTI2QDMxMzkyZTMzMmUzMEZEcElPTmNIL2Y4eFJ5Y0h4Y1hudjV5UFBJeFdvMzBRQlpyVGJMbWRSTDA9;NTEyMTI3QDMxMzkyZTMzMmUzMGZkeXptamNQRnhzbU8wWXZHUWZQZzUzdHZEVkJxWUVHKzJvUERMdkwxUGM9;NTEyMTI4QDMxMzkyZTMzMmUzMG1Fek8rWTVJd1FCOFM0Yk9YMzJ4OGIvOUNjYVNkZUZ5aE5hcTRXRXRjVnc9;NTEyMTI5QDMxMzkyZTMzMmUzMFk0U2N3UWp1djBpbFUyRHVTUm45MlVsc3FPODl1bzBVa1JjeTZkemdKeE09;NTEyMTMwQDMxMzkyZTMzMmUzMFA2SUdsbitDc1pGMUdtalZ0YlFELy9wK2dHbmx2VkpiSnJZVHF4aDFOZGM9;NTEyMTMxQDMxMzkyZTMzMmUzMEJ6L0F4NWxPa29CWWRsaW03UjhpeS9OV0tML1FZcTNSVjNnZVNYWkVRaFE9;NTEyMTMyQDMxMzkyZTMzMmUzME84YnZYNnNFSXBpVkgyQ3p0ckRCbzNCcGlhb0l3MnB0Z1ZWRHpSTnhWc0U9;NTEyMTMzQDMxMzkyZTMzMmUzMFF2bGZ0RjFnOTRnVTNORENxamtPd0NnOXNNV29zOHZVVW9wU2tKZDVFcEE9;NTEyMTM0QDMxMzkyZTMzMmUzMEFCRDhPVkYrcGNKWFk1WEpCK0pyZnZ4Y2d5OTZ1MTJ6YWgwa2tabnJrSXM9;NTEyMTM1QDMxMzkyZTMzMmUzMEhYRUVPT3dzK2N3TjFWZStiYUJUa0xWR1pScFpLUEMvUStPeUdSOC9TazA9;NTEyMTM2QDMxMzkyZTMzMmUzMEExaFdYdUFPeFVNUUVPU0pHSHBSOW1taEQ5ZHBTSm56Y3N0cjBuVkd6eU09");
            global::Xamarin.Forms.Forms.Init();
            SfListViewRenderer.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
