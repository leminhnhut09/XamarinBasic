using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBasic.Source.Tuan1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculator : ContentPage
    {
        private bool isOperatorClicked;
        private bool isShowResult;
        private decimal firstNumber;
        private string operatorName;
        public Calculator()
        {
            InitializeComponent();
        }

        private void OnPercentButtonClicked(object sender, EventArgs e)
        {
            try
            {
                string number = resultLabel.Text;
                if (number != "0")
                {
                    decimal percent = decimal.Parse(number);
                    resultLabel.Text = (percent / 100).ToString();
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Notification", ex.Message, "Ok");
            }
        }

        private void OnClearButtonClicked(object sender, EventArgs e)
        {
            resultLabel.Text = "0";
            subResultLabel.Text = "";
            isOperatorClicked = false;
            firstNumber = 0;
        }

        private void OnDelButtonClicked(object sender, EventArgs e)
        {
            string number = resultLabel.Text;
            if (number != "0")
            {
                number = number.Remove(number.Length - 1, 1);
                if (String.IsNullOrEmpty(number))
                {
                    resultLabel.Text = "0";
                    subResultLabel.Text = "";
                    isOperatorClicked = false;
                    firstNumber = 0;
                }
                else
                {
                    resultLabel.Text = number;
                }
            }
        }

        private void OnOperatorButtonClick(object sender, EventArgs e)
        {
            //Button button = sender as Button(); 
            // Correct -> không có giá trị -> null

            //  Button button = (Button)sender;
            // Avoid -> không có giá trị -> error
            Button button = (Button)sender;
            isOperatorClicked = true;
            operatorName = button.Text;
            firstNumber = decimal.Parse(resultLabel.Text);
            if (isShowResult)
            {
                isShowResult = false;
                subResultLabel.Text = firstNumber + " " + button.Text;
            }
            else
            {
                subResultLabel.Text += resultLabel.Text + " " + button.Text;
            }
        }

        private void OnCommonButtonClick(object sender, EventArgs e)
        {
            Button buttonClick = (Button)sender;
            if (isShowResult)
            {
                isShowResult = false;
                resultLabel.Text = "0";
                subResultLabel.Text = "";
            }

            if (resultLabel.Text.Trim().Equals("0") || isOperatorClicked)
            {
                isOperatorClicked = false;
                resultLabel.Text = buttonClick.Text;
            }
            else
            {
                resultLabel.Text += buttonClick.Text;
            }
        }

        private void OnConvertButtonClick(object sender, EventArgs e)
        {
            isOperatorClicked = false;
            firstNumber = 0;
            resultLabel.Text = (-(decimal.Parse(resultLabel.Text))).ToString();
        }

        private void OnEqualButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (isShowResult == false)
                {
                    subResultLabel.Text = subResultLabel.Text + resultLabel.Text + " = ";
                    isShowResult = true;
                    decimal secondNumber = decimal.Parse(resultLabel.Text);
                    resultLabel.Text = Calculate(firstNumber, secondNumber).ToString();
                    firstNumber = 0;
                }

            }
            catch (Exception ex)
            {
                DisplayAlert("Notification", ex.Message, "Cancel");
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
    }
}