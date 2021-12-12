using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.ViewModels
{
    public class InfomationPageViewModel
    {
        protected INavigationService _navigationService;
        protected IPageDialogService _pageDialogService;

        private DelegateCommand _onPopNavigationCommand;
        public DelegateCommand OnPopNavigationCommand =>
            _onPopNavigationCommand ?? (_onPopNavigationCommand = new DelegateCommand(async ()=> await ExecuteOnPopNavigation()));

        private async Task ExecuteOnPopNavigation()
        {
            var result = await _navigationService.GoBackAsync(null, true, true);
            if (!result.Success)
            {
                await _pageDialogService.DisplayAlertAsync("Thông báo", "Không thể quay lại !", "Đóng");
            }
        }

        public InfomationPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
