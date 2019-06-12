using System;
using EmailAction.Shared;
using EmailActionSheetDemo.Interfaces;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(EmailActionSheetDemo.iOS.Implementations.OpenMail))]
namespace EmailActionSheetDemo.iOS.Implementations
{
    public class OpenMail : IOpenMail
    {
        public OpenMail()
        {
        }

        public void Open(string from, string subject)
        {
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(SetupChooseEmailActionSheet(), true, null);
        }

        UIAlertController SetupChooseEmailActionSheet(string title = "Choose Email", string emailString = null, string subjectString = null)
        {

            var emailActionSheet = UIAlertController.Create(title: title, message: null, preferredStyle: UIAlertControllerStyle.ActionSheet);


            var escapedSubjectString = subjectString == null ? null : Uri.EscapeDataString(subjectString);


            var actionArray = ChooseEmailActionSheetPresenter.PopulateAppActionArray(emailString, escapedSubjectString);

            if (actionArray.Count == 0)
            {

                emailActionSheet.AddAction(ChooseEmailActionSheetPresenter.OpenSafariAction(null));
            }
            else
            {
                foreach (var action in actionArray)
                {
                    emailActionSheet.AddAction(action);
                }
            }

            emailActionSheet.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null));

            return emailActionSheet;
        }
    }
}
