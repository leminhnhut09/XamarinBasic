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
    public partial class HtmlWebView : ContentPage
    {
        public HtmlWebView()
        {
            InitializeComponent();
            var htmlWebView = new HtmlWebViewSource();
            htmlWebView.Html = @"<html>
                                      <body>
                                           <h1>HTML</h1>
                                      </body>
                                </html>";
            wvHtmlView.Source = htmlWebView;
        }
    }
}