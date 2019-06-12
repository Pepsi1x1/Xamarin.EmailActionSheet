using EmailActionSheetDemo.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
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

        private IDependencyService _dependencyService;

        public MainPageViewModel(INavigationService navigationService, IDependencyService dependencyService)
			: base(navigationService)
		{
			Title = "Main Page";
            _dependencyService = dependencyService;
            OnOpenMail = new DelegateCommand(HandleAction);
        }

        void HandleAction()
        {
            _dependencyService.Get<IOpenMail>().Open(null, null);
        }

    }
}
