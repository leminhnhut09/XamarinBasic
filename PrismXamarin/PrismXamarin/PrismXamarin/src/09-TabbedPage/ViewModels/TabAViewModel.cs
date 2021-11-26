using Prism;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismXamarin.src._09_TabbedPage.ViewModels
{
    public class TabAViewModel : BindableBase, IActiveAware
    {
        public event EventHandler IsActiveChanged;

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value, RaiseIsActiveChanged); }
        }

        protected virtual void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
