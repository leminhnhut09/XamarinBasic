using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class ClipboardViewModel : BindableBase, IPageLifecycleAware
    {

        private string _title = "Clipboard";
        protected IPageDialogService _pageDialogService;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }

        public DelegateCommand OnCopyCammand { get; set; }
        public DelegateCommand OnPasteCammand { get; set; }

        public ClipboardViewModel(IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
            OnCopyCammand = new DelegateCommand(HandleCopyText);
            OnPasteCammand = new DelegateCommand(HandlePasteText);
        }

        private async void OnClipboardContentChanged(object sender, EventArgs e)
        {
            await _pageDialogService.DisplayAlertAsync("Noti", $"Last clipboard change at {DateTime.UtcNow:T}", "Close");
        }

        private async void HandlePasteText()
        {
            if (Clipboard.HasText)
            {
                Content = await Clipboard.GetTextAsync();
            }
        }

        private async void HandleCopyText()
        {
            await Clipboard.SetTextAsync(Text);
        }

        public void OnAppearing()
        {
            Clipboard.ClipboardContentChanged += OnClipboardContentChanged;
        }

        public void OnDisappearing()
        {
            Clipboard.ClipboardContentChanged -= OnClipboardContentChanged;
        }
    }
}
