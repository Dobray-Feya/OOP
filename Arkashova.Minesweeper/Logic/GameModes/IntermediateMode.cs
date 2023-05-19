namespace Arkashova.Minesweeper.Logic.GameModes
{
    internal class IntermediateMode : GameMode
    {
        public override string Name => "Любитель";

        public override int FieldWidth => 16;

        public override int FieldHeight => 16;

        public override int MinesCount => 40;
    }
}