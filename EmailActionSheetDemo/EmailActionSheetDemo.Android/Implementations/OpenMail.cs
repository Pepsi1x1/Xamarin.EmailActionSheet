using System;
using EmailActionSheetDemo.Interfaces;
using Prism.Services;

[assembly: Xamarin.Forms.Dependency(typeof(EmailActionSheetDemo.Droid.Implementations.OpenMail))]
namespace EmailActionSheetDemo.Droid.Implementations
{
    public class OpenMail : IOpenMail
    {
        public OpenMail()
        {
        }

        public void Open(string from, string subject)
        {
            Xamarin.Forms.Device.OpenUri(new Uri($"mailto:{from}?subject={subject}"));
        }
    }
}
