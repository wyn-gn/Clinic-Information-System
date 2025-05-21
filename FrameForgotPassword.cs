using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Clinis_infosys
{
    public partial class FrameForgotPassword : Form
    {
        private string userEmail = "";
        private string storedAnswer = "";  // changed from storedAnswerHash
        private MySqlConnection connection;

        // Defined manually
        private Label labelMessage;
        private Label labelResetMessage;

        public FrameForgotPassword()
        {
            InitializeComponent();

            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;";
            connection = new MySqlConnection(connStr);

            // Initialize custom labels (no need to add them in the designer)
            labelMessage = new Label
            {
                AutoSize = true,
                ForeColor = System.Drawing.Color.Red,
                Location = new System.Drawing.Point(20, 220), // Adjust coordinates as needed
                Name = "labelMessage",
                Size = new System.Drawing.Size(0, 13),
                TabIndex = 1000
            };
            this.Controls.Add(labelMessage);

            labelResetMessage = new Label
            {
                AutoSize = true,
                ForeColor = System.Drawing.Color.Green,
                Location = new System.Drawing.Point(20, 250), // Adjust coordinates as needed
                Name = "labelResetMessage",
                Size = new System.Drawing.Size(0, 13),
                TabIndex = 1001
            };
            this.Controls.Add(labelResetMessage);
        }

        private void FrameForgotPassword_Load(object sender, EventArgs e)
        {
            labelSecurityQ.Visible = false;
            textBoxAnswer.Visible = false;
            buttonVerifyAnswer.Visible = false;
            textBoxNewPass.Visible = false;
            buttonResetPass.Visible = false;

            labelMessage.Text = "";
            labelResetMessage.Text = "";
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            userEmail = textBoxEmail.Text.Trim();
            labelMessage.Text = "";

            if (string.IsNullOrEmpty(userEmail))
            {
                labelMessage.Text = "Please enter your email.";
                return;
            }

            try
            {
                connection.Open();
                string query = "SELECT security_question, security_answer FROM admin_user WHERE email = @Email";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Email", userEmail);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    labelSecurityQ.Text = reader.GetString("security_question");
                    storedAnswer = reader.GetString("security_answer");  // plain text answer
                    reader.Close();

                    labelSecurityQ.Visible = true;
                    textBoxAnswer.Visible = true;
                    buttonVerifyAnswer.Visible = true;

                    labelMessage.Text = "Please answer your security question.";
                    textBoxEmail.Enabled = false;
                    buttonNext.Enabled = false;
                }
                else
                {
                    labelMessage.Text = "Email not registered.";
                    reader.Close();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error: " + ex.Message;
            }
        }

        private void buttonVerifyAnswer_Click(object sender, EventArgs e)
        {
            string inputAnswer = textBoxAnswer.Text.Trim();

            if (string.IsNullOrEmpty(inputAnswer))
            {
                labelMessage.Text = "Please enter the answer.";
                return;
            }

            // Plain text comparison, ignoring case and trimming spaces
            if (string.Equals(inputAnswer, storedAnswer.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                labelMessage.Text = "Security answer verified. Enter your new password.";

                // Hide answer controls
                labelSecurityQ.Visible = false;
                textBoxAnswer.Visible = false;
                buttonVerifyAnswer.Visible = false;

                // Show new password controls
                textBoxNewPass.Visible = true;
                buttonResetPass.Visible = true;
            }
            else
            {
                labelMessage.Text = "Incorrect security answer.";
            }
        }

        private void buttonResetPass_Click(object sender, EventArgs e)
        {
            string newPassword = textBoxNewPass.Text.Trim();

            if (string.IsNullOrEmpty(newPassword))
            {
                labelResetMessage.Text = "Please enter a new password.";
                return;
            }

            string hashedPassword = HashPassword(newPassword);

            try
            {
                connection.Open();
                string update = "UPDATE admin_user SET password = @Password WHERE email = @Email";
                MySqlCommand cmd = new MySqlCommand(update, connection);
                cmd.Parameters.AddWithValue("@Password", hashedPassword);
                cmd.Parameters.AddWithValue("@Email", userEmail);
                cmd.ExecuteNonQuery();
                connection.Close();

                labelResetMessage.Text = "Password has been successfully reset.";

                FrmLogin loginForm = new FrmLogin();
                loginForm.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                labelResetMessage.Text = "Error: " + ex.Message;
            }
        }

        private string HashPassword(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                return Convert.ToBase64String(bytes);
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
