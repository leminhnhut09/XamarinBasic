using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBasic.Source.Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CaculatorPage : ContentPage
    {
        private bool isOperatorClicked;
        private bool isShowResult;
        private decimal firstNumber;
        private string operatorName;
        public CaculatorPage()
        {
            InitializeComponent();
        }

        private void btnCommon_Clicked(object sender, EventArgs e)
        {
            Button buttonClick = (Button)sender;
            if (isShowResult)
            {
                isShowResult = false;
                lblResult.Text = "0";
                lblSubResult.Text = "";
            }

            if (lblResult.Text.Trim().Equals("0") || isOperatorClicked)
            {
                isOperatorClicked = false;
                lblResult.Text = buttonClick.Text;
            }
            else
            {
                lblResult.Text += buttonClick.Text;
            }
        }

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            lblResult.Text = "0";
            lblSubResult.Text = "";
            isOperatorClicked = false;
            firstNumber = 0;
        }

        private void btnDel_Clicked(object sender, EventArgs e)
        {
            string number = lblResult.Text;
            if (number != "0")
            {
                number = number.Remove(number.Length - 1, 1);
                if (String.IsNullOrEmpty(number))
                {
                    lblResult.Text = "0";
                    lblSubResult.Text = "";
                    isOperatorClicked = false;
                    firstNumber = 0;
                }
                else
                {
                    lblResult.Text = number;
                }
            }
        }

        private async void btnPercent_Clicked(object sender, EventArgs e)
        {
            try
            {
                string number = lblResult.Text;
                if (number != "0")
                {
                    decimal percent = decimal.Parse(number);
                    lblResult.Text = (percent / 100).ToString();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Notification", ex.Message, "Ok");
            }

        }
        private void btnOperator_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            isOperatorClicked = true;
            operatorName = button.Text;
            firstNumber = decimal.Parse(lblResult.Text);
            if (isShowResult)
            {
                isShowResult = false;
                lblSubResult.Text = firstNumber + " " + button.Text;
            }
            else
            {
                lblSubResult.Text += lblResult.Text + " " + button.Text;
            }
            
        }

        private async void btnEqual_Clicked(object sender, EventArgs e)
        {
            try
            {
                if(isShowResult == false)
                {
                    lblSubResult.Text = lblSubResult.Text + lblResult.Text + " = ";
                    isShowResult = true;
                    decimal secondNumber = decimal.Parse(lblResult.Text);
                    lblResult.Text = Calculate(firstNumber, secondNumber).ToString();
                    firstNumber = 0;
                }
                
            }
            catch(Exception ex)
            {
               await DisplayAlert("Notification", ex.Message, "Cancel");
            }
        }
        public decimal Calculate(decimal theFirst, decimal theSecond)
        {
            decimal result = 0;
            switch (operatorName)
            {
                case "+":
                    result = theFirst + theSecond;
                    break;
                case "-":
                    result = theFirst - theSecond;
                    break;
                case "x":
                    result = theFirst * theSecond;
                    break;
                case "/":
                    result = theFirst / theSecond;
                    break;
                default:
                    break;
            }
            return result;
        }

        private void btnConvert_Clicked(object sender, EventArgs e)
        {
            isOperatorClicked = false;
            firstNumber = 0;
            lblResult.Text = (-(decimal.Parse(lblResult.Text))).ToString(); 
        }
    }
}