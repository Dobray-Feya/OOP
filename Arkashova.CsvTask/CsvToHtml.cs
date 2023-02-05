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

            if (ConvertCsvToHtml(args[0], args[1]))
            {
                Console.WriteLine("Конвертация завершена.");
            }
            else
            {
                Console.WriteLine("Конвертация прервана.");
            }
        }

        public static bool ConvertCsvToHtml(string sourceFileName, string resultFileName)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding targetEncoding = Encoding.GetEncoding(1251);

            using StreamReader reader = new StreamReader(sourceFileName, targetEncoding);
            using StreamWriter writer = new StreamWriter(resultFileName, false, targetEncoding);

            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html>");
            writer.WriteLine("<head>");
            writer.WriteLine("<meta charset = " + targetEncoding.WebName + ">");
            writer.WriteLine("</head>");
            writer.WriteLine("<body>");
            writer.WriteLine("<table border=\"1\">");

            string currentLine;

            while ((currentLine = reader.ReadLine()) != null)
            {
                int quotesCount = GetQuotesCount(currentLine);

                while (quotesCount % 2 == 1)
                {
                    string nextLine = reader.ReadLine();

                    quotesCount += GetQuotesCount(nextLine);

                    currentLine += "\r" + nextLine;
                }

                writer.Write("<tr>");

                int currentLineLength = currentLine.Length;
                int beginCellIndex = 0;
                int endCellIndex;
                int nextCellBeginIndex;

                while (beginCellIndex < currentLineLength)
                {
                    writer.Write("<td>");

                    if (currentLine[beginCellIndex] == ',')
                    {
                        endCellIndex = beginCellIndex - 1;  // need to avoid to write symbol ','
                                                            // in the end of this function
                        nextCellBeginIndex = beginCellIndex + 1;
                    }
                    else if (currentLine[beginCellIndex] == '"')
                    {
                        beginCellIndex++;
                        endCellIndex = GetClosingQuoteIndex(currentLine, beginCellIndex) - 1;
                        nextCellBeginIndex = endCellIndex + 3;

                        if ((endCellIndex + 2 < currentLineLength) && (currentLine[endCellIndex + 2] != ','))
                        {
                            Console.WriteLine("Неверный формат исходного CSV файла в строке:");
                            Console.WriteLine(currentLine);
                            return false;
                        }
                    }
                    else
                    {
                        int endCommaIndex = currentLine.IndexOf(",", beginCellIndex);
                        endCellIndex = (endCommaIndex == -1) ? currentLineLength - 1 : endCommaIndex - 1;
                        nextCellBeginIndex = endCellIndex + 2;
                    }

                    bool isQuoteIndexOdd = true;

                    string convertedSymbol;

                    for (int i = beginCellIndex; i <= endCellIndex; i++)
                    {
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

                    if ((nextCellBeginIndex == currentLineLength) && (currentLine[currentLineLength - 1] == ','))
                    {
                        writer.Write("<td></td>");
                    }

                    beginCellIndex = nextCellBeginIndex;
                }

                writer.WriteLine("</tr>");
            }

            writer.WriteLine("</table>");
            writer.WriteLine("</body>");
            writer.WriteLine("</html>");

            return true;
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