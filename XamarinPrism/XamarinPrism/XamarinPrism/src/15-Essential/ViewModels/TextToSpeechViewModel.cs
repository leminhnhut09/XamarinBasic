using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Linq;


namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class TextToSpeechViewModel : BindableBase
    {
        public CancellationTokenSource CancellationTokenSource { get; set; }

        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private float _volume = 0.75f;
        public float Volume
        {
            get { return _volume; }
            set { SetProperty(ref _volume, value); }
        }

        private float _pitch = 1f;
        public float Pitch
        {
            get { return _pitch; }
            set { SetProperty(ref _pitch, value); }
        }

        public DelegateCommand OnTextToSpeedCommand { get; set; }
        public DelegateCommand OnCancelSpeedCommand { get; set; }
        public TextToSpeechViewModel()
        {
            OnTextToSpeedCommand = new DelegateCommand(async () => await HandleTextToSpeech());
            OnCancelSpeedCommand = new DelegateCommand(HandleCancelSpeech);
        }

        private void HandleCancelSpeech()
        {
            if (CancellationTokenSource?.IsCancellationRequested ?? true)
                return;
            CancellationTokenSource.Cancel();
        }

        private async Task HandleTextToSpeech()
        {
            CancellationTokenSource = new CancellationTokenSource();
            var locales = await TextToSpeech.GetLocalesAsync();
            var locale = locales.FirstOrDefault();

            await TextToSpeech.SpeakAsync(Text, new SpeechOptions
            {
                Locale = locale,
                // 0 - 1
                Volume = Volume, 
                 //0 - 2
                Pitch = Pitch
            }, cancelToken: CancellationTokenSource.Token);

            //Task.Run(async () =>
            //{
            //    await TextToSpeech.SpeakAsync("Hello World 1");
            //    await TextToSpeech.SpeakAsync("Hello World 2");
            //    await TextToSpeech.SpeakAsync("Hello World 3");
            //});
        }
    }
}
