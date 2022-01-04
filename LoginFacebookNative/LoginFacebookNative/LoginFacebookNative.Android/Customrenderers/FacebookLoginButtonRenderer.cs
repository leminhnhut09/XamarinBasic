using Android.App;
using Android.Content;
using LoginFacebookNative.CustomRenderers;
using LoginFacebookNative.Droid.Customrenderers;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FacebookLoginButton), typeof(FacebookLoginButtonRenderer))]
namespace LoginFacebookNative.Droid.Customrenderers
{
    public class FacebookLoginButtonRenderer : ViewRenderer
    {
        Context _context;
        bool _disposed;

        public FacebookLoginButtonRenderer(Context context) : base(context)
        {
            _context = context;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            if (Control == null)
            {
                var fbLoginBtnView = e.NewElement as FacebookLoginButton;
                if (fbLoginBtnView == null) return;
                var fbLoginbBtnCtrl = new Xamarin.Facebook.Login.Widget.LoginButton(_context)
                {
                    LoginBehavior = LoginBehavior.NativeWithFallback,
                };

                fbLoginbBtnCtrl.SetPermissions(fbLoginBtnView.Permissions);
                fbLoginbBtnCtrl.RegisterCallback(MainActivity.CallbackManager, new MyFacebookCallback(Element as FacebookLoginButton));

                SetNativeControl(fbLoginbBtnCtrl);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                if (Control != null)
                {
                    (Control as Xamarin.Facebook.Login.Widget.LoginButton).UnregisterCallback(MainActivity.CallbackManager);
                    Control.Dispose();
                }
                _disposed = true;
            }
            base.Dispose(disposing);
        }

        class MyFacebookCallback : Java.Lang.Object, IFacebookCallback
        {
            FacebookLoginButton view;

            public MyFacebookCallback(FacebookLoginButton view)
            {
                this.view = view;
            }

            public void OnCancel() =>
                view.OnCancel?.Execute(null);

            public void OnError(FacebookException fbException) =>
                view.OnError?.Execute(fbException.Message);

            public void OnSuccess(Java.Lang.Object result) =>
                view.OnSuccess?.Execute(((LoginResult)result).AccessToken.Token);
        }
    }
}