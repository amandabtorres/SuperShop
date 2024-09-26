using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SuperShop.Prism.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperShop.Prism.ViewModels
{
	public class ModifyUserPagexamlViewModel : ViewModelBase
	{
        public ModifyUserPagexamlViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.ModifyUser;

        }
	}
}
