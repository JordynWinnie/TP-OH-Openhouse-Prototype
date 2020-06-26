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
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            (new EventManagementForm()).ShowDialog();
            Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            (new QRCodeGeneration()).ShowDialog();
            Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            (new MainEntryRemovals(MainEntryRemovals.ApplicationState.RemoveEvent)).ShowDialog();
            Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hide();
            (new MainEntryRemovals(MainEntryRemovals.ApplicationState.RemoveReward)).ShowDialog();
            Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Hide();
            (new MainEntryRemovals(MainEntryRemovals.ApplicationState.RemoveQuiz)).ShowDialog();
            Show();
        }
    }
}