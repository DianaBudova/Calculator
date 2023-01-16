namespace Calculator
{
    public partial class Form1 : Form
    {
        private double? result;
        private string? lastUsedOperator;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = "0";
            this.result = null;
            this.lastUsedOperator = null;
        }

        private void C_Click(object sender, EventArgs e) => Form1_Load(sender, e);

        private void Abs_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "0" && double.TryParse(this.textBox1.Text, out double temp))
            {
                temp *= -1;
                this.textBox1.Text = temp.ToString();
            }
        }

        private void RemoveLastChar_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "0" && this.textBox1.Text != "0," && !ContainsOperators())
            {
                if (this.textBox1.Text.Length == 1)
                {
                    Form1_Load(sender, e);
                    return;
                }
                this.textBox1.Text = this.textBox1.Text.Remove(this.textBox1.Text.Length - 1);
            }
        }

        private void AdditionOperator_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Contains("+"))
                return;
            this.lastUsedOperator = ((Button)sender).Text;
            if (result == null)
                result = double.Parse(this.textBox1.Text);
            else
                result += double.Parse(this.textBox1.Text);
            this.textBox1.Text += " +";
        }

        private void SubstractionOperator_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Contains("-"))
                return;
            this.lastUsedOperator = ((Button)sender).Text;
            if (result == null)
                result = double.Parse(this.textBox1.Text);
            else
                result -= double.Parse(this.textBox1.Text);
            this.textBox1.Text += " -";
        }

        private void MultiplicationOperator_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Contains("*"))
                return;
            this.lastUsedOperator = ((Button)sender).Text;
            if (result == null)
                result = double.Parse(this.textBox1.Text);
            else
                result *= double.Parse(this.textBox1.Text);
            this.textBox1.Text += " *";
        }

        private void DivisionOperator_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Contains("/"))
                return;
            this.lastUsedOperator = ((Button)sender).Text;
            double num = double.Parse(this.textBox1.Text);
            if (result == null)
                result = num;
            else
            {
                if (num == 0)
                {
                    Form1_Load(sender, e);
                    return;
                }
                result /= double.Parse(this.textBox1.Text);
            }
            this.textBox1.Text += " /";
        }

        private void EqualsOperator_Click(object sender, EventArgs e)
        {
            if (this.result == null)
            {
                Form1_Load(sender, e);
                return;
            }
            switch (this.lastUsedOperator)
            {
                case "+":
                    AdditionOperator_Click(sender, e);
                    break;
                case "-":
                    SubstractionOperator_Click(sender, e);
                    break;
                case "*":
                    MultiplicationOperator_Click(sender, e);
                    break;
                case "/":
                    DivisionOperator_Click(sender, e);
                    break;
            }
            this.textBox1.Text = this.result.ToString();
            this.result = null;
            this.lastUsedOperator = null;
        }

        private void Number_Click(object sender, EventArgs e)
        {
            string textofTextBox = ((Button)sender).Text;
            if (this.textBox1.Text == "0" && textofTextBox == "0")
                return;
            else if (this.textBox1.Text == "0" || ContainsOperators())
                this.textBox1.Text = "";
            this.textBox1.Text += textofTextBox;
        }

        private void FloatNumber_Click(object sender, EventArgs e)
        {
            if (!ContainsOperators() && !this.textBox1.Text.Contains(","))
                this.textBox1.Text += ",";
        }

        private bool ContainsOperators()
        {
            if (this.textBox1.Text.Contains("+") ||
                this.textBox1.Text.Contains("-") ||
                this.textBox1.Text.Contains("*") ||
                this.textBox1.Text.Contains("/"))
                return true;
            return false;
        }
    }
}