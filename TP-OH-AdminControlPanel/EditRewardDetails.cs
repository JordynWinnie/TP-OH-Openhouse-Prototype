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
    public partial class EditRewardDetails : Form
    {
        public enum ApplicationState { EditReward, AddReward };

        private ApplicationState applicationState;
        private int currentRewardID;

        public EditRewardDetails(int rewardID, ApplicationState appState)
        {
            currentRewardID = rewardID;
            applicationState = appState;
            InitializeComponent();
        }

        private TPOHEntities context = new TPOHEntities();

        private void EditRewardDetails_Load(object sender, EventArgs e)
        {
            redemptionLimit.Maximum = int.MaxValue;

            switch (applicationState)
            {
                case ApplicationState.EditReward:

                    var rewardToEdit = (from x in context.AwardsTables
                                        where x.awardID == currentRewardID
                                        select x).First();
                    rewardNameTb.Text = rewardToEdit.awardName;
                    rewardDescriptionTb.Text = rewardToEdit.awardDescription;
                    redemptionLimit.Value = rewardToEdit.awardLimit;

                    if (rewardToEdit.creditsRequired == 0)
                    {
                        checkBox2.Checked = true;
                    }

                    requiredCredits.Value = rewardToEdit.creditsRequired;

                    rewardHeader.Text = $"Editing Reward '{rewardToEdit.awardName}':";
                    break;

                case ApplicationState.AddReward:
                    rewardHeader.Text = "Adding New Reward:";
                    break;

                default:
                    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                redemptionLimit.Value = redemptionLimit.Maximum;
                redemptionLimit.Enabled = false;
            }
            else
            {
                redemptionLimit.Value = 10;
                redemptionLimit.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (applicationState)
            {
                case ApplicationState.EditReward:
                    var rewardToEdit = (from x in context.AwardsTables
                                        where x.awardID == currentRewardID
                                        select x).First();

                    rewardToEdit.awardName = rewardNameTb.Text;
                    rewardToEdit.awardDescription = rewardDescriptionTb.Text;
                    rewardToEdit.awardLimit = (int)redemptionLimit.Value;
                    rewardToEdit.creditsRequired = (int)requiredCredits.Value;
                    break;

                case ApplicationState.AddReward:
                    var insertReward = new AwardsTable
                    {
                        awardName = rewardNameTb.Text,
                        awardDescription = rewardDescriptionTb.Text,
                        awardLimit = (int)redemptionLimit.Value,
                        creditsRequired = (int)requiredCredits.Value
                    };
                    context.AwardsTables.Add(insertReward);
                    break;

                default:
                    break;
            }

            context.SaveChanges();
            MessageBox.Show("Changes saved");
            Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                requiredCredits.Minimum = 0;
                requiredCredits.Value = 0;
                requiredCredits.Enabled = false;
            }
            else
            {
                requiredCredits.Minimum = 1;
                requiredCredits.Value = 10;
                requiredCredits.Enabled = true;
            }
        }
    }
}