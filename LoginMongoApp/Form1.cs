using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginMongoApp
{

    public partial class Form1 : Form
    {
        private IMongoCollection<BsonDocument> userCollection;

        public Form1()
        {
            InitializeComponent();

            // MongoDB connection initialization
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("AuthDB");
            userCollection = database.GetCollection<BsonDocument>("Users");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

           
            if (!IsValidEmail(email))
            {
                lblStatus.Text = "Invalid email format.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

        
            if (!IsStrongPassword(password))
            {
                lblStatus.Text = "Password must be at least 8 characters, include upper & lower case letters, a digit, and a special character.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

           
            var filter = Builders<BsonDocument>.Filter.Eq("email", email) &
                         Builders<BsonDocument>.Filter.Eq("password", password);

            var user = userCollection.Find(filter).FirstOrDefault();

            if (user != null)
            {
                lblStatus.Text = "Login successful!";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                MessageBox.Show("Welcome, " + email);
            }
            else
            {
                lblStatus.Text = "Email or Password cannot be empty.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }

        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

       
        private bool IsStrongPassword(string password)
        {
            if (password.Length < 8)
                return false;

            bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if (!char.IsLetterOrDigit(c)) hasSpecial = true;
            }

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }
    }
}
