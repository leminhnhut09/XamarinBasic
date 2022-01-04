using LoginFacebookNative.Droid.Services;
using LoginFacebookNative.Services;
using System;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Forms;

//[assembly: Dependency(typeof(FacebookLoginService))]
namespace LoginFacebookNative.Droid.Services
{
    public class FacebookLoginService : IFacebookLoginService
    {
        readonly MyAccessTokenTracker myAccessTokenTracker;
        public Action<string, string> AccessTokenChanged { get; set; }

        public FacebookLoginService()
        {
            myAccessTokenTracker = new MyAccessTokenTracker(this);
            myAccessTokenTracker.StartTracking();
        }

        public string AccessToken => Xamarin.Facebook.AccessToken.CurrentAccessToken?.Token;

        public void Logout()
        {
            LoginManager.Instance.LogOut();
        }
    }

    class MyAccessTokenTracker : AccessTokenTracker
    {
        readonly IFacebookLoginService _facebookLoginService;

        public MyAccessTokenTracker(FacebookLoginService facebookLoginService)
        {
            _facebookLoginService = facebookLoginService;
        }

        protected override void OnCurrentAccessTokenChanged(AccessToken oldAccessToken, AccessToken currentAccessToken)
        {
            _facebookLoginService.AccessTokenChanged?.Invoke(oldAccessToken?.Token, currentAccessToken?.Token);
        }
    }
}