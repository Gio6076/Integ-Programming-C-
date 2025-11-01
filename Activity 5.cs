using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ebs_Lab_3
{
    public partial class Activity5 : Form
    {
        private string picpath;
        private Double basic_netincome = 0.00,
            basic_numhrs = 0.00,
            basic_rate = 0.00,
            hono_netincome = 0.00,
            hono_numhrs = 0.00,
            hono_rate = 0.00,
            other_netincome = 0.00,
            other_numhrs = 0.00,
            other_rate = 0.00;

        private Double netincome = 0.00,
            grossincome = 0.00,
            sss_contrib = 0.00,
            pagibig_contrib = 0.00,
            philhealth_contrib = 0.00,
            tax_contrib = 0.00;

        private void emp_nuTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void other_netincomeTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        //private void others_loanCombo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (others_loanCombo.Text == "Other 1")
        //    {
        //        others_loanTxtbox.Text = "500.00";
        //    }
        //    else if (others_loanCombo.Text == "Other 2")
        //    {
        //        others_loanTxtbox.Text = "550.00";
        //    }
        //    else if (others_loanCombo.Text == "Other 3")
        //    {
        //        others_loanTxtbox.Text = "1550.00";
        //    }
        //    else if (others_loanCombo.Text == "Other 4")
        //    {
        //        others_loanTxtbox.Text = "1250.00";
        //    }
        //    else
        //    {
        //        MessageBox.Show("No other loan option selected!");
        //    }
        //}

        private void payslip_viewListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void net_income_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for empty required fields
                if (string.IsNullOrWhiteSpace(sss_contribTxtbox.Text) ||
                    string.IsNullOrWhiteSpace(pagibig_contribTxtbox.Text) ||
                    string.IsNullOrWhiteSpace(philhealth_contribTxtbox.Text) ||
                    string.IsNullOrWhiteSpace(tax_contribTxtbox.Text) ||
                    string.IsNullOrWhiteSpace(sss_loanTxtbox.Text) ||
                    string.IsNullOrWhiteSpace(pagibig_loanTxtbox.Text))
                {
                    MessageBox.Show("Please fill in all required contribution and loan fields before calculating.",
                                    "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Proceed only if all inputs are valid numbers
                sss_contrib = Convert.ToDouble(sss_contribTxtbox.Text);
                pagibig_contrib = Convert.ToDouble(pagibig_contribTxtbox.Text);
                philhealth_contrib = Convert.ToDouble(philhealth_contribTxtbox.Text);
                tax_contrib = Convert.ToDouble(tax_contribTxtbox.Text);
                sss_loan = Convert.ToDouble(sss_loanTxtbox.Text);
                pagibig_loan = Convert.ToDouble(pagibig_loanTxtbox.Text);
                salary_loan = Convert.ToDouble(sal_loanTxtbox.Text);
                faculty_sav_loan = Convert.ToDouble(FS_loanTxtbox.Text);
                salary_savings = Convert.ToDouble(FSD_depositTxtbox.Text);
                other_deduction = Convert.ToDouble(others_loanTxtbox.Text);

                total_contrib = sss_contrib + pagibig_contrib + philhealth_contrib + tax_contrib;
                total_loan = sss_loan + pagibig_loan + salary_loan + faculty_sav_loan + salary_savings + other_deduction;
                total_deduction = total_contrib + total_loan;

                total_deducTxtbox.Text = total_deduction.ToString("n");
                netincome = grossincome - total_deduction;
                net_incomeTxtbox.Text = netincome.ToString("n");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please make sure all fields contain valid numeric values before calculating.",
                                "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Double sss_loan = 0.00,
            pagibig_loan = 0.00,
            salary_loan = 0.00,
            salary_savings = 0.00,
            faculty_sav_loan = 0.00,
            other_deduction = 0.00,
            total_deduction = 0.00,
            total_contrib = 0.00,
            total_loan = 0.00;

        public Activity5()
        {
            InitializeComponent();
        }

        private void basic_numhrsTxtbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(basic_numhrsTxtbox.Text) || string.IsNullOrWhiteSpace(basic_rateTxtbox.Text))
                {
                    basic_netincomeTxtbox.Clear();
                    return;
                }
                if (double.TryParse(basic_numhrsTxtbox.Text, out basic_numhrs) && double.TryParse(basic_rateTxtbox.Text, out basic_rate))
                {
                    basic_netincome = basic_numhrs * basic_rate;
                    basic_netincomeTxtbox.Text = basic_netincome.ToString("n");
                }
                else
                {
                    basic_netincomeTxtbox.Clear();
                    MessageBox.Show($"Please enter numeric values only for Basic Pay rate or hours. {MessageBoxButtons.OK} {MessageBoxIcon.Warning}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.Message} Input Error {MessageBoxButtons.OK} {MessageBoxIcon.Error}");
            }

            //basic_numhrs = Double .Parse(basic_numhrsTxtbox.Text);
            //basic_rate = Convert.ToDouble(basic_rateTxtbox.Text);
            //basic_netincome = basic_numhrs * basic_rate;
            //basic_netincomeTxtbox.Text = basic_netincome.ToString("n");
        }

        private void hono_numhrsTxtbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(hono_numhrsTxtbox.Text) || string.IsNullOrWhiteSpace(hono_rateTxtbox.Text))
                {
                    hono_netincomeTxtbox.Clear();
                    return;
                }
                if (double.TryParse(hono_numhrsTxtbox.Text, out hono_numhrs) && double.TryParse(hono_rateTxtbox.Text, out hono_rate))
                {
                    hono_netincome = hono_numhrs * hono_rate;
                    hono_netincomeTxtbox.Text = hono_netincome.ToString("n");
                }
                else
                {
                    hono_netincomeTxtbox.Clear();
                    MessageBox.Show("Please enter numeric values only for Honorarium rate or hours.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //hono_numhrs = Convert.ToDouble(hono_numhrsTxtbox.Text);
                //hono_rate = Convert.ToDouble(hono_rateTxtbox.Text);
                //hono_netincome = hono_numhrs * hono_rate;
                //hono_netincomeTxtbox.Text = hono_netincome.ToString("n");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.Message} Input Error {MessageBoxButtons.OK} {MessageBoxIcon.Error}");
            }
        }

        private void other_numhrsTxtbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                other_numhrs = Convert.ToDouble(other_numhrsTxtbox.Text);
                other_rate = Convert.ToDouble(other_rateTxtbox.Text);
                other_netincome = other_numhrs * other_rate;
                other_netincomeTxtbox.Text = other_netincome.ToString("n");
                grossincome = basic_netincome + hono_netincome + other_netincome;
                gross_incomeTxtbox.Text = grossincome.ToString("n");

                //philheatl contribution based from the current table
                if (grossincome <= 10000)
                {
                    philhealth_contribTxtbox.Text = "137.50";
                }
                else if (grossincome > 10000 && grossincome <= 11000)
                {
                    philhealth_contribTxtbox.Text = "151.25";
                }
                else if (grossincome > 11000 && grossincome <= 12000)
                {
                    philhealth_contribTxtbox.Text = "165.00";
                }
                else if (grossincome > 12000 && grossincome <= 13000)
                {
                    philhealth_contribTxtbox.Text = "178.75";
                }
                else if (grossincome > 13000 && grossincome <= 14000)
                {
                    philhealth_contribTxtbox.Text = "192.50";
                }
                else if (grossincome > 14000 && grossincome <= 15000)
                {
                    philhealth_contribTxtbox.Text = "206.25";
                }
                else if (grossincome > 15000 && grossincome <= 16000)
                {
                    philhealth_contribTxtbox.Text = "220.00";
                }
                else if (grossincome > 16000 && grossincome <= 17000)
                {
                    philhealth_contribTxtbox.Text = "233.75";
                }
                else if (grossincome > 17000 && grossincome <= 18000)
                {
                    philhealth_contribTxtbox.Text = "247.50";
                }
                else if (grossincome > 18000 && grossincome <= 19000)
                {
                    philhealth_contribTxtbox.Text = "261.25";
                }
                else if (grossincome > 19000 && grossincome <= 20000)
                {
                    philhealth_contribTxtbox.Text = "275.00";
                }
                else if (grossincome > 20000 && grossincome <= 21000)
                {
                    philhealth_contribTxtbox.Text = "288.75";
                }
                else if (grossincome > 21000 && grossincome <= 22000)
                {
                    philhealth_contribTxtbox.Text = "302.50";
                }
                else if (grossincome > 22000 && grossincome <= 23000)
                {
                    philhealth_contribTxtbox.Text = "316.25";
                }
                else if (grossincome > 23000 && grossincome <= 24000)
                {
                    philhealth_contribTxtbox.Text = "330.00";
                }
                else if (grossincome > 24000 && grossincome <= 25000)
                {
                    philhealth_contribTxtbox.Text = "343.75";
                }
                else if (grossincome > 25000 && grossincome <= 26000)
                {
                    philhealth_contribTxtbox.Text = "357.50";
                }
                else if (grossincome > 26000 && grossincome <= 27000)
                {
                    philhealth_contribTxtbox.Text = "371.25";
                }
                else if (grossincome > 27000 && grossincome <= 28000)
                {
                    philhealth_contribTxtbox.Text = "385.00";
                }
                else if (grossincome > 28000 && grossincome <= 29000)
                {
                    philhealth_contribTxtbox.Text = "398.75";
                }
                else if (grossincome > 29000 && grossincome <= 30000)
                {
                    philhealth_contribTxtbox.Text = "412.50";
                }
                else if (grossincome > 30000 && grossincome <= 31000)
                {
                    philhealth_contribTxtbox.Text = "426.25";
                }
                else if (grossincome > 31000 && grossincome <= 32000)
                {
                    philhealth_contribTxtbox.Text = "440.00";
                }
                else if (grossincome > 32000 && grossincome <= 33000)
                {
                    philhealth_contribTxtbox.Text = "453.75";
                }
                else if (grossincome > 33000 && grossincome <= 34000)
                {
                    philhealth_contribTxtbox.Text = "467.50";
                }
                else if (grossincome > 34000 && grossincome <= 35000)
                {
                    philhealth_contribTxtbox.Text = "481.25";
                }
                else if (grossincome > 35000 && grossincome <= 36000)
                {
                    philhealth_contribTxtbox.Text = "495.00";
                }
                else if (grossincome > 36000 && grossincome <= 37000)
                {
                    philhealth_contribTxtbox.Text = "508.75";
                }
                else if (grossincome > 37000 && grossincome <= 38000)
                {
                    philhealth_contribTxtbox.Text = "522.50";
                }
                else if (grossincome > 38000 && grossincome <= 39000)
                {
                    philhealth_contribTxtbox.Text = "536.25";
                }
                else if (grossincome > 39000 && grossincome <= 39999.99)
                {
                    philhealth_contribTxtbox.Text = "543.13";
                }
                else
                {
                    philhealth_contribTxtbox.Text = "550.00";
                }

                //SSS contibution based on the current table from SSS
                if (grossincome < 1000)
                {
                    sss_contribTxtbox.Text = "0.00";
                }
                else if (grossincome > 1000 && grossincome <= 1249.99)
                {
                    sss_contribTxtbox.Text = "36.30";
                }
                else if (grossincome > 1000 && grossincome <= 1749.99)
                {
                    sss_contribTxtbox.Text = "54.50";
                }
                else if (grossincome > 1000 && grossincome <= 2249.99)
                {
                    sss_contribTxtbox.Text = "72.70";
                }
                else if (grossincome > 1000 && grossincome <= 2749.99)
                {
                    sss_contribTxtbox.Text = "90.80";
                }
                else if (grossincome > 1000 && grossincome <= 3249.99)
                {
                    sss_contribTxtbox.Text = "109.00";
                }
                else if (grossincome > 1000 && grossincome <= 3749.99)
                {
                    sss_contribTxtbox.Text = "127.20";
                }
                else if (grossincome > 1000 && grossincome <= 4249.99)
                {
                    sss_contribTxtbox.Text = "145.30";
                }
                else if (grossincome > 1000 && grossincome <= 4749.99)
                {
                    sss_contribTxtbox.Text = "163.50";
                }
                else if (grossincome > 1000 && grossincome <= 5249.99)
                {
                    sss_contribTxtbox.Text = "181.70";
                }
                else if (grossincome > 1000 && grossincome <= 5749.99)
                {
                    sss_contribTxtbox.Text = "199.80";
                }
                else if (grossincome > 1000 && grossincome <= 6249.99)
                {
                    sss_contribTxtbox.Text = "218.00";
                }
                else if (grossincome > 1000 && grossincome <= 6749.99)
                {
                    sss_contribTxtbox.Text = "236.29";
                }
                else if (grossincome > 1000 && grossincome <= 7249.99)
                {
                    sss_contribTxtbox.Text = "254.30";
                }
                else if (grossincome > 1000 && grossincome <= 7749.99)
                {
                    sss_contribTxtbox.Text = "272.50";
                }
                else if (grossincome > 1000 && grossincome <= 8249.99)
                {
                    sss_contribTxtbox.Text = "290.70";
                }
                else if (grossincome > 1000 && grossincome <= 8749.99)
                {
                    sss_contribTxtbox.Text = "308.80";
                }
                else if (grossincome > 1000 && grossincome <= 9249.99)
                {
                    sss_contribTxtbox.Text = "327.00";
                }
                else if (grossincome > 1000 && grossincome <= 9749.99)
                {
                    sss_contribTxtbox.Text = "345.20";
                }
                else if (grossincome > 1000 && grossincome <= 10249.99)
                {
                    sss_contribTxtbox.Text = "363.30";
                }
                else if (grossincome > 1000 && grossincome <= 10749.99)
                {
                    sss_contribTxtbox.Text = "381.50";
                }
                else if (grossincome > 1000 && grossincome <= 11249.99)
                {
                    sss_contribTxtbox.Text = "399.70";
                }
                else if (grossincome > 1000 && grossincome <= 11749.99)
                {
                    sss_contribTxtbox.Text = "417.80";
                }
                else if (grossincome > 1000 && grossincome <= 12249.99)
                {
                    sss_contribTxtbox.Text = "436.00";
                }
                else if (grossincome > 1000 && grossincome <= 12749.99)
                {
                    sss_contribTxtbox.Text = "454.20";
                }
                else if (grossincome > 1000 && grossincome <= 13249.99)
                {
                    sss_contribTxtbox.Text = "472.30";
                }
                else if (grossincome > 1000 && grossincome <= 13749.99)
                {
                    sss_contribTxtbox.Text = "490.50";
                }
                else if (grossincome > 1000 && grossincome <= 14249.99)
                {
                    sss_contribTxtbox.Text = "508.70";
                }
                else if (grossincome > 1000 && grossincome <= 14749.99)
                {
                    sss_contribTxtbox.Text = "526.80";
                }
                else if (grossincome > 1000 && grossincome <= 15249.99)
                {
                    sss_contribTxtbox.Text = "545.00";
                }
                else if (grossincome > 1000 && grossincome <= 15749.99)
                {
                    sss_contribTxtbox.Text = "563.20";
                }
                else
                    sss_contribTxtbox.Text = "581.30";

                //tax contribution per month based on new table of TAX 2019
                if (grossincome < (250000/24))
                {
                    tax_contribTxtbox.Text = "0.00";
                }
                else if (grossincome > 10416.67 && grossincome <= 16666.67)
                {
                    tax_contrib = ((((grossincome * 24) - 250000) * 0.20) / 24);
                    tax_contribTxtbox.Text = tax_contrib.ToString("n");
                }
                else if (grossincome > 16666.67 && grossincome <= 33333.33)
                {
                    tax_contrib = (((((grossincome * 24) - 400000) * 0.25) + 30000) / 24);
                    tax_contribTxtbox.Text = tax_contrib.ToString("n");
                }
                else if (grossincome > 33333.33 && grossincome <= 83333.33)
                {
                    tax_contrib = (((((grossincome * 24) - 800000) * 0.30) + 130000) / 24);
                    tax_contribTxtbox.Text = tax_contrib.ToString("n");
                }
                else if (grossincome > 83333.33 && grossincome <= 333333.33)
                {
                    tax_contrib = (((((grossincome * 24) - 2000000) * 0.32) + 490000) / 24);
                    tax_contribTxtbox.Text = tax_contrib.ToString("n");
                }
                else
                {
                    tax_contrib = (((((grossincome * 24) - 8000000) * 0.35) + 2410000) / 24);
                    tax_contribTxtbox.Text = tax_contrib.ToString("n");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Data Entry");
                other_numhrsTxtbox.Clear();
                other_numhrsTxtbox.Focus();
            }

        }

        private void New_Click(object sender, EventArgs e)
        {
            emp_nuTxtbox.Clear();
            firstnameTxtbox.Clear();
            MNameTxtbox.Clear();
            surTxtbox.Clear();
            civil_statusTxtbox.Clear();
            desigTxtbox.Clear();
            numDependentTxtbox.Clear();
            empStatusTxtbox.Clear();
            DeptNameTxtbox.Clear();
            basic_netincomeTxtbox.Clear();
            basic_numhrsTxtbox.Clear();
            basic_rateTxtbox.Clear();
            hono_netincomeTxtbox.Clear();
            hono_numhrsTxtbox.Clear();
            hono_rateTxtbox.Clear();
            other_netincomeTxtbox.Clear();
            other_numhrsTxtbox.Clear();
            other_rateTxtbox.Clear();
            net_incomeTxtbox.Clear();
            gross_incomeTxtbox.Clear();
            sss_contribTxtbox.Clear();
            pagibig_contribTxtbox.Clear();
            philhealth_contribTxtbox.Clear();
            tax_contribTxtbox.Clear();
            sss_loanTxtbox.Clear();
            pagibig_loanTxtbox.Clear();
            payslip_viewListBox.Items.Clear();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            emp_nuTxtbox.Clear();
            firstnameTxtbox.Clear();
            MNameTxtbox.Clear();
            surTxtbox.Clear();
            civil_statusTxtbox.Clear();
            desigTxtbox.Clear();
            numDependentTxtbox.Clear();
            empStatusTxtbox.Clear();
            DeptNameTxtbox.Clear();
            basic_netincomeTxtbox.Clear();
            basic_numhrsTxtbox.Clear();
            basic_rateTxtbox.Clear();
            hono_netincomeTxtbox.Clear();
            hono_numhrsTxtbox.Clear();
            hono_rateTxtbox.Clear();
            other_netincomeTxtbox.Clear();
            other_numhrsTxtbox.Clear();
            other_rateTxtbox.Clear();
            net_incomeTxtbox.Clear();
            gross_incomeTxtbox.Clear();
            sss_contribTxtbox.Clear();
            pagibig_contribTxtbox.Clear();
            philhealth_contribTxtbox.Clear();
            tax_contribTxtbox.Clear();
            sss_loanTxtbox.Clear();
            pagibig_loanTxtbox.Clear();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image File | * .gif; * .jpg; * .png; * .bmp";
            openFileDialog.Title = "Select Employee Picture";
            openFileDialog.ShowDialog();
            pictureBox2.Image = Image.FromFile(openFileDialog.FileName);
        }

        private void print_payslip_Click(object sender, EventArgs e)
        {

        }

        private void Preview_payslip_Click(object sender, EventArgs e)
        {
            payslip_viewListBox.Items.Add("Company: Lyceum of the Philippines University Cavite");
            payslip_viewListBox.Items.Add($"Employee Code: {emp_nuTxtbox.Text}");
            payslip_viewListBox.Items.Add($"Employee Name: {surTxtbox.Text}, {firstnameTxtbox.Text} {MNameTxtbox.Text}");
            payslip_viewListBox.Items.Add($"Department: {DeptNameTxtbox.Text}");
            payslip_viewListBox.Items.Add($"Cut Off: {paydateDatePickerTxtbox.Text}");
            payslip_viewListBox.Items.Add($"Pay Period: {paydateDatePickerTxtbox.Text}");
            payslip_viewListBox.Items.Add($"\n-----------------------------------------------------------------------------------------------------\n");

            payslip_viewListBox.Items.Add($"Basic Pay: ₱{basic_netincomeTxtbox.Text}");
            payslip_viewListBox.Items.Add($"");
            payslip_viewListBox.Items.Add($"Overtime: ₱{other_netincomeTxtbox.Text}");
            payslip_viewListBox.Items.Add("");
            payslip_viewListBox.Items.Add($"Honorarium: ₱{hono_netincomeTxtbox.Text}");
            payslip_viewListBox.Items.Add($"");
            payslip_viewListBox.Items.Add($"Honirarium Adjustment = 0");
            payslip_viewListBox.Items.Add($"");
            payslip_viewListBox.Items.Add($"Substitution = 0");
            payslip_viewListBox.Items.Add($"");
            payslip_viewListBox.Items.Add($"Tardy = 0");
            payslip_viewListBox.Items.Add($"");
            payslip_viewListBox.Items.Add("\n-----------------------------------------------------------------------------------------------------\n");
            payslip_viewListBox.Items.Add($"");
            payslip_viewListBox.Items.Add($"Tax Contribution: ₱{tax_contribTxtbox.Text}");
            payslip_viewListBox.Items.Add($"SSS Contribution: ₱{sss_contribTxtbox.Text}");
            payslip_viewListBox.Items.Add($"PhilHealth Contribution: ₱{philhealth_contribTxtbox.Text}");
            payslip_viewListBox.Items.Add($"Pagibig Contribution: ₱{pagibig_contribTxtbox.Text}");
            payslip_viewListBox.Items.Add($"SSS Loan: ₱{sss_loanTxtbox.Text}");
            payslip_viewListBox.Items.Add($"Pagibig Loan: ₱{pagibig_loanTxtbox.Text}");
            payslip_viewListBox.Items.Add($"Faculty Savings Deposit: ₱{FSD_depositTxtbox.Text}");
            payslip_viewListBox.Items.Add($"Faculty Savings Loan: ₱{FS_loanTxtbox.Text}");
            payslip_viewListBox.Items.Add($"Salary Loan: ₱{sal_loanTxtbox.Text}");
            payslip_viewListBox.Items.Add($"Other Loan: ₱{others_loanTxtbox.Text}");
            payslip_viewListBox.Items.Add($"");
            payslip_viewListBox.Items.Add("\n-----------------------------------------------------------------------------------------------------\n");
            payslip_viewListBox.Items.Add($"");
            payslip_viewListBox.Items.Add($"Total Deduction: ₱{total_deducTxtbox.Text}");
            payslip_viewListBox.Items.Add($"Gross Income: ₱{gross_incomeTxtbox.Text}");
            payslip_viewListBox.Items.Add($"Net Income: ₱{net_incomeTxtbox.Text}");
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for empty required fields
                if (string.IsNullOrWhiteSpace(sss_contribTxtbox.Text) ||
                    string.IsNullOrWhiteSpace(pagibig_contribTxtbox.Text) ||
                    string.IsNullOrWhiteSpace(philhealth_contribTxtbox.Text) ||
                    string.IsNullOrWhiteSpace(tax_contribTxtbox.Text) ||
                    string.IsNullOrWhiteSpace(sss_loanTxtbox.Text) ||
                    string.IsNullOrWhiteSpace(pagibig_loanTxtbox.Text))
                {
                    MessageBox.Show("Please fill in all required contribution and loan fields before calculating.",
                                    "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Proceed only if all inputs are valid numbers
                sss_contrib = Convert.ToDouble(sss_contribTxtbox.Text);
                pagibig_contrib = Convert.ToDouble(pagibig_contribTxtbox.Text);
                philhealth_contrib = Convert.ToDouble(philhealth_contribTxtbox.Text);
                tax_contrib = Convert.ToDouble(tax_contribTxtbox.Text);
                sss_loan = Convert.ToDouble(sss_loanTxtbox.Text);
                pagibig_loan = Convert.ToDouble(pagibig_loanTxtbox.Text);
                salary_loan = Convert.ToDouble(sal_loanTxtbox.Text);
                faculty_sav_loan = Convert.ToDouble(FS_loanTxtbox.Text);
                salary_savings = Convert.ToDouble(FSD_depositTxtbox.Text);
                other_deduction = Convert.ToDouble(others_loanTxtbox.Text);

                total_contrib = sss_contrib + pagibig_contrib + philhealth_contrib + tax_contrib;
                total_loan = sss_loan + pagibig_loan + salary_loan + faculty_sav_loan + salary_savings + other_deduction;
                //total_deduction = total_contrib + total_loan;

                //total_deducTxtbox.Text = total_deduction.ToString("n");
                //netincome = grossincome - total_deduction;
                //net_incomeTxtbox.Text = netincome.ToString("n");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please make sure all fields contain valid numeric values before calculating.",
                                "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            //sss_contrib = Convert.ToDouble(sss_contribTxtbox.Text);
            //pagibig_contrib = Convert.ToDouble(pagibig_contribTxtbox.Text);
            //philhealth_contrib = Convert.ToDouble(philhealth_contribTxtbox.Text);
            //tax_contrib = Convert.ToDouble(tax_contribTxtbox.Text);
            //sss_loan = Convert.ToDouble(sss_loanTxtbox.Text);
            //pagibig_loan = Convert.ToDouble(pagibig_loanTxtbox.Text);
            //salary_loan = Convert.ToDouble(sal_loanTxtbox.Text);
            //faculty_sav_loan = Convert.ToDouble(FS_loanTxtbox.Text);
            //salary_savings = Convert.ToDouble(FSD_depositTxtbox.Text);
            //other_deduction = Convert.ToDouble(others_loanTxtbox.Text);

            //total_contrib = sss_contrib + pagibig_contrib + philhealth_contrib + tax_contrib;
            //total_loan = sss_loan + pagibig_loan + salary_loan + faculty_sav_loan + salary_savings + other_deduction;
            //total_deduction = total_contrib + total_loan;

            //total_deducTxtbox.Text = total_deduction.ToString("n");
            //netincome = grossincome - total_deduction;
            //net_incomeTxtbox.Text = netincome.ToString("n");
        private void Activity5_Load(object sender, EventArgs e)
        {
            basic_netincomeTxtbox.Enabled = false;
            hono_netincomeTxtbox.Enabled = false;
            other_netincomeTxtbox.Enabled = false;
            net_incomeTxtbox.Enabled = false;
            gross_incomeTxtbox.Enabled = false;
            total_deducTxtbox.Enabled = false;
            sss_contribTxtbox.Text = "0.00";
            pagibig_contribTxtbox.Text = "0.00";
            philhealth_contribTxtbox.Text = "0.00";
            tax_contribTxtbox.Text = "0.00";
            sss_loanTxtbox.Text = "0.00";
            pagibig_loanTxtbox.Text = "0.00";
            FSD_depositTxtbox.Text = "0.00";
            FS_loanTxtbox.Text = "0.00";
            sal_loanTxtbox.Text = "0.00";
            others_loanTxtbox.Text = "0.00";
        }
    }
}
