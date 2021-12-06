using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class LauncherViewModel : BindableBase
    {
        public DelegateCommand OnLauncherCommand { get; set; }
        public DelegateCommand OnLauncherFileCommand { get; set; }

        public LauncherViewModel()
        {
            OnLauncherCommand = new DelegateCommand(async () => await HandleLauncher());
            OnLauncherFileCommand = new DelegateCommand(async () => await HandleLaucherFile());
        }

        private async Task HandleLaucherFile()
        {
                var fn = "Attachment.txt";
                var file = Path.Combine(FileSystem.CacheDirectory, fn);

                File.WriteAllText(file, "Hello xamarin form");

                await Launcher.OpenAsync(
                    new OpenFileRequest
                    {
                        File = new ReadOnlyFile(file)
                    }
                );
        }

        async Task HandleLauncher()
        {
            bool isOpen = await Launcher.CanOpenAsync("https://www.google.com/");
            if (isOpen)
            {
                await Launcher.OpenAsync("https://www.youtube.com/");
            }
            //await Launcher.TryOpenAsync("lyft://ridetype?id=lyft_line");
        }
    }
}
