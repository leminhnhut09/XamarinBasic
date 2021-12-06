using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class ShareViewModel : BindableBase
    {
        private string _textShare;
        public string TextShare
        {
            get { return _textShare; }
            set { SetProperty(ref _textShare, value); }
        }
        private DelegateCommand _onShareTextCommand;
        public DelegateCommand OnShareTextCommand =>
            _onShareTextCommand ?? (_onShareTextCommand = new DelegateCommand(HandleShareText));


        private DelegateCommand _onShareUriCommand;
        public DelegateCommand OnShareUriCommand =>
            _onShareUriCommand ?? (_onShareUriCommand = new DelegateCommand(HandleShareUri));

        private async void HandleShareText()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Title = "Share",
                Text = "Hello xamarin form"
            });
        }
        private async void HandleShareUri()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Title = "Share",
                // uri
                Uri = "https://www.youtube.com/watch?v=YXW4w-yK_dw&list=PLM75ZaNQS_Fa6UdCieXUcVubIV3-MDXDV&index=34"
            });
        }
    }
}
