namespace Arkashova.Minesweeper.Logic.GameModes
{
    public class ExpertMode : GameMode
    {
        public override string Name => "Профессионал";

        public override int FieldWidth => 30;

        public override int FieldHeight => 16;

        public override int MinesCount => 99;
    }
}
