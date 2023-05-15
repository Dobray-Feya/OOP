﻿namespace Arkashova.Minesweeper.Logic.GameModes
{
    public class SpecialMode : CustomGameMode
    {
        public override string Name => "Особый";

        public override int GetMinWidth() => 8;
        public override int GetMaxWidth() => 32;

        public override int GetMinHeight() => 8;
        public override int GetMaxHeight() => 24;

        public override int GetMinMinesCount() => 1;

        public override string HighScoresFileName => "..\\..\\..\\Logic\\GameModes\\HighScores\\SpecialModeHighScores.txt";

        public SpecialMode(int width, int height, int minesCount) : base(height, width, minesCount)
        {
        }

        public SpecialMode() : base()
        {
        }
    }
}