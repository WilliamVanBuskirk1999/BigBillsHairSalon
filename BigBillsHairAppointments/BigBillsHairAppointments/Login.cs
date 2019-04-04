using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BigBillsHairAppointments
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

            this.Text = Application.ProductName;

            if (Properties.Settings.Default.Password != string.Empty)
            {
                txtPassword.Text = Properties.Settings.Default.Password;
                chkRemember.Checked = true;
            }
        }

        private bool LoginAuthentication(string username, string password)
        {
            string sql = string.Format("SELECT cast(1 as bit) FROM Authenticate WHERE username = '{0}' AND password = '{1}'", username, password);

            if (GETDATA(sql, "authenticate").Tables[0].Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private DataSet GETDATA(string sqlStatement, string tableName)
        {
            SqlConnection cnn = new SqlConnection(Properties.Settings.Default.cnnString);
            SqlCommand cmd = new SqlCommand(sqlStatement, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds, tableName);
            return ds;
        }
        int max = 0;
        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (LoginAuthentication(txtUsername.Text, txtPassword.Text).Equals(true))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                max += 1;
                if (max >= 3)
                {
                    DialogResult = DialogResult.Cancel;
                }
                txtPassword.Focus();
                txtPassword.SelectAll();

                if (chkRemember.Checked == true && LoginAuthentication(txtUsername.Text, txtPassword.Text).Equals(true))
                {
                    Properties.Settings.Default.Password = txtPassword.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Password = string.Empty;
                    Properties.Settings.Default.Save();
                }
            }

        }
        private void Login_Leave(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}




