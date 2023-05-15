namespace Arkashova.Minesweeper.Logic.GameModes
{
    public class BeginnerMode : GameMode
    {
        public override string Name => "Новичок";

        public override int FieldWidth => 9;

        public override int FieldHeight => 9;

        public override int MinesCount => 10;

        public override string HighScoresFileName => "..\\..\\..\\Logic\\GameModes\\HighScores\\BeginnerModeHighScores.txt";
    }
}