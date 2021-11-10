using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBasic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            btnLogin.Clicked += ButtonLogin_Clicked;
            btnRegister.Clicked += ButtonRegister_Clicked;
        }

        private void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string passWord = txtPassWord.Text;
            if (String.IsNullOrEmpty(userName))
            {
                DisplayAlert("Notification", "Please enter user name", "Ok");
                txtUserName.Focus();
                return;
            }
            if (String.IsNullOrEmpty(passWord))
            {
                DisplayAlert("Notification", "Please enter password", "Ok");
                txtPassWord.Focus();
                return;
            }
            if (userName.Equals("admin") && passWord.Equals("123456")){
                DisplayAlert("Notification", "Login success", "Close");
            }
            else
            {
                DisplayAlert("Notification", "Account does not exist !", "Close");
            }
        }
    }
}