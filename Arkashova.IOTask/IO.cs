namespace Arkashova.IOTask
{
    public class IO
    {
        static void Main(string[] args)
        {
            var sourceFileName = "..\\..\\..\\Software Testing - Base Course (Svyatoslav Kulikov) - 3rd edition.pdf";
            var resultFileName = "..\\..\\..\\result.pdf";

            // Заметка для себя: При работе с файлами (не текстовыми) и сетью рекомендуется использовать буферизованные потоки (BinaryReader и BinaryWriter). 
            // (А вот для текстовых файлов рекомендуются StreamReader и StreamWriter)
            // Для BinaryReader рекомендуется указывать права только на чтение (FileAccess.Read),
            // т.к. по умолчанию требуются права еще и на запись, но у пользователя их может не быть и тогда будет исключение.
            // Читать даные из потока нужно в цикле.

            FileStream initialStream = new FileStream(resultFileName, FileMode.Create, FileAccess.Write); // Можно ли обойтись без этого?
            initialStream.Close();

            const int MaxBytesCountReadAtOneIteration = 50000;

            byte[] bytes = new byte[MaxBytesCountReadAtOneIteration];

            int bytesReadAtOneTime;
            int bytesReadAtOneIteration;

            int iterationsCount = 0;

            using (BinaryReader reader = new BinaryReader(new FileStream(sourceFileName, FileMode.Open, FileAccess.Read)))
            {
                using (BinaryWriter writer = new BinaryWriter(new FileStream(resultFileName, FileMode.Append, FileAccess.Write)))
                {
                    do
                    {
                        bytesReadAtOneTime = 0;
                        bytesReadAtOneIteration = 0;

                        while ((bytesReadAtOneTime = reader.Read(bytes, bytesReadAtOneIteration, bytes.Length - bytesReadAtOneIteration)) > 0)
                        {
                            bytesReadAtOneIteration += bytesReadAtOneTime;
                        }

                        iterationsCount++;

                        writer.Write(bytes, 0, bytesReadAtOneIteration);

                        Array.Clear(bytes);
                    }
                    while (bytesReadAtOneIteration > 0);
                }
            }

            Console.WriteLine($"Копия файла {Path.GetFileName(sourceFileName)} создана: {Path.GetFileName(resultFileName)}.");
            Console.WriteLine($"Файл копировался порциями по {MaxBytesCountReadAtOneIteration} байт.");
            Console.WriteLine($"Потребовалось {iterationsCount} итераций.");
        }
    }
}