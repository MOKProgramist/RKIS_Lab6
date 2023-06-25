using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RKIS_Lab6.libs;
using RKIS_Lab6.Models;


namespace RKIS_Lab6
{
    public partial class Form1AddUsers : Form
    {
        ModelEF models = new ModelEF();
        public Form1AddUsers()
        {
            InitializeComponent();
        }

        private void StartLoadDataUsers()
        {
            dataGridView1.DataSource = models.UsersHash.ToList();
        }

        private void Form1AddUsers_Load(object sender, EventArgs e)
        {
            StartLoadDataUsers();
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(textBoxLogin.Text) || String.IsNullOrWhiteSpace(textBoxPassword.Text) || String.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            UsersHash usersHash = new UsersHash();
            usersHash.Login = textBoxLogin.Text;
            usersHash.Password = SHA256Builder.ConvertToHash(textBoxPassword.Text);
            usersHash.FirstName = textBoxFirstName.Text;

            try
            {
                models.UsersHash.Add(usersHash);
                models.SaveChanges();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                StartLoadDataUsers();
            }
            ResetInput();
            MessageBox.Show("Данные добавлены");
        }

        private void ResetInput()
        {
            textBoxFirstName.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
            textBoxLogin.Text = string.Empty;
        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            Form2Authorization form2Authorization = new Form2Authorization();   
            form2Authorization.ShowDialog();
        }
    }
}
