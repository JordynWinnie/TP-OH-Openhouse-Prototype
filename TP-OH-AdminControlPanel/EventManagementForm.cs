using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TP_OH_AdminControlPanel
{
    public partial class EventManagementForm : Form
    {
        public EventManagementForm()
        {
            InitializeComponent();
        }

        public TPOHEntities context = new TPOHEntities();

        private void EventManagementForm_Load(object sender, EventArgs e)
        {
            var currentEventsHeader = new List<string>()
            {
                "Event Name", "Event Description", "Credits", "courseName", "qrCode", "evtID"
            };

            foreach (var column in currentEventsHeader)
            {
                currentEventsDGV.Columns.Add(column, column);
            }
            RefreshData();
        }

        private void RefreshData()
        {
            currentEventsDGV.Rows.Clear();

            var events = from x in context.EventsTables
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
                             x.invitationLink
                         };

            foreach (var evt in events)
            {
                var row = new List<string>()
                    {
                        evt.eventName,
                        evt.eventDescription,
                        evt.creditsToEarn.ToString(),
                        evt.courseName,
                        evt.qrCodeString,
                        evt.eventID.ToString()
                    };
                currentEventsDGV.Rows.Add(row.ToArray());
            }
        }

        private void currentEventsDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(currentEventsDGV.Rows[e.RowIndex].Cells[5].Value);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Timings:\n");

            var eventID = int.Parse(currentEventsDGV.Rows[e.RowIndex].Cells[5].Value.ToString());

            var timingList = (from x in context.EventsTables
                              where x.eventID == eventID
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
                                  x.invitationLink
                              }).First().EventTimings.ToList();

            var groupedTiming = (from x in timingList
                                 group x by x.startTimeOfEvent.Date into y
                                 select y);

            foreach (var timings in groupedTiming)
            {
                sb.AppendLine(timings.Key.ToShortDateString());

                foreach (var time in timings)
                {
                    sb.AppendLine($"\t\t{time.startTimeOfEvent.ToShortTimeString()} - {time.endTimeOfEvent.ToShortTimeString()}");
                }
            }

            //MessageBox.Show(sb.ToString());
            Hide();
            (new EditEventDetails(eventID, EditEventDetails.AppState.EditCurrent)).ShowDialog();
            RefreshData();
            Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            (new EditEventDetails(-1, EditEventDetails.AppState.CreateNew)).ShowDialog();
            RefreshData();
            Show();
        }
    }
}