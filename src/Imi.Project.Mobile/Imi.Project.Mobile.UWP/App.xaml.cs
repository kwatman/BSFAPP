using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Imi.Project.Mobile.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTEyMTI2QDMxMzkyZTMzMmUzMEZEcElPTmNIL2Y4eFJ5Y0h4Y1hudjV5UFBJeFdvMzBRQlpyVGJMbWRSTDA9;NTEyMTI3QDMxMzkyZTMzMmUzMGZkeXptamNQRnhzbU8wWXZHUWZQZzUzdHZEVkJxWUVHKzJvUERMdkwxUGM9;NTEyMTI4QDMxMzkyZTMzMmUzMG1Fek8rWTVJd1FCOFM0Yk9YMzJ4OGIvOUNjYVNkZUZ5aE5hcTRXRXRjVnc9;NTEyMTI5QDMxMzkyZTMzMmUzMFk0U2N3UWp1djBpbFUyRHVTUm45MlVsc3FPODl1bzBVa1JjeTZkemdKeE09;NTEyMTMwQDMxMzkyZTMzMmUzMFA2SUdsbitDc1pGMUdtalZ0YlFELy9wK2dHbmx2VkpiSnJZVHF4aDFOZGM9;NTEyMTMxQDMxMzkyZTMzMmUzMEJ6L0F4NWxPa29CWWRsaW03UjhpeS9OV0tML1FZcTNSVjNnZVNYWkVRaFE9;NTEyMTMyQDMxMzkyZTMzMmUzME84YnZYNnNFSXBpVkgyQ3p0ckRCbzNCcGlhb0l3MnB0Z1ZWRHpSTnhWc0U9;NTEyMTMzQDMxMzkyZTMzMmUzMFF2bGZ0RjFnOTRnVTNORENxamtPd0NnOXNNV29zOHZVVW9wU2tKZDVFcEE9;NTEyMTM0QDMxMzkyZTMzMmUzMEFCRDhPVkYrcGNKWFk1WEpCK0pyZnZ4Y2d5OTZ1MTJ6YWgwa2tabnJrSXM9;NTEyMTM1QDMxMzkyZTMzMmUzMEhYRUVPT3dzK2N3TjFWZStiYUJUa0xWR1pScFpLUEMvUStPeUdSOC9TazA9;NTEyMTM2QDMxMzkyZTMzMmUzMEExaFdYdUFPeFVNUUVPU0pHSHBSOW1taEQ5ZHBTSm56Y3N0cjBuVkd6eU09");
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                Xamarin.Forms.Forms.Init(e);

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
