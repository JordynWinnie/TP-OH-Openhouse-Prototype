using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_OH_AdminControlPanel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new TPOHEntities())
            {
                var user = context.Users.Where(x => x.email == emailTb.Text && x.password == passwordTb.Text).FirstOrDefault();

                if (user == null)
                {
                    MessageBox.Show("Username or password is wrong");
                    return;
                }
                if (user.isAdmin)
                {
                    this.Hide();
                    (new MainMenuForm()).ShowDialog();
                    Show();
                }
                else
                {
                    MessageBox.Show("User is not marked as Admin");
                }
            }
        }
    }
}