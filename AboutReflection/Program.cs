// https://metanit.com/sharp/tutorial/14.1.php на Метанит о рефлексии

// Как исследовать стороннюю сборку:
// 1. Загрузить сборку (прописать путь к ее dll).
// 2. Добавить в зависимость загруженную сборку:
//    а) Вызвать окно Reference Manager так же, как добавляется ссылка на другой проект,
//    б) Нажать внизу окна кнопку Browse и в открывшемся окне выбрать сборку, которую хочется поисследовать с помощью Reflection

// Я взяла сборку из задачи о фигурах, но  сделала класс Circle internal (чтобы было сложнее), добавила приватное поле и метод.

using System.Reflection;

namespace AboutReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string loadedAssembliesDirectoryName = "..\\..\\..\\LoadedAssemblies";
            Console.WriteLine($"Загрузка сборки из папки {loadedAssembliesDirectoryName}:");

            Assembly extraAssembly = Assembly.LoadFrom(loadedAssembliesDirectoryName + "\\Arkashova.ShapesTask.dll");
            Console.WriteLine("Полное имя сборки: " + extraAssembly.FullName);

            Console.WriteLine("Сборка содержит типы:");
            Console.WriteLine();

            Type[] extraAssemblyTypes = extraAssembly.GetTypes();

            for (int i = 0; i < extraAssemblyTypes.Length; i++)
            {
                Console.WriteLine($"Тип ({i}): {extraAssemblyTypes[i].Name}");
                Console.WriteLine("Полное имя: " + extraAssemblyTypes[i].FullName);
                Console.WriteLine("Is interface? -> " + extraAssemblyTypes[i].IsInterface + "; Is public? -> " + extraAssemblyTypes[i].IsPublic);
                Console.WriteLine("Родительский тип: " + extraAssemblyTypes[i].BaseType);
                Console.WriteLine("");

                PropertyInfo[] properties = extraAssemblyTypes[i].GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                if (properties.Length > 0)
                {
                    Console.WriteLine("Свойства:");

                    foreach (var property in properties)
                    {
                        Console.Write(property.Name);
                        Console.Write(" (" + property.PropertyType.Name + ")");
                        Console.WriteLine();
                    }

                    Console.WriteLine("");
                }

                FieldInfo[] fields = extraAssemblyTypes[i].GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                if (fields.Length > 0)
                {
                    Console.WriteLine("Поля:");

                    foreach (var field in fields)
                    {
                        Console.Write(field.Name);
                        Console.Write(" (" + field.FieldType.Name + ") ");
                        Console.Write(GetFieldModificator(field));
                        Console.WriteLine();
                    }

                    Console.WriteLine("");
                }

                Console.WriteLine("Конструкторы:");

                foreach (MethodBase constructor in extraAssemblyTypes[i].GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    Console.WriteLine(constructor + " " + GetMethodBaseModificator(constructor));
                }

                Console.WriteLine();

                Console.WriteLine("Методы:");

                foreach (MethodBase method in extraAssemblyTypes[i].GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    Console.WriteLine(method + " " + GetMethodBaseModificator(method));
                }

                Console.WriteLine();
            }

            Console.WriteLine("Создаем экземпляр класса через ConstructorInfo:");

            // Type circleType = typeof(Arkashova.ShapesTask.Shapes.Circle); // к публичному классу можно обратиться вот так - напрямую
            Type circleType = extraAssemblyTypes[4]; //но к классу internal так не получится, поэтому придумала вот так.

            ConstructorInfo circleConstructor = circleType.GetConstructor(new Type[] { typeof(double) });

            var circle = circleConstructor.Invoke(new object[] { 5 }); // в лекции было еще приведение к типу, но для класса internal это невозможно. Но тут и без приведения работает

            Console.WriteLine("Создан объект: " + circle);
            Console.WriteLine();

            FieldInfo openField = circleType.GetField("openField");
            // чтобы получить значение приватного поля надо передать в GetField флаги
            FieldInfo secretField = circleType.GetField("secret", BindingFlags.Instance | BindingFlags.NonPublic);

            Console.WriteLine("Значение поля openField: " + openField.GetValue(circle));
            Console.WriteLine("Значение поля secret: " + secretField.GetValue(circle));
            Console.WriteLine();

            Console.WriteLine("Меняем поля:");

            openField.SetValue(circle, 3000);
            secretField.SetValue(circle, 2024);
            Console.WriteLine("Значение публичного поля openField: " + openField.GetValue(circle));
            Console.WriteLine("Значение приватного поля secret: " + secretField.GetValue(circle));
            Console.WriteLine();

            Console.WriteLine("Меняем (публичное) свойство Radius:");
            PropertyInfo radiusProperty = circleType.GetProperty("Radius");
            radiusProperty.SetValue(circle, 1);
            Console.WriteLine(circle);
            Console.WriteLine();

            Console.WriteLine("Получаем доступ к публичному методу GetArea:");
            MethodInfo openMethod = circleType.GetMethod("GetArea");
            Console.WriteLine(openMethod.Invoke(circle, new object[] { }));
            Console.WriteLine();

            Console.WriteLine("А теперь вызовем приватный метод:");
            MethodInfo secretMethod = circleType.GetMethod("PrintSecret", BindingFlags.Instance | BindingFlags.NonPublic);
            secretMethod.Invoke(circle, new object[] { });
        }

        public static string GetMethodBaseModificator(MethodBase methodbase)
        {
            string modificator = "";

            if (methodbase.IsPublic)
            {
                modificator += "public";
            }
            else if (methodbase.IsPrivate)
            {
                modificator += "private";
            }
            else if (methodbase.IsAssembly)
            {
                modificator += "internal";
            }
            else if (methodbase.IsFamily)
            {
                modificator += "protected";
            }
            else if (methodbase.IsFamilyAndAssembly)
            {
                modificator += "private protected";
            }
            else if (methodbase.IsFamilyOrAssembly)
            {
                modificator += "protected internal";
            }

            return modificator;
        }

        public static string GetFieldModificator(FieldInfo field)
        {
            string modificator = "";

            if (field.IsPublic)
            {
                modificator += "public";
            }
            else if (field.IsPrivate)
            {
                modificator += "private";
            }

            return modificator;
        }
    }
}