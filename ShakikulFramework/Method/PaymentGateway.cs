using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShakikulFramework.Method
{
    public partial class PaymentGateway : UserControl
    {
        private static string _paymentMethod = "";
        private static string _accountNumber = "";
        private static DateTime _transactionDate;
        private static double _amount = 0;
        private static string _transactionId = "";
        private static string _bankName = "";
        private static string _bankBranchName = "";
        private static string _bankAccountName = "";
        private static string _checkNumber = "";
        private static string _cardHolderName = "";
        private static string _cardNumber = "";

        //Property
        public static string PaymentMethod { get { return _paymentMethod; } }
        public static string AccountNumber { get { return _accountNumber; } }
        public static DateTime TransactionDate { get { return _transactionDate; } }
        public static double Amount { get { return _amount; } }
        public static string TransactionId { get { return _transactionId; } }
        public static string BankName { get { return _bankName; } }
        public static string BankBranchName { get { return _bankBranchName; } }
        public static string BankAccountName { get { return _bankAccountName; } }
        public static string CheckNumber { get { return _checkNumber; } }
        public static string CardHolderName { get { return _cardHolderName; } }
        public static string CardNumber { get { return _cardNumber; } }


        public PaymentGateway()
        {
            InitializeComponent();

            comboBoxGatewayList.DataSource = new[]
            {
                "Cash",
                "bKash",
                "Rocket",
                "Card",
                "Check"
            };

            dateTimePickerTransactionDate.MaxDate = DateTime.Now;
        }
        
        private void ShowPanel(Control panel)
        {
            foreach (var panels in Controls.OfType<Panel>())
            {
                foreach (var textBox in panels.Controls.OfType<TextBox>())
                {
                    textBox.Clear();
                }
                panels.Visible = false;
            }

            textBoxAccountNo.Enabled = true;
            dateTimePickerTransactionDate.Enabled = true;

            panel.Location = new Point(8, 126);
            panel.Size = new Size(390, panel.Height);
            panel.Visible = true;
            textBoxAccountNo.Focus();
            buttonValidity.Location = new Point(312, panel.Location.Y + panel.Height);
        }
        
        private void comboBoxGatewayList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                _paymentMethod = comboBoxGatewayList.Text;
                switch (PaymentMethod)
                {
                    case "Cash":
                    {
                        foreach (var panel in Controls.OfType<Panel>())
                        {
                            foreach (var textBox in panel.Controls.OfType<TextBox>())
                            {
                                textBox.Clear();
                            }
                            panel.Visible = false;
                        }
                        textBoxAccountNo.Enabled = false;
                        dateTimePickerTransactionDate.Enabled = false;
                        buttonValidity.Location = new Point(317, 91);
                        textBoxAmount.SelectAll();
                        textBoxAmount.Focus();
                        break;
                    }
                    case "bKash":
                    {
                        ShowPanel(panelMobileBanking);
                        break;
                    }
                    case "Rocket":
                    {
                        ShowPanel(panelMobileBanking);
                        break;
                    }
                    case "Card":
                    {
                        ShowPanel(panelCard);
                        textBoxAccountNo.Enabled = false;
                        break;
                    }
                    case "Check":
                    {
                        ShowPanel(panelCheck);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonValidity_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(PaymentMethod))
                {
                    switch (PaymentMethod)
                    {
                        case "Cash":
                        {
                            _amount = Convert.ToDouble(textBoxAmount.Text.Trim());
                            if (Amount<=0)
                            {
                                textBoxAmount.Focus();
                                textBoxAmount.SelectAll();
                                throw new Exception("Please enter amount and try again");
                            }
                            break;
                        }
                        case "bKash":
                        {
                            _accountNumber = textBoxAccountNo.Text.Trim();
                            _transactionDate = dateTimePickerTransactionDate.Value;
                            _amount = Convert.ToDouble(textBoxAmount.Text.Trim());
                            _transactionId = textBoxTransactionId.Text.Trim();
                            if (string.IsNullOrEmpty(AccountNumber))
                            {
                                textBoxAccountNo.Focus();
                                textBoxAccountNo.SelectAll();
                                throw new Exception("Please enter account number");
                            }
                            if (Amount<=0)
                            {
                                textBoxAmount.Focus();
                                textBoxAmount.SelectAll();
                                throw new Exception("Please enter amount");
                            }
                            if (string.IsNullOrEmpty(TransactionId))
                            {
                                textBoxTransactionId.Focus();
                                textBoxTransactionId.SelectAll();
                                throw new Exception("Please enter Transaction ID");
                            }
                            break;
                        }
                        case "Rocket":
                        {
                            _accountNumber = textBoxAccountNo.Text.Trim();
                            _transactionDate = dateTimePickerTransactionDate.Value;
                            _amount = Convert.ToDouble(textBoxAmount.Text.Trim());
                            _transactionId = textBoxTransactionId.Text.Trim();
                            if (string.IsNullOrEmpty(AccountNumber))
                            {
                                textBoxAccountNo.Focus();
                                textBoxAccountNo.SelectAll();
                                throw new Exception("Please enter account number");
                            }
                            if (Amount <= 0)
                            {
                                textBoxAmount.Focus();
                                textBoxAmount.SelectAll();
                                throw new Exception("Please enter amount");
                            }
                            if (string.IsNullOrEmpty(TransactionId))
                            {
                                textBoxTransactionId.Focus();
                                textBoxTransactionId.SelectAll();
                                throw new Exception("Please enter Transaction ID");
                            }
                            break;
                        }
                        case "Card":
                        {
                            _transactionDate = dateTimePickerTransactionDate.Value;
                            _amount = Convert.ToDouble(textBoxAmount.Text.Trim());
                            _cardHolderName = textBoxCardHolderName.Text.Trim();
                            _cardNumber = textBoxCardNumber.Text.Trim();
                            
                            if (Amount <= 0)
                            {
                                textBoxAmount.Focus();
                                textBoxAmount.SelectAll();
                                throw new Exception("Please enter amount");
                            }
                            if (string.IsNullOrEmpty(CardHolderName))
                            {
                                textBoxCardHolderName.Focus();
                                textBoxCardHolderName.SelectAll();
                                throw new Exception("Please enter card holder name");
                            }
                            if (string.IsNullOrEmpty(CardNumber))
                            {
                                textBoxCardNumber.Focus();
                                textBoxCardNumber.SelectAll();
                                throw new Exception("Please enter card number");
                            }
                            break;
                        }
                        case "Check":
                        {
                            _accountNumber = textBoxAccountNo.Text.Trim();
                            _transactionDate = dateTimePickerTransactionDate.Value;
                            _amount = Convert.ToDouble(textBoxAmount.Text.Trim());
                            _bankName = textBoxBankName.Text.Trim();
                            _bankBranchName = textBoxBankBranchName.Text.Trim();
                            _bankAccountName = textBoxBankAccountName.Text.Trim();
                            _cardNumber = textBoxCheckNumber.Text.Trim();
                            if (string.IsNullOrEmpty(AccountNumber))
                            {
                                textBoxAccountNo.Focus();
                                textBoxAccountNo.SelectAll();
                                throw new Exception("Please enter account number");
                            }
                            if (Amount <= 0)
                            {
                                textBoxAmount.Focus();
                                textBoxAmount.SelectAll();
                                throw new Exception("Please enter amount");
                            }
                            if (string.IsNullOrEmpty(BankName))
                            {
                                textBoxBankBranchName.Focus();
                                textBoxBankBranchName.SelectAll();
                                throw new Exception("Please enter bank name");
                            }
                            if (string.IsNullOrEmpty(BankBranchName))
                            {
                                textBoxBankBranchName.Focus();
                                textBoxBankBranchName.SelectAll();
                                throw new Exception("Please enter bank branch name");
                            }
                            if (string.IsNullOrEmpty(BankAccountName))
                            {
                                textBoxBankAccountName.Focus();
                                textBoxBankAccountName.SelectAll();
                                throw new Exception("Please enter bank account name");
                            }
                            if (string.IsNullOrEmpty(CheckNumber))
                            {
                                textBoxCheckNumber.Focus();
                                textBoxCheckNumber.SelectAll();
                                throw new Exception("Please enter check number");
                            }
                            break;
                        }
                    }
                }
                else
                {
                    throw new Exception("Please select payment method and try again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBoxAmount.Text.Trim()) > 0) return;
                textBoxAmount.Text = "0.00";
                textBoxAmount.SelectAll();
            }
            catch
            {
                textBoxAmount.Text = "0.00";
                textBoxAmount.SelectAll();
            }
        }

        private void textBoxCardNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBoxCardNumber.Text.Trim()) > 0) return;
                textBoxCardNumber.Clear();
            }
            catch
            {
                textBoxAmount.Clear();
            }
        }


    }
}
