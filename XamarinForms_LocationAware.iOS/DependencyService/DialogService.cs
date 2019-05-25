using System;
using XamarinForms_LocationAware.Services.Dialog;

namespace XamarinForms_LocationAware.iOS.DependencyService
{
    public class DialogService : IDialogService
    {
        public DialogService()
        {
        }

        public bool DisplayAlert(string title, string message, string okButton = "Ok", string cancelButton = "Cancel")
        {
            var alertVC = UIKit.UIAlertController.Create(title, message, UIKit.UIAlertControllerStyle.Alert);
            return false;
        }
    }
}
