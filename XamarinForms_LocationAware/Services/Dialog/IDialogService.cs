using System;
namespace XamarinForms_LocationAware.Services.Dialog
{
    public interface IDialogService
    {
        bool DisplayAlert(string title, string message, string okButton = "Ok", string cancelButton = "Cancel");
    }
}
