/*  Задача

Написать программу, которая из имеющегося массива строк формирует массив из строк, длина
которых меньше либо равна 3 символа. Первоначальный массив можно ввести с клавиатуры,
либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться
коллекциями, лучше обойтись исключительно массивами

Примеры:
{"hello", "2", "world", ":-)"} // -> {"2", ":-)"}
{"1234", "1567", "-2", "computer science"} // -> {"-2"}
{"Russia", "Denmark", "Kazan"} // -> {}
*/


void ShowResult((string[] usersArray, string[] resultArray) args)
{
    string usersArray = "{" + "\"" + String.Join("\", \"", args.usersArray) + "\"" + "}";
    string resultArray = 0 < args.resultArray.Length
                       ? "{" + "\"" + String.Join("\", \"", args.resultArray) + "\"" + "}"
                       : "{}";
    Console.WriteLine(usersArray + " –> " + resultArray);
}


string[] ReturnStringsLessEqualArgs((string[] array, int samplingCondition) args)
{
    string[] result = new string[0];
    int nextElemIndex = 0;

    foreach (string element in args.array)
    {
        if (element.Length <= args.samplingCondition)
        {
            Array.Resize(ref result, result.Length + 1);
            result[nextElemIndex++] = element;
        }
    }
    return result;
}


int GetStringLengthForSelection()
{
    int stringLength = 3;
    Console.Write("Желаете установить длину отбора строк?\n"
                + "(нажмите Y, если \"Да\" или любую кнопку, если \"Нет\")\n"
                + ">>> ");
    if (Console.ReadKey().Key == ConsoleKey.Y)
    {
        Console.WriteLine();
        Console.Write("Укажите длину строки для отбора значений:\n>>> ");
        bool flag = int.TryParse(Console.ReadLine(), out stringLength);
        if (!flag)
        {
            stringLength = 3; // Метод TryParse() "обнулит" значение переменной, если 
                              // ему не удастся пропарсить строку.
                              // Восстанавливаем инициализированное ранее значение. 
            Console.WriteLine("Не удалось преобразовать строку к числу, "
                            + $"будет использовано значение по умолчанию -> {stringLength}");
        }
    }
    return stringLength;
}


string[] GetRandomDefaultArray()
{
    string[] randArray;
    int randVariant = new Random().Next(0, 3);
    switch (randVariant)
    {
        case 0:
            randArray = new string[4]
            {"hello", "2", "world", ":-)"};
            break;
        case 1:
            randArray = new string[4]
            {"1234", "1567", "-2", "computer science"};
            break;
        case 2:
            randArray = new string[3]
            {"Russia", "Denmark", "Kazan"};
            break;
        default:
            randArray = new string[0];
            break;
    }
    return randArray;
}


string[] GetUsersInputedArray()
{
    string[] usersArray = new string[0];
    bool stringChecker = true;
    int stringCount = 0;
    bool nextString = true;

    while (nextString)
    {
        System.Console.Write("Введите строку:\n"
                            + $"(было добавлено {stringCount} строк)\n"
                            + ">>> ");
        var usersString = Console.ReadLine()!;
        stringChecker = String.IsNullOrWhiteSpace(usersString);
        if (!stringChecker)
        {
            Array.Resize(ref usersArray, usersArray.Length + 1);
            usersArray[stringCount++] = usersString.Trim();
        }
        Console.Write("q – прервать ввод строк.\n"
                    + "любая кнопка – продолжить ввод.\n"
                    + ">>> ");
        if (Console.ReadKey().Key == ConsoleKey.Q) nextString = false;
        Console.WriteLine();
    }
    return usersArray;
}


bool ReadAnArray()
{
    Console.Write("Желаете задать свой массив строк?\n"
                + "(нажмите Y, если \"Да\" или любую кнопку, если \"Нет\")\n"
                + ">>> ");
    if (Console.ReadKey().Key == ConsoleKey.Y)
    {
        Console.WriteLine();
        return true;
    }
    else
    {
        Console.WriteLine();
        return false;
    }
}


void Main()
{
    bool readUsersInput = ReadAnArray();
    string[] sourceArray = readUsersInput
                         ? GetUsersInputedArray()
                         : GetRandomDefaultArray();
    int stringLength = GetStringLengthForSelection();
    string[] resultingArray = ReturnStringsLessEqualArgs((sourceArray, stringLength));
    ShowResult((usersArray: sourceArray,
                resultArray: resultingArray));
}


Main();
