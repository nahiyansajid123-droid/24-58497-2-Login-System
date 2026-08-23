using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Login_and_Register
{
    public partial class frmRegister : Form
    {
        private static string myConn =
            ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmedPassword = txtConPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username cannot be empty.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password cannot be empty.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(confirmedPassword))
            {
                MessageBox.Show("Confirm password cannot be empty.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConPassword.Focus();
                return;
            }

            if (password != confirmedPassword)
            {
                MessageBox.Show("Passwords do not match. Please re-enter them.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtConPassword.Clear();
                txtPassword.Focus();
                return;
            }

            const string userExists = "SELECT COUNT(*) FROM tbl_users WHERE username = @username";
            const string register = "INSERT INTO tbl_users (username, password) VALUES (@username, @password)";

            try
            {
                using (SqlConnection con = new SqlConnection(myConn))
                using (SqlCommand checkCommand = new SqlCommand(userExists, con))
                {
                    checkCommand.Parameters.AddWithValue("@username", username);
                    con.Open();

                    if ((int)checkCommand.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("That username already exists. Please choose another one.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsername.Focus();
                        return;
                    }

                    using (SqlCommand registerCommand = new SqlCommand(register, con))
                    {
                        registerCommand.Parameters.AddWithValue("@username", username);
                        registerCommand.Parameters.AddWithValue("@password", password);
                        registerCommand.ExecuteNonQuery();
                    }
                }

                txtUsername.Clear();
                txtPassword.Clear();
                txtConPassword.Clear();
                txtUsername.Focus();
                MessageBox.Show("Your account has been successfully created.", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unable to save the new user to SQL Server. " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            char passwordChar = checkbxShowPas.Checked ? '\0' : '•';
            txtPassword.PasswordChar = passwordChar;
            txtConPassword.PasswordChar = passwordChar;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtConPassword.Clear();
            txtUsername.Focus();
        }

        private void clickLogin_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
        }
    }
}
