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
    public partial class EditEventDetails : Form
    {
        public EditEventDetails()
        {
            InitializeComponent();
        }

        public TPOHEntities context = new TPOHEntities();

        private void EditEventDetails_Load(object sender, EventArgs e)

        {
            courseCB.Items.AddRange(context.CourseTables.Select(x => x.courseName).ToArray());
            StringBuilder sb = new StringBuilder();

            //var eventID = int.Parse(currentEventsDGV.Rows[e.RowIndex].Cells[5].Value.ToString());

            var currentEvent = (from x in context.EventsTables
                                where x.eventID == 1
                                select new
                                {
                                    x.eventID,
                                    x.eventName,
                                    x.eventDescription,
                                    x.creditsToEarn,
                                    x.CourseTable.courseName,
                                    x.CourseTable.courseShortName,
                                    x.CourseTable.courseCode,
                                    x.qrCodeString,
                                    x.EventTimings,
                                    x.invitationLink,
                                    x.CourseTable.courseID
                                }).First();

            courseCB.SelectedItem = currentEvent.courseName;

            evtNameTb.Text = currentEvent.eventName;
            evtCredits.Value = currentEvent.creditsToEarn;
            evtDescTb.Text = currentEvent.eventDescription;
            evtQRCode.Text = currentEvent.qrCodeString;

            var groupedTiming = (from x in currentEvent.EventTimings
                                 group x by x.startTimeOfEvent.Date into y
                                 select y);

            foreach (var timings in groupedTiming)
            {
                sb.AppendLine(timings.Key.ToShortDateString());

                foreach (var time in timings)
                {
                    sb.AppendLine($"        {time.startTimeOfEvent.ToShortTimeString()} - {time.endTimeOfEvent.ToShortTimeString()}");
                }
                sb.AppendLine("\n");
            }
            timeLabel.Text = sb.ToString();
        }
    }
}