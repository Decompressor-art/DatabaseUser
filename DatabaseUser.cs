using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decompression
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
       
         

            public void btnOK_Click(object sender, EventArgs e)
        {
                if (!string.IsNullOrWhiteSpace(loginTextBox.Text) && !string.IsNullOrWhiteSpace(passwordTextBox.Text))
                    {
                    var ops = new DatabaseUser("N10468000115\\SQLHUNTER", "demo");
                    var loginResults = ops.SqlCredentialLogin(loginTextBox.Text, passwordTextBox.Text);
                    if (loginResults)
                      {

                        var successValue = ops.DoWork(passwordTextBox.Text, loginTextBox.Text);
                        var workResult = string.IsNullOrWhiteSpace(successValue);
                        
                            if (workResult)
                            {
                                Hide();
                                Form MW = new MainWindow();
                                MW.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show(successValue);
                            }
                        
                      }
                    }
        }
    }
}
