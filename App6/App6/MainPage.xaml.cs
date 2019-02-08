using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App6
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string mathOp;
        double firstNum, secondNum;

        public MainPage()
        {
            InitializeComponent();
            AllClear(this, null);
        }

        void OnClickNum(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (this.Compute.Text == "0" || currentState < 0)
            {
                this.Compute.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }

            this.Compute.Text += pressed;

            double number;
            if (double.TryParse(this.Compute.Text, out number))
            {
                this.Compute.Text = number.ToString("N0");
                if (currentState == 1)
                {
                    firstNum = number;
                }
                else
                {
                    secondNum = number;
                }


            }
        }

        void Calculator(object sender, EventArgs e)
        {
            if (currentState ==2)
            {
                double result = 0.0;


                if (mathOp == "/")
                    result = (firstNum / secondNum);
                if (mathOp == "X")
                    result = (firstNum * secondNum);
                if (mathOp == "+")
                    result = (firstNum + secondNum);
                if (mathOp == "-")
                    result = (firstNum - secondNum);

                this.Compute.Text = result.ToString();   
                firstNum = result;   
                currentState = -1;
            }
        }


        void AllClear(object sender, EventArgs e)
        {
            firstNum = 0;
            secondNum = 0;
            currentState = 1;
            this.Compute.Text = "0";

        }


         void OnClickOp(object sender, EventArgs e)
        {
            currentState = -2;
            
            Button button = (Button)sender;
            string pressed = button.Text;

            mathOp = pressed;

            
        }



    }


}
