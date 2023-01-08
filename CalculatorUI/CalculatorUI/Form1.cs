using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenericCalculator;

namespace CalculatorUI
{
    public partial class Form1 : Form
    {
        private readonly InputHandler _inputObject = new InputHandler();
        public Form1()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        private void AcceptInput(string s)
        {
            if (this.textBox2.Text.Length > 10)
            {
                return;
            }
            this.textBox2.Text += s;
        }

        private void ResetInput()
        {
            _inputObject.firstNumber = 0;
            _inputObject.secondNumber = 0;
            _inputObject.requestedOperation = CalculatorOperation.None;
        }

        private void ProcessOperation(CalculatorOperation operation)
        {
            try
            {
                _inputObject.firstNumber = System.Convert.ToDouble(this.textBox2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid numeric input");
                return;
            }
            if (_inputObject.firstNumber == 0)
            {
                return;
            }
            
            _inputObject.requestedOperation = operation;
            this.textBox2.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AcceptInput("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AcceptInput("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AcceptInput("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AcceptInput("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AcceptInput("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AcceptInput("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Math.Sqrt(7);
            AcceptInput("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AcceptInput("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AcceptInput("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            AcceptInput("0");
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            AcceptInput(".");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ProcessOperation(CalculatorOperation.Add);
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            ProcessOperation(CalculatorOperation.Subtract);
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            ProcessOperation(CalculatorOperation.Multiply);
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            ProcessOperation(CalculatorOperation.Divide);
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            try
            {
                _inputObject.secondNumber = System.Convert.ToDouble(this.textBox2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid numeric input");
                return;
            }
            if (_inputObject.requestedOperation == CalculatorOperation.None)
            {
                return;
            }

            this.textBox2.Text = string.Empty;
            var cal = new Calculate();
            switch (_inputObject.requestedOperation)
            {
                case CalculatorOperation.Add:
                    this.textBox2.Text = cal.Add(_inputObject.firstNumber, _inputObject.secondNumber).ToString();
                    break;
                case CalculatorOperation.Subtract:
                    this.textBox2.Text = cal.Subtract(_inputObject.firstNumber, _inputObject.secondNumber).ToString();
                    break;
                case CalculatorOperation.Multiply:
                    this.textBox2.Text = cal.Multiply(_inputObject.firstNumber, _inputObject.secondNumber).ToString();
                    break;
                case CalculatorOperation.Divide:
                    this.textBox2.Text = cal.Divide(_inputObject.firstNumber, _inputObject.secondNumber).ToString();
                    break;
                case CalculatorOperation.None:
                default:
                    break;
            }

            ResetInput();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = string.Empty;
            ResetInput();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        { if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if (textBox2.Text.Length > 10 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
