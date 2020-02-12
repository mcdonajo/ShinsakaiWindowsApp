using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShinsakaiWindowsApp
{
    public partial class ScoringControl : UserControl
    {
        public int judgeNum = 0;
        IScore score;
        private IScoringListener listener;
        Dictionary<int, ScoringEntry> rows = new Dictionary<int, ScoringEntry>();
        Dictionary<int, Judge> columns = new Dictionary<int, Judge>();
        Dictionary<ScoringEntry, int> rowsReversed = new Dictionary<ScoringEntry, int>();
        bool shouldUpdate = true;

        public ScoringControl(ref IScore score, Registrant r, IScoringListener listener)
        {
            suspendUpdates();
            InitializeComponent();
            this.listener = listener;
            this.score = score;
            addJudges();
            dataGridView1.TopLeftHeaderCell.Value = r.FirstName + " " + r.LastName;
            setupRows();
            fillData();
            resumeUpdates();
        }

        private void setHeight()
        {
            int colHeaderHeight = dataGridView1.ColumnHeadersHeight+10;
            int cellHeight = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Height;
            Height = colHeaderHeight + (cellHeight * dataGridView1.Rows.Count);
        }

        private void addJudges()
        {
            int judgeCount = score.getScores().Count;
            if (judgeCount == 0)
            {
                addColumn();
            }
            else
            {
                for (int i = 0; i < judgeCount; i++)
                {
                    addColumn();
                }
            }
        }

        private void fillData()
        {
            int i = 0;
            foreach(KeyValuePair<Judge, Dictionary<ScoringEntry, float>> judgeScore in score.getScores())
            {
                dataGridView1.Columns[i].HeaderCell.Value = judgeScore.Key.Name;
                foreach (KeyValuePair<ScoringEntry, float> kvp in judgeScore.Value)
                {
                    dataGridView1.Rows[rowsReversed[kvp.Key]].Cells[i].Value = kvp.Value;
                }
                columns[i] = judgeScore.Key;
                i++;
            }
        }

        private void setupRows()
        {
            foreach(ScoringEntry se in score.getRows())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.HeaderCell.Value = se.getDesc();
                rows.Add(dataGridView1.Rows.Count, se);
                rowsReversed.Add(se, dataGridView1.Rows.Count);
                dataGridView1.Rows.Add(row);
                
            }
            setHeight();
        }

        public void addColumn()
        {
            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            Judge j = new Judge();
            j.Name = "Judge #" + (judgeNum + 1);
            col.HeaderCell.Value = j.Name;
            judgeNum++;
            dataGridView1.Columns.Add(col);
            columns.Add(col.Index, j);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(!shouldUpdate)
            {
                return;
            }
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            ScoringEntry se = rows[e.RowIndex];
            string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            score.addScore(columns[e.ColumnIndex], se, float.Parse(value));
            listener.scoreUpdated();
        }

        public IScore getScore()
        {
            return score;
        }

        private void suspendUpdates()
        {
            shouldUpdate = false;
        }

        private void resumeUpdates()
        {
            shouldUpdate = true;
            listener.scoreUpdated();
        }
    }
}
