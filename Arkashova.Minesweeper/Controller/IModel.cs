namespace Arkashova.Minesweeper.Controller
{
    public interface IModel
    {
        public int[,] Table { get; set; }

        public GameMode GameMode { get; set; }
    }
}