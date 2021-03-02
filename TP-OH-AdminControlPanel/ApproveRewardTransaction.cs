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
    public partial class ApproveRewardTransaction : Form
    {
        public ApproveRewardTransaction()
        {
            InitializeComponent();
        }

        private TPOHEntities context = new TPOHEntities();
        private List<AwardRedemption> redemptionList;

        private void ApproveRewardTransaction_Load(object sender, EventArgs e)
        {
            redemptionList = (from x in context.AwardRedemptions
                              where x.isAwardUsed == false
                              select x).ToList();

            foreach (var redemption in redemptionList)
            {
                approvalCB.Items.Add($"{redemption.AwardsTable.awardName} ({redemption.User.username}) -- {redemption.UUID}");
            }
        }

        private void approvalCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var redemption = redemptionList[approvalCB.SelectedIndex];
            externalAPICallback.Text = $"http://localhost:54888/AwardRedemptions/RedeemReward?guid={redemption.UUID}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var redemptionID = redemptionList[approvalCB.SelectedIndex].redemptionID;
            var redemptionToChange = (from x in context.AwardRedemptions
                                      where x.redemptionID == redemptionID
                                      select x).First();

            redemptionToChange.isAwardUsed = true;
            context.SaveChanges();
        }

        private void externalAPICallback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(externalAPICallback.Text);
        }
    }
}