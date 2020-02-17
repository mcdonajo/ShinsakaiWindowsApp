using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShinsakaiWindowsApp
{
    public interface IScoringListener
    {
        void scoreUpdated();
    }

    public partial class ScoringForm : Form, IScoringListener
    {
        private Dictionary<Registrant, ScoringControl> scores = new Dictionary<Registrant, ScoringControl>();
        public GroupScore GroupScore { get; set; }
        private Group group;
        public ScoringForm(Group g)
        {
            group = g;
            InitializeComponent();
            addCompetitionTypesToComboBox();
            competitionCombo.SelectedItem = DataManager.CurrentCompetition.ToString();
            this.PerformLayout();
        }

        private void setupScoringControls()
        {
            GroupScore gScore;
            if (group.GroupScore != null && group.GroupScore.CompetitionGroupType == DataManager.CurrentCompetition)
            {
                gScore = new GroupScore(group.GroupScore);
            }
            else
            {
                gScore = new GroupScore(DataManager.CurrentCompetition, group);
            }
            scores.Clear();
            scoringContents.Controls.Clear();
            foreach (Registrant r in gScore.getRegistrants())
            {
                Score score = gScore.getScoreForRegistrant(r);
                ScoringControl sc = new ScoringControl(ref score, r, this);
                sc.Dock = DockStyle.Top;
                scoringContents.Controls.Add(sc);
                scores.Add(r, sc);
                updateScore();
            }
            GroupScore = gScore;
        }

        private void addCompetitionTypesToComboBox()
        {
            foreach (CompetitionGroupType r in Enum.GetValues(typeof(CompetitionGroupType)))
            {
                competitionCombo.Items.Add(r.ToString());
            }
        }

        private void addJudgeButton_Click(object sender, EventArgs e)
        {
            foreach(ScoringControl sc in scores.Values)
            {
                sc.addColumn();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            group.GroupScore = GroupScore;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void competitionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompetitionGroupType ctype = (CompetitionGroupType)(Enum.Parse(typeof(CompetitionGroupType), competitionCombo.SelectedItem.ToString()));
            DataManager.CurrentCompetition = ctype;
            setupScoringControls();
        }

        private void updateScore()
        {
            float sum = 0.0f;
            foreach (ScoringControl sc in scores.Values)
            {
                sum += sc.getScore().getTotal();
            }
            totalValueLabel.Text = sum.ToString();
        }

        public void scoreUpdated()
        {
            updateScore();
        }
    }
}
