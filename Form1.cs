using System.Data;
using System.Text;

namespace Calculator_assignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string modify(string s)
        {
            string temp = "";
            foreach (char c in s)
            {
                if (c == '×')
                {
                    temp += '*';
                }
                else if (c == '÷')
                {
                    temp += '/';

                }
                else
                {
                    temp += c;

                }
            }
            return temp;
        }
        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                var temp = textBox2.Text;
                string temp2 = modify(temp);
                try
                {
                    double ans = Solve(temp2);
                    textBox1.Text = ans.ToString() + " ";
                    textBox3.Text = "";
                }
                catch (Exception)
                {
                    textBox1.Text = "SYNTAX ERROR ";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox2.Text += "1";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox2.Text += "0";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox2.Text += "2";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox2.Text += "3";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Text += "4";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox2.Text += "5";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox2.Text += "6";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text += "7";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text += "8";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text += "9";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox2.Text += ".";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox2.Text += "÷";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Text += "×";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text += "-";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text += "+";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 0) {
                textBox3.Text = "";
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
            if(e.KeyChar == '*')
            {
                textBox2.Text += "×";
                textBox2.SelectionStart = textBox2.Text.Length;
            }
            if(e.KeyChar == '/')
            {
                textBox2.Text += "÷";
                textBox2.SelectionStart = textBox2.Text.Length;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                var temp = textBox2.Text;
                string temp2 = modify(temp);

                try
                {
                    double ans = Solve(temp2);
                    if (textBox3.Text == "BIN")
                    {
                        textBox1.Text = ans.ToString() + " ";
                        textBox3.Text = "";
                    }
                    else
                    {
                        textBox3.Text = "BIN";
                        string bin = ToBinary(ans);
                        textBox1.Text = bin.ToString() + " ";
                    }
                }
                catch (Exception)
                {
                    textBox3.Text = "";
                    textBox1.Text = "SYNTAX ERROR ";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                var temp = textBox2.Text;
                string temp2 = modify(temp);

                try
                {
                    double ans = Solve(temp2);
                    if (textBox3.Text == "OCT")
                    {
                        textBox1.Text = ans.ToString() + " ";
                        textBox3.Text = "";
                    }
                    else
                    {
                        textBox3.Text = "OCT";
                        string oct = ToOctal(ans);
                        textBox1.Text = oct.ToString() + " ";
                    }
                }
                catch (Exception)
                {
                    textBox3.Text = "";
                    textBox1.Text = "SYNTAX ERROR ";
                }                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                var temp = textBox2.Text;
                string temp2 = modify(temp);

                try
                {
                    double ans = Solve(temp2);
                    if (textBox3.Text == "HEX")
                    {
                        textBox1.Text = ans.ToString() + " ";
                        textBox3.Text = "";
                    }
                    else
                    {
                        textBox3.Text = "HEX";
                        string hex = ToHexaDecimal(ans);
                        textBox1.Text ="0x" + hex.ToString() + " ";
                    }
                }
                catch (Exception)
                {
                    textBox3.Text = "";
                    textBox1.Text = "SYNTAX ERROR ";
                }           
            }
        }

        private string ToBinary(double n)
        {
            long intValue = (long) n; 
            return Convert.ToString(intValue, 2);
        }
        private string ToOctal(double n)
        {
            long intValue = (long) n;
            return Convert.ToString(intValue, 8);
        }
        private string ToHexaDecimal(double n)
        {
            long intValue = (long) n;
            return intValue.ToString("X");
        }

        private double Solve(string s)
        {
            DataTable dataTable = new DataTable();
                object result = dataTable.Compute(s, "");
                    return Convert.ToDouble(result);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
       
        }
    }
}
