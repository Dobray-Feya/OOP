﻿using System.Xml;

namespace Arkashova.Minesweeper.View
{
    public partial class HighScoresWindow : Form
    {
        public HighScoresWindow(string gameModeName, SortedDictionary<string, int> records)
        {
            InitializeComponent();

            gameModeLabel.Text = gameModeName;



            highScoresTable.Controls.Clear();

            highScoresTable.ColumnCount = 3;
            highScoresTable.RowCount = records.Count;
 
            var column1Width = 40;
            var column2Width = 100;
            var column3Width = 80;

            highScoresTable.ColumnStyles.Clear();
            highScoresTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, column1Width));
            highScoresTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, column2Width));
            highScoresTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, column3Width));

            var rowHeight = 40;

            highScoresTable.RowStyles.Clear();

            var i = 1;

            foreach (var record in records)
            {
                highScoresTable.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));

                var countLabel = new Label();
                countLabel.Text = i.ToString();
                highScoresTable.Controls.Add(countLabel, 0, i - 1);

                var userNameLabel = new Label();
                userNameLabel.Text = record.Key.ToString();
                highScoresTable.Controls.Add(userNameLabel, 1, i - 1);

                var userScoreLabel = new Label();
                userScoreLabel.Text = record.Value.ToString();
                highScoresTable.Controls.Add(userScoreLabel, 2, i - 1);

                i++;
            }
        }
    }
}