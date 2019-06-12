using System;
namespace EmailActionSheetDemo.Interfaces
{
    public interface IOpenMail
    {
        void Open(string from, string subject);
    }
}
