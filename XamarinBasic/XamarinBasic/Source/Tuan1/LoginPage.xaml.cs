using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinBasic.Source.Tuan1;

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
            NavigationPage navigation = new NavigationPage(new LoginPage());
            Navigation.PushAsync(new RegisterPage());
        }

        private void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            string userName = userEntry.Text.Trim().ToString();
            string passWord = passEntry.Text.Trim().ToString();


            if (userName.Equals("admin") && passWord.Equals("123456"))
            {
                Navigation.PushAsync(new DetailLoginPage(userName, passWord));
            }
            else
            {
                DisplayAlert("Notification", "Account does not exist !", "Close");
            }
        }
    }

    public class User
    {
        public string Pass { get; set; }
        public string UserName { get; set; }
        public User(string name, string pass)
        {
            this.UserName = name;
            this.Pass = pass;
        }
    }
}