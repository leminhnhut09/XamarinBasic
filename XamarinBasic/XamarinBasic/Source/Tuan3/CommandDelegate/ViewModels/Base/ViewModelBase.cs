namespace XamarinBasic.Source.Tuan3.CommandDelegate.ViewModels
{
    // base INotifyPropertyChanged
    public class ViewModelBase : Mvvm.BindableBase
    {
        private bool _isBusy;
        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                if (SetProperty(ref _title, value))
                {
                    RaisePropertyChanged(nameof(IsNotBusy));
                }
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public bool IsNotBusy => !IsBusy;
    }
}