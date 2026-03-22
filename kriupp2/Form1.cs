using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private double currentNumber = 0;
        private double previousNumber = 0;
        private string operation = "";
        private bool isNewNumber = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (isNewNumber)
            {
                textBoxResult.Text = btn.Text;
                isNewNumber = false;
            }
            else
            {
                textBoxResult.Text += btn.Text;
            }
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (!string.IsNullOrEmpty(textBoxResult.Text))
            {
                previousNumber = double.Parse(textBoxResult.Text);
            }

            operation = btn.Text;
            isNewNumber = true;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxResult.Text) || string.IsNullOrEmpty(operation))
                return;

            currentNumber = double.Parse(textBoxResult.Text);

            double result = 0;

            switch (operation)
            {
                case "+":
                    result = previousNumber + currentNumber;
                    break;
                case "-":
                    result = previousNumber - currentNumber;
                    break;
                case "×":
                    result = previousNumber * currentNumber;
                    break;
                case "÷":
                    if (currentNumber == 0)
                    {
                        MessageBox.Show("На ноль делить нельзя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxResult.Text = "0";
                        return;
                    }
                    result = previousNumber / currentNumber;
                    break;
            }

            textBoxResult.Text = result.ToString();
            isNewNumber = true;
            operation = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
            currentNumber = 0;
            previousNumber = 0;
            operation = "";
            isNewNumber = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (isNewNumber)
            {
                textBoxResult.Text = "0.";
                isNewNumber = false;
            }
            else if (!textBoxResult.Text.Contains("."))
            {
                textBoxResult.Text += ".";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
        }
    }
}