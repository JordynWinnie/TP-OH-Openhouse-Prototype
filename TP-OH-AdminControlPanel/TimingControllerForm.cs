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
    public partial class TimingControllerForm : Form
    {
        public enum ApplicationState { AddingTime, RemovingTime, EditingTime };

        private int currentEventID;
        private ApplicationState currentAppState;

        private TPOHEntities context = new TPOHEntities();
        private List<EventTiming> timingList;

        public TimingControllerForm(ApplicationState applicationState, int eventID)
        {
            currentEventID = eventID;
            currentAppState = applicationState;
            InitializeComponent();
        }

        private void TimingControllerForm_Load(object sender, EventArgs e)
        {
            switch (currentAppState)
            {
                case ApplicationState.AddingTime:
                    headerLbl.Text = "Adding Time";
                    removeTimingLbl.Visible = false;
                    removeTimingCb.Visible = false;
                    break;

                case ApplicationState.RemovingTime:
                    headerLbl.Text = "Remove Time";

                    startDatePicker.Visible = false;
                    endDatePicker.Visible = false;
                    startTimePicker.Visible = false;
                    endTimePicker.Visible = false;
                    startTimeLbl.Visible = false;
                    endTimeLbl.Visible = false;

                    timingList = (from x in context.EventTimings
                                  where x.eventIDFK == currentEventID
                                  select x).ToList();
                    foreach (var timing in timingList)
                    {
                        removeTimingCb.
                            Items.Add($"{timing.startTimeOfEvent.Date.ToShortDateString()}: {timing.startTimeOfEvent.ToShortTimeString()} - {timing.endTimeOfEvent.ToShortTimeString()}");
                    }
                    removeTimingCb.SelectedIndex = 0;

                    break;

                case ApplicationState.EditingTime:
                    headerLbl.Text = "Edit Time";
                    removeTimingLbl.Text = "Edit Timing:";

                    timingList = (from x in context.EventTimings
                                  where x.eventIDFK == currentEventID
                                  select x).ToList();
                    foreach (var timing in timingList)
                    {
                        removeTimingCb.
                            Items.Add($"{timing.startTimeOfEvent.Date.ToShortDateString()}: {timing.startTimeOfEvent.ToShortTimeString()} - {timing.endTimeOfEvent.ToShortTimeString()}");
                    }
                    removeTimingCb.SelectedIndex = 0;

                    removeTimingCb.SelectedIndexChanged += RemoveTimingCb_SelectedIndexChanged;
                    break;

                default:
                    break;
            }
        }

        private void RemoveTimingCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTiming = timingList[removeTimingCb.SelectedIndex];
            startDatePicker.Value = selectedTiming.startTimeOfEvent;
            startTimePicker.Value = selectedTiming.startTimeOfEvent;
            endDatePicker.Value = selectedTiming.endTimeOfEvent;
            endTimePicker.Value = selectedTiming.endTimeOfEvent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (currentAppState)
            {
                case ApplicationState.AddingTime:

                    var startTime = startDatePicker.Value.Date + startTimePicker.Value.TimeOfDay;
                    var endTime = endDatePicker.Value.Date + endTimePicker.Value.TimeOfDay;
                    if (context.EventTimings.Where(x => x.startTimeOfEvent == startTime).Any())
                    {
                        var confirmation = MessageBox.Show("An event timing has already been alotted for this slot, continue?", "Warning", MessageBoxButtons.YesNo);

                        if (confirmation == DialogResult.Yes)
                        {
                            var insertTiming = new EventTiming
                            {
                                startTimeOfEvent = startTime,
                                endTimeOfEvent = endTime,
                                eventIDFK = currentEventID
                            };
                            context.EventTimings.Add(insertTiming);
                        }
                    }
                    else
                    {
                        var insertTiming = new EventTiming
                        {
                            startTimeOfEvent = startTime,
                            endTimeOfEvent = endTime,
                            eventIDFK = currentEventID
                        };
                        context.EventTimings.Add(insertTiming);
                    }

                    break;

                case ApplicationState.RemovingTime:
                    var timingID = timingList[removeTimingCb.SelectedIndex].eventTimingID;

                    var timingToRemove = context.EventTimings.Where(x => x.eventTimingID == timingID).First();
                    context.EventTimings.Remove(timingToRemove);
                    break;

                case ApplicationState.EditingTime:
                    var timingIDToEdit = timingList[removeTimingCb.SelectedIndex].eventTimingID;

                    var timingToChange = context.EventTimings.Where(x => x.eventTimingID == timingIDToEdit).First();

                    timingToChange.startTimeOfEvent = startDatePicker.Value.Date + startTimePicker.Value.TimeOfDay;
                    timingToChange.endTimeOfEvent = endDatePicker.Value.Date + endTimePicker.Value.TimeOfDay;
                    break;

                default:
                    break;
            }

            context.SaveChanges();
            MessageBox.Show("Changes Committed.");
            Close();
        }
    }
}