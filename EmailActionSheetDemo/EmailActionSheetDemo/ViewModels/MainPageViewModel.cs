using EmailActionSheetDemo.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace EmailActionSheetDemo.ViewModels
{
	public class MainPageViewModel : ViewModelBase
	{
        public DelegateCommand OnOpenMail
        {
            get;
            set;
        }

		public MainPageViewModel(INavigationService navigationService)
			: base(navigationService)
		{
			Title = "Main Page";
            OnOpenMail = new DelegateCommand(HandleAction);
		}

        void HandleAction()
        {
            Xamarin.Forms.DependencyService.Get<IOpenMail>().Open(null, null);
        }

    }
}
