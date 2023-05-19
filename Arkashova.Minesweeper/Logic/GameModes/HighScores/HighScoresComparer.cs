namespace Arkashova.Minesweeper.Logic.GameModes.HighScores
{
    public class HighScoresComparer : IComparer<(string, int)>
    {
        public int Compare((string, int) record1, (string, int) record2)
        {
            return record1.Item2.CompareTo(record2.Item2);
        }
    }
}
