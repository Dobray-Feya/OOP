using System.Text;

// В Debug Properties надо указать:
// ..\\..\\..\\data.csv ..\\..\\..\\data.html

namespace Arkashova.CsvTask
{
    internal class CsvToHtml
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Ошибка: неверные аргументы.");
                Console.WriteLine();
                Console.WriteLine("Примеры использования:");
                Console.WriteLine("CsvToHtml.exe data.csv data.html");
                Console.WriteLine(@"CsvToHtml.exe ""..\dir1\data.csv"" ""..\dir2\data.html""");

                return;
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding(1251);

            string sourceFileName = args[0];
            string resultFileName = args[1];

            try
            {
                using StreamReader reader = new StreamReader(sourceFileName, encoding);
                using StreamWriter writer = new StreamWriter(resultFileName, false, encoding);

                ConvertCsvToHtml(reader, writer, encoding);

                Console.WriteLine("Конвертация завершена.");
                Console.WriteLine($"Исходный CSV-файл: {Path.GetFullPath(sourceFileName)}.");
                Console.WriteLine($"Итоговый HTML-файл: {Path.GetFullPath(resultFileName)}.");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Файл не найден. Конвертация невозможна.");
                Console.WriteLine("Описание ошибки:");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка. Конвертация прервана.");
                Console.WriteLine("Описание ошибки:");
                Console.WriteLine(e.Message);
            }
        }

        private static void ConvertCsvToHtml(StreamReader reader, StreamWriter writer, Encoding encoding)
        {
            WriteHtmlHeaderToFile(writer, encoding);

            string? currentLine;

            while ((currentLine = reader.ReadLine()) != null)
            {
                int quotesCount = GetQuotesCount(currentLine);

                while (quotesCount % 2 == 1)
                {
                    string? nextLine = reader.ReadLine();

                    if (nextLine == null)
                    {
                        break;
                    }

                    quotesCount += GetQuotesCount(nextLine);
                    currentLine += "\r" + nextLine;
                }

                WriteHtmlRowToFile(currentLine, writer);
            }

            WriteHtmlFooterToFile(writer);
        }

        private static void WriteHtmlHeaderToFile(StreamWriter writer, Encoding encoding)
        {
            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html>");
            writer.WriteLine("<head>");
            writer.WriteLine($"<meta charset=\"{encoding.WebName}\">");
            writer.WriteLine("</head>");
            writer.WriteLine("<body>");
            writer.WriteLine("<table border=\"1\">");
        }

        private static void WriteHtmlFooterToFile(StreamWriter writer)
        {
            writer.WriteLine("</table>");
            writer.WriteLine("</body>");
            writer.WriteLine("</html>");
        }

        private static void WriteHtmlRowToFile(string currentLine, StreamWriter writer)
        {
            writer.Write("<tr>");

            int beginCellIndex = 0;

            while (beginCellIndex < currentLine.Length)
            {
                writer.Write("<td>");

                int endCellIndex;
                int nextCellBeginIndex;

                if (currentLine[beginCellIndex] == ',')
                {
                    endCellIndex = beginCellIndex - 1;
                    nextCellBeginIndex = beginCellIndex + 1;
                }
                else if (currentLine[beginCellIndex] == '"')
                {
                    beginCellIndex++;
                    endCellIndex = GetClosingQuoteIndex(currentLine, beginCellIndex) - 1;
                    nextCellBeginIndex = endCellIndex + 3;

                    // Выявляется неверный формат строки, когда в кавычки взято не все содержимое ячейки, например, "абс"d
                    if ((endCellIndex + 2 < currentLine.Length) && (currentLine[endCellIndex + 2] != ','))
                    {
                        throw new ArgumentException("Неверный формат исходного CSV-файла в строке:", currentLine);
                    }
                }
                else
                {
                    int endCommaIndex = currentLine.IndexOf(",", beginCellIndex);
                    endCellIndex = (endCommaIndex == -1) ? currentLine.Length - 1 : endCommaIndex - 1;
                    nextCellBeginIndex = endCellIndex + 2;
                }

                bool isQuoteIndexOdd = true;

                for (int i = beginCellIndex; i <= endCellIndex; i++)
                {
                    string convertedSymbol;

                    switch (currentLine[i])
                    {
                        case '<':
                            convertedSymbol = "&lt;";
                            break;
                        case '>':
                            convertedSymbol = "&gt;";
                            break;
                        case '&':
                            convertedSymbol = "&amp;";
                            break;
                        case '\r':
                            convertedSymbol = "<br/>";
                            break;
                        case '"':
                            convertedSymbol = isQuoteIndexOdd ? "\"" : "";
                            isQuoteIndexOdd = !isQuoteIndexOdd;
                            break;
                        default:
                            convertedSymbol = currentLine[i].ToString();
                            break;
                    }

                    writer.Write(convertedSymbol);
                }

                writer.Write("</td>");

                if ((nextCellBeginIndex == currentLine.Length) && (currentLine[^1] == ','))
                {
                    writer.Write("<td></td>");
                }

                beginCellIndex = nextCellBeginIndex;
            }

            writer.WriteLine("</tr>");
        }

        private static int GetQuotesCount(string line)
        {
            int quotesCount = 0;

            foreach (char symbol in line)
            {
                if (symbol == '"')
                {
                    quotesCount++;
                }
            }

            return quotesCount;
        }

        private static int GetClosingQuoteIndex(string line, int startIndex)
        {
            int quoteIndex = line.IndexOf('"', startIndex);

            while (quoteIndex < line.Length - 1)
            {
                if (line[quoteIndex + 1] == '"')
                {
                    quoteIndex = line.IndexOf('"', quoteIndex + 2);
                }
                else
                {
                    return quoteIndex;
                }
            }

            return quoteIndex;
        }
    }
}