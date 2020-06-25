﻿using System;
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
        public EditEventDetails(int eventID)
        {
            currentEventID = eventID;
            InitializeComponent();
        }

        public TPOHEntities context = new TPOHEntities();
        private int currentEventID;
        private List<CourseTable> courseList;

        private void EditEventDetails_Load(object sender, EventArgs e)

        {
            LoadDetails();
        }

        private void LoadDetails()
        {
            courseCB.Items.Clear();
            courseList = context.CourseTables.ToList();
            courseCB.Items.AddRange(courseList.Select(x => x.courseName).ToArray());
            StringBuilder sb = new StringBuilder();

            //var eventID = int.Parse(currentEventsDGV.Rows[e.RowIndex].Cells[5].Value.ToString());

            var currentEvent = (from x in context.EventsTables
                                where x.eventID == currentEventID
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

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            (new TimingControllerForm(TimingControllerForm.ApplicationState.AddingTime, currentEventID)).ShowDialog();
            LoadDetails();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            (new TimingControllerForm(TimingControllerForm.ApplicationState.RemovingTime, currentEventID)).ShowDialog();
            LoadDetails();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            (new TimingControllerForm(TimingControllerForm.ApplicationState.EditingTime, currentEventID)).ShowDialog();
            LoadDetails();
            Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(timeLabel.Text);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var eventToModify = context.EventsTables.Where(x => x.eventID == currentEventID).First();
            eventToModify.eventName = evtNameTb.Text;
            eventToModify.courseIDFK = courseList[courseCB.SelectedIndex].courseID;
            eventToModify.eventDescription = evtDescTb.Text;
            eventToModify.creditsToEarn = (int)evtCredits.Value;
            eventToModify.qrCodeString = evtQRCode.Text;

            context.SaveChanges();
        }
    }
}