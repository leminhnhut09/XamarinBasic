using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class WebAuthenticatorViewModel
    {
        private DelegateCommand _onWebAuthenticatorCommand;
        public DelegateCommand OnWebAuthenticatorCommand =>
            _onWebAuthenticatorCommand ?? (_onWebAuthenticatorCommand = new DelegateCommand(HandleWebAuthenticator));

        async void HandleWebAuthenticator()
        {
            try
            {
                var authResult = await WebAuthenticator.AuthenticateAsync(
                   new Uri("https://accounts.google.com/"),
                   new Uri("myapp://"));

                var accessToken = authResult?.AccessToken;
                Console.WriteLine("result:" + accessToken);
            }
            catch (TaskCanceledException tce)
            {
            }
            catch(Exception e)
            {

            }
           
        }
    }
}
