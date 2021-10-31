using Imi.Project.Mobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTEyMTI2QDMxMzkyZTMzMmUzMEZEcElPTmNIL2Y4eFJ5Y0h4Y1hudjV5UFBJeFdvMzBRQlpyVGJMbWRSTDA9;NTEyMTI3QDMxMzkyZTMzMmUzMGZkeXptamNQRnhzbU8wWXZHUWZQZzUzdHZEVkJxWUVHKzJvUERMdkwxUGM9;NTEyMTI4QDMxMzkyZTMzMmUzMG1Fek8rWTVJd1FCOFM0Yk9YMzJ4OGIvOUNjYVNkZUZ5aE5hcTRXRXRjVnc9;NTEyMTI5QDMxMzkyZTMzMmUzMFk0U2N3UWp1djBpbFUyRHVTUm45MlVsc3FPODl1bzBVa1JjeTZkemdKeE09;NTEyMTMwQDMxMzkyZTMzMmUzMFA2SUdsbitDc1pGMUdtalZ0YlFELy9wK2dHbmx2VkpiSnJZVHF4aDFOZGM9;NTEyMTMxQDMxMzkyZTMzMmUzMEJ6L0F4NWxPa29CWWRsaW03UjhpeS9OV0tML1FZcTNSVjNnZVNYWkVRaFE9;NTEyMTMyQDMxMzkyZTMzMmUzME84YnZYNnNFSXBpVkgyQ3p0ckRCbzNCcGlhb0l3MnB0Z1ZWRHpSTnhWc0U9;NTEyMTMzQDMxMzkyZTMzMmUzMFF2bGZ0RjFnOTRnVTNORENxamtPd0NnOXNNV29zOHZVVW9wU2tKZDVFcEE9;NTEyMTM0QDMxMzkyZTMzMmUzMEFCRDhPVkYrcGNKWFk1WEpCK0pyZnZ4Y2d5OTZ1MTJ6YWgwa2tabnJrSXM9;NTEyMTM1QDMxMzkyZTMzMmUzMEhYRUVPT3dzK2N3TjFWZStiYUJUa0xWR1pScFpLUEMvUStPeUdSOC9TazA9;NTEyMTM2QDMxMzkyZTMzMmUzMEExaFdYdUFPeFVNUUVPU0pHSHBSOW1taEQ5ZHBTSm56Y3N0cjBuVkd6eU09");

            InitializeComponent();

            MainPage = new AdminPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
