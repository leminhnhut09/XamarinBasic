using BlogApp.Models;
using Newtonsoft.Json;
using Plugin.FacebookClient;
using System;
using System.Threading.Tasks;

namespace BlogApp.Services
{
    public class LoginFacebookService : ILoginFacebookService
    {
        readonly string[] facebookRequestFields = { "email", "first_name", "picture", "gender", "last_name" };
        readonly string[] facebookPermisions = { "email", "public_profile" };
        public Action<Account, string> _onLoginComplete;
        IFacebookClient _facebookService = CrossFacebookClient.Current;

        public void Logout()
        {
            if (_facebookService.IsLoggedIn)
            {
                _facebookService.Logout();
            }
        }

        async Task ILoginFacebookService.Login(Action<Account, string> onLoginComplete)
        {
            _onLoginComplete = onLoginComplete;
            if (_facebookService.IsLoggedIn)
            {
                _facebookService.Logout();
            }
            _facebookService.OnUserData += OnUserDataChanged;
            await _facebookService.RequestUserDataAsync(facebookRequestFields, facebookPermisions);
        }
        private void OnUserDataChanged(object sender, FBEventArgs<string> e)
        {
            if (e == null) return;

            switch (e.Status)
            {
                case FacebookActionStatus.Completed:
                    var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(e.Data);
                    var account = new Account
                    {
                        Email = facebookProfile.Email,
                        Picture = facebookProfile.Picture.Data.Url
                    };
                    _onLoginComplete?.Invoke(account, string.Empty);
                    break;
                case FacebookActionStatus.Canceled:
                    _onLoginComplete?.Invoke(null, "Cancel");
                    break;
                case FacebookActionStatus.Error:
                    _onLoginComplete?.Invoke(null, "Error");
                    break;
                case FacebookActionStatus.Unauthorized:
                    _onLoginComplete?.Invoke(null, "Unauthorized");
                    break;
                default:
                    _onLoginComplete?.Invoke(null, "Unknow");
                    break;
            }
            _facebookService.OnUserData -= OnUserDataChanged;
        }
    }
}
