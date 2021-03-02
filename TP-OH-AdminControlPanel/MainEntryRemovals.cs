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
    public partial class MainEntryRemovals : Form
    {
        public enum ApplicationState { RemoveEvent, RemoveReward, RemoveQuiz };

        private ApplicationState applicationState;

        public MainEntryRemovals(ApplicationState appState)
        {
            applicationState = appState;
            InitializeComponent();
        }

        private TPOHEntities context = new TPOHEntities();
        private List<EventsTable> eventList;
        private List<AwardsTable> rewardList;
        private List<QuizTable> quizList;

        private void MainEntryRemovals_Load(object sender, EventArgs e)
        {
            switch (applicationState)
            {
                case ApplicationState.RemoveEvent:
                    eventList = context.EventsTables.ToList();

                    foreach (var item in eventList)
                    {
                        removalCB.Items.Add($"{item.eventName} - {item.CourseTable.courseName}. {item.EarnedCreditsFromEventTables.Count} people have attended and redeemed credits");
                    }
                    break;

                case ApplicationState.RemoveReward:
                    rewardList = context.AwardsTables.ToList();

                    foreach (var item in rewardList)
                    {
                        removalCB.Items.Add($"{item.awardName} - Currently Redeemed by {item.AwardRedemptions.Count} users");
                    }
                    break;

                case ApplicationState.RemoveQuiz:
                    quizList = context.QuizTables.ToList();

                    foreach (var item in quizList)
                    {
                        removalCB.Items.Add($"{item.quizName} - Already Attemped by {item.QuizAttempts.Count} users");
                    }
                    break;

                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (applicationState)
            {
                case ApplicationState.RemoveEvent:
                    var eventID = eventList[removalCB.SelectedIndex].eventID;
                    var eventToRemove = (from x in context.EventsTables
                                         where x.eventID == eventID
                                         select x).First();

                    var affectedEventTimings = from x in context.EventTimings
                                               where x.eventIDFK == eventID
                                               select x;

                    var affectedCreditEarningRecords = from x in context.EarnedCreditsFromEventTables
                                                       where x.eventIDFK == eventID
                                                       select x;

                    var eventConfirm = MessageBox.Show($"Confirm Removal of:\n 1 event\n{affectedEventTimings.Count()} timing records\n" +
                        $"{affectedCreditEarningRecords.Count()} attendance records", "Confirm?", MessageBoxButtons.YesNo);

                    if (eventConfirm == DialogResult.Yes)
                    {
                        context.EventsTables.Remove(eventToRemove);

                        foreach (var affectedEventTiming in affectedEventTimings)
                        {
                            context.EventTimings.Remove(affectedEventTiming);
                        }

                        foreach (var record in affectedCreditEarningRecords)
                        {
                            context.EarnedCreditsFromEventTables.Remove(record);
                        }
                    }

                    break;

                case ApplicationState.RemoveReward:
                    var rewardID = rewardList[removalCB.SelectedIndex].awardID;
                    var rewardToRemove = (from x in context.AwardsTables
                                          where x.awardID == rewardID
                                          select x).First();

                    var affectedRedemptions = from x in context.AwardRedemptions
                                              where x.awardIdFK == rewardID
                                              select x;

                    var rewardConfirm = MessageBox.Show($"Confirm Removal of:\n 1 reward\n{affectedRedemptions.Count()} redemptions\n\n" +
                        $"NOTE: Removed Redemptions will disallow users to claim a reward they redeemed prior to removal. PROCEED WITH CAUTION", "Confirm?", MessageBoxButtons.YesNo);

                    if (rewardConfirm == DialogResult.Yes)
                    {
                        context.AwardsTables.Remove(rewardToRemove);

                        foreach (var redemption in affectedRedemptions)
                        {
                            context.AwardRedemptions.Remove(redemption);
                        }
                    }
                    break;

                case ApplicationState.RemoveQuiz:
                    var quizID = quizList[removalCB.SelectedIndex].quizID;

                    var quizToRemove = (from x in context.QuizTables
                                        where x.quizID == quizID
                                        select x).First();

                    var affectedQuizEarnedCredits = from x in context.QuizEarnedCredits
                                                    where x.quizIDFK == quizID
                                                    select x;

                    var affectedAttemptRecords = from x in context.QuizAttempts
                                                 where x.quizIDFK == quizID
                                                 select x;

                    var affectedQuestions = from x in context.QuestionsTables
                                            where x.quizIDFK == quizID
                                            select x;
                    var affectedAnswers = from x in context.AnswersTables
                                          where x.QuestionsTable.quizIDFK == quizID
                                          select x;
                    var quizConfirm = MessageBox.Show($"Confirm Removal of:\n1 Quiz\n{affectedQuizEarnedCredits.Count()} credit earning records\n" +
                        $"{affectedAttemptRecords.Count()} leaderboard records\n{affectedQuestions.Count()} questions\n{affectedAnswers.Count()} " +
                        $"answers", "Confirm?", MessageBoxButtons.YesNo);

                    if (quizConfirm == DialogResult.Yes)
                    {
                        context.QuizTables.Remove(quizToRemove);

                        foreach (var item in affectedQuizEarnedCredits)
                        {
                            context.QuizEarnedCredits.Remove(item);
                        }

                        foreach (var item in affectedAttemptRecords)
                        {
                            context.QuizAttempts.Remove(item);
                        }

                        foreach (var item in affectedQuestions)
                        {
                            context.QuestionsTables.Remove(item);
                        }
                        foreach (var item in affectedAnswers)
                        {
                            context.AnswersTables.Remove(item);
                        }
                    }
                    break;

                default:
                    break;
            }

            context.SaveChanges();
            MessageBox.Show("Deletion Complete");
            Close();
        }
    }
}