//https://professorweb.ru/my/csharp/thread_and_files/level4/4_6.php

using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    internal class SerializationTask
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа сериализует и дисериализует симметричную матрицу.");
            Console.WriteLine();
            Console.WriteLine("Матрица:");

            var matrixBeforeSerialization = new SymmetricMatrix(6);
            matrixBeforeSerialization.Print();

            var serializationFileName = "..\\..\\..\\data.txt";

            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream stream = new FileStream(serializationFileName, FileMode.Create, FileAccess.Write))
            {
#pragma warning disable SYSLIB0011  // Сериализация BinaryFormatter устарела - компиллятор выдает предупреждение.
                formatter.Serialize(stream, matrixBeforeSerialization);

                Console.WriteLine("Матрица успешно сериализована в файл " + Path.GetFullPath(serializationFileName));
            }

            using (Stream stream = new FileStream(serializationFileName, FileMode.Open, FileAccess.Read))
            {
                var matrixAfterSerialization = (SymmetricMatrix)formatter.Deserialize(stream);

                Console.WriteLine($"Матрица успешно десериализована из файла {Path.GetFullPath(serializationFileName)}:");

                matrixAfterSerialization.Print();
            }

            Console.WriteLine();
        }
    }
}