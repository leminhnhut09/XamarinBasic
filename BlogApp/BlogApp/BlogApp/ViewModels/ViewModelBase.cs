using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System.Threading.Tasks;

namespace BlogApp.ViewModels
{
    public class ViewModelBase : BindableBase, IApplicationLifecycleAware, IPageLifecycleAware, INavigationAware
    {
        protected INavigationService NavigationService { get; private set; }
        protected IPageDialogService PageDialogService { get; private set; }

        private string _title;
        protected string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            PageDialogService = pageDialogService;
        }

        public virtual void OnAppearing()
        {
            
        }

        public virtual void OnDisappearing()
        {
            
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public virtual void OnResume()
        {
            
        }

        public virtual void OnSleep()
        {
           
        }
    }
}
