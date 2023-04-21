using Arkashova.Minesweeper.Controller;

namespace Arkashova.Minesweeper.Logic
{
    public class BeginnerMode : GameMode
    {
        public override string Name => "Begginer";

        public override bool IsCustom => false;

        public BeginnerMode()
        {
            FieldWidth = 9;
            FieldHeight = 9;
            MinesCount = 10;
        }
    }
}
