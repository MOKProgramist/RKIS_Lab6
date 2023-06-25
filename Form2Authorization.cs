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

namespace RKIS_Lab6.Models
{
    public partial class Form2Authorization : Form
    {
        public Form2Authorization()
        {
            InitializeComponent();
        }

        private void buttonAuthLogin_Click(object sender, EventArgs e)
        {
            ModelEF models = new ModelEF();
            string hashPassword = SHA256Builder.ConvertToHash(textBoxPassword.Text);

            UsersHash FindUser = models.UsersHash.FirstOrDefault(user => user.Login == textBoxLogin.Text && user.Password == hashPassword);
            if (FindUser != null)
            {
                MessageBox.Show("Пользователь найден");
                return;
            }

            MessageBox.Show("Пользователь не найден");
        }

        private void Form2Authorization_Load(object sender, EventArgs e)
        {

        }
    }
}
