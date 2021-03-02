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
    public partial class ManageRewards : Form
    {
        public ManageRewards()
        {
            InitializeComponent();
        }

        private TPOHEntities context = new TPOHEntities();

        private void ManageRewards_Load(object sender, EventArgs e)
        {
            var columns = new List<string>
            {
                "Reward Name", "Reward Description", "Reward Limit", "Rewards Left", "RewardID"
            };

            foreach (var column in columns)
            {
                currentRewardsDGV.Columns.Add(column, column);
            }

            RefreshData();
        }

        private void RefreshData()
        {
            currentRewardsDGV.Rows.Clear();
            var rewards = from x in context.AwardsTables
                          select x;

            foreach (var reward in rewards)
            {
                var row = new List<string>
                {
                    reward.awardName, reward.awardDescription, reward.awardLimit.ToString(),
                    (reward.awardLimit - reward.AwardRedemptions.Count).ToString(), reward.awardID.ToString()
                };

                currentRewardsDGV.Rows.Add(row.ToArray());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            (new EditRewardDetails(-1, EditRewardDetails.ApplicationState.AddReward)).ShowDialog();
            RefreshData();
            Show();
        }

        private void currentRewardsDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var rewardID = int.Parse(currentRewardsDGV.Rows[e.RowIndex].Cells[4].Value.ToString());
            Hide();
            (new EditRewardDetails(rewardID, EditRewardDetails.ApplicationState.EditReward)).ShowDialog();
            RefreshData();
            Show();
        }
    }
}