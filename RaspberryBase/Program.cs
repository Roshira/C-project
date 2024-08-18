using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System.Numerics;
using RaspberryList;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
Menu menu = new Menu();
ReadExpenses expenses = new ReadExpenses();
ReadAdd AddList = new ReadAdd();
InfAboutDay Search = new InfAboutDay();
ListDay list = new ListDay();
DeleteDay DelInf = new DeleteDay();
MainSumUAH Sum = new MainSumUAH();
Calculator calculator = new Calculator();

//string filePath = "Income.bin";
//using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
//using (BinaryWriter writer = new BinaryWriter(fs))
//{
//    writer.Write(03);
//    writer.Write(08);
//    writer.Write(2024);
//    writer.Write(4000);
//    writer.Write("We bought new chest for raspberry");
//}
    menu.MenuList(expenses, AddList,Search,list, DelInf,Sum,calculator);


public class Dates : IComparable<Dates>
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

    // Конструктор для ініціалізації змінних
    public Dates(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    public int CompareTo(Dates other)
    {
        int result = Year.CompareTo(other.Year);
        if (result == 0)
        {
            result = Month.CompareTo(other.Month);
            if (result == 0)
            {
                result = Day.CompareTo(other.Day);
            }
        }
        return result;
    }
}
public class Menu
{
    private int click = 0;
    private string FileIncome = "Income.bin";
    private string FileExpenses = "Expenses.bin";

    public void MenuList(ReadExpenses expenses1, ReadAdd add, InfAboutDay Search, ListDay list, DeleteDay deleteDay,
        RaspberryList.MainSumUAH SumDays, RaspberryList.Calculator calc)
    {
        while (true)
        {
            string Line1 = "1) Your expenses";
        string Line2 = "2) Your income";
        string Line3 = "3) Add expenses";
        string Line4 = "4) Add income";
        string Line5 = "5) Exit";
        string Line6 = "6)Search information about day(XX/XX/XXXX)";
        string Line7 = "7)Print all days whitch in RaspberryBase";
        string Line8 = "8)Delete someone day";
        string Line9 = "9)Different sum";
            string Line10 = "10)Open Calculator";

        string Line = "--> ";

        
            switch (click)
            {
                case 1:
                    Line1 = String.Concat(Line + Line1);
                    break;
                case 2:
                    Line2 = String.Concat(Line + Line2);
                    break;
                case 3:
                    Line3 = String.Concat(Line + Line3);
                    break;
                case 4:
                    Line4 = String.Concat(Line + Line4);
                    break;
                case 5:
                    Line5 = String.Concat(Line + Line5);
                    break;
                case 6:
                    Line6 = String.Concat(Line + Line6);
                    break;
                case 7:
                    Line7 = String.Concat(Line + Line7);
                    break;
                case 8:
                    Line8 = string.Concat(Line + Line8);
                    break;
                case 9:
                    Line9 = string.Concat(Line + Line9);
                    break;
                case 10:
                    Line10 = string.Concat(Line + Line10);
                    break;
            }
            Console.WriteLine(Line1);
            Console.WriteLine(Line2);
            Console.WriteLine(Line3);
            Console.WriteLine(Line4);
            Console.WriteLine(Line5);
            Console.WriteLine(Line6);
            Console.WriteLine(Line7);
            Console.WriteLine(Line8);
            Console.WriteLine(Line9);
            Console.WriteLine(Line10);
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            if (keyInfo.Key == ConsoleKey.S && click < 11)
            {
                click++;
            }
            else if (keyInfo.Key == ConsoleKey.W && click >= 0)
                click--;
            if (click == 0)
                click = 10;
            else if (click == 11)
                click = 1;
            if (keyInfo.Key == ConsoleKey.Enter && click < 11 && click > 0)
            {
                switch (click)
                {
                    case 1:
                        Console.Clear();
                        expenses1.Exp(FileExpenses);
                        break;
                    case 2:
                        Console.Clear();
                        expenses1.Exp(FileIncome);
                        break;
                    case 3:
                        Console.Clear();
                        add.addExpenses(FileExpenses);
                        break;
                    case 4:
                        Console.Clear();
                        add.addExpenses(FileIncome);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Proggram exit...");
                        Environment.Exit(0);
                        break;
                    case 6:
                        Search.InfDay(FileExpenses, FileIncome);
                        break;
                    case 7:
                        list.printListDay(FileExpenses, FileIncome);
                        break;
                    case 8:
                        deleteDay.DeleteInf(FileExpenses, FileIncome);
                        break;
                    case 9:
                        SumDays.MenuFORSum(FileExpenses, FileIncome);
                        break;
                        case 10:
                        calc.Calc();
                        break;
                }
            }
            Console.Clear();
        }
    }
};

public class InfAboutDay
{
    public void InfDay(string fileExpenses, string fileIncome)
    {
        int day;
        int month;
        int year;
        Console.WriteLine("Please enter the day that interests you:");
        Console.Write("Day: ");
        day = int.Parse(Console.ReadLine());
        Console.Write("Month: ");
        month = int.Parse(Console.ReadLine());
        Console.Write("Year: ");
        year = int.Parse(Console.ReadLine());
        Console.Clear();

        bool expensesFound = false;
        bool incomeFound = false;

        // Читання файлу витрат
        using (FileStream fs = new FileStream(fileExpenses, FileMode.Open, FileAccess.Read))
        using (BinaryReader br = new BinaryReader(fs))
        {
            while (!expensesFound)
            {
                try
                {
                    int Fd = br.ReadInt32();
                    int fm = br.ReadInt32();
                    int fy = br.ReadInt32();
                    if (Fd == day && fm == month && fy == year)
                    {
                        Console.WriteLine("Your expenses on this day:");
                        Console.WriteLine("----------------------------------------");
                        int expenses = br.ReadInt32();
                        string comment = br.ReadString();
                        string type = br.ReadString();
                        Console.WriteLine($"Day: {day}/{month}/{year}");
                        Console.WriteLine($"Expenses: {expenses} UAH");
                        Console.WriteLine($"Comment: {comment}");
                        Console.WriteLine($"Type: {type}");
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine();
                        expensesFound = true;
                    }
                    else
                    {
                        br.ReadInt32(); // Пропустити витрати
                        br.ReadString(); // Пропустити коментар
                        br.ReadString(); // Пропустити тип
                    }
                }
                catch
                {
                    expensesFound = true; // Вихід з циклу у випадку помилки (досягли кінця файлу)
                }
            }
        }

        // Читання файлу доходів
        using (FileStream fi = new FileStream(fileIncome, FileMode.Open, FileAccess.Read))
        using (BinaryReader bi = new BinaryReader(fi))
        {
            while (!incomeFound)
            {
                try
                {
                    int Fd = bi.ReadInt32();
                    int fm = bi.ReadInt32();
                    int fy = bi.ReadInt32();
                    if (Fd == day && fm == month && fy == year)
                    {
                        Console.WriteLine("Your income on this day:");
                        Console.WriteLine("----------------------------------------");
                        int income = bi.ReadInt32();
                        string comment = bi.ReadString();
                        string type = bi.ReadString();
                        Console.WriteLine($"Day: {day}/{month}/{year}");
                        Console.WriteLine($"Income: {income} UAH");
                        Console.WriteLine($"Comment: {comment}");
                        Console.WriteLine($"Type: {type}");
                        Console.WriteLine();
                        Console.WriteLine("----------------------------------------");
                        incomeFound = true;
                    }
                    else
                    {
                        bi.ReadInt32(); // Пропустити дохід
                        bi.ReadString(); // Пропустити коментар
                        bi.ReadString(); // Пропустити тип
                    }
                }
                catch
                {
                    incomeFound = true; // Вихід з циклу у випадку помилки (досягли кінця файлу)
                }
            }
        }

        Console.ReadLine();
    }
}
public class ReadExpenses
{
    public void Exp(string filePath)
    {
        bool play = true;
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            while (play)
            {
                try
                {
                    int day = reader.ReadInt32();
                    int mounth = reader.ReadInt32();
                    int years = reader.ReadInt32();
                    int expenses = reader.ReadInt32();
                    string comment = reader.ReadString();
                    string type = reader.ReadString();


                    Console.WriteLine($"Day: {day}/{mounth}/{years}");
                    Console.WriteLine($"Expenses or Income: {expenses} UAH");
                    Console.WriteLine($"Comment: {comment}");
                    Console.WriteLine($"Type: {type}");
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine("File the end");
                    play = false;

                }
            }

            
            Console.ReadLine();
        }
    }
}


public class ReadAdd
{
    public void addExpenses(string filePath)
    {
        int day;
        int month;
        int years;
        int expenses;
        string type;
        string comment;
        Console.WriteLine($">>>WRITING {filePath} <<<");
        Console.WriteLine("Writing day(XX/04/2024):");
        day = int.Parse(Console.ReadLine());
        Console.WriteLine("Writing mounth(03/08/2024):");
        month = int.Parse(Console.ReadLine());
        Console.WriteLine("Writing years(03/08/XXXX):");
        years = int.Parse(Console.ReadLine());
        Console.WriteLine("Writing expenses or income:");
        expenses = int.Parse(Console.ReadLine());
        Console.WriteLine("Writing  comment:");
        comment = Console.ReadLine();
        Console.WriteLine("Writing type:");
        type = Console.ReadLine();

        using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
            writer.Write(day);
            writer.Write(month);
            writer.Write(years);
            writer.Write(expenses);
            writer.Write(comment);
            writer.Write(type);

        }
        Console.ReadLine();

    }
}
//List<int> years = new List<int>();
//List<int> mounth = new List<int>();
//List<int> days = new List<int>();
public class ListDay
{
    public void printListDay(string fileExpenses, string fileIncome)
    {
        int temp = 1; // Змінна, що тримає поточний вибір меню
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Please choose what you want to see\n");

            string exp = "All days with expenses";
            string inc = "All days with income";
            string exit = "Exit";
            string clicer = "--->";

            // Відображення вибраного пункту меню
            if (temp == 1)
            {
                exp = clicer + exp;
            }
            else if (temp == 2)
            {
                inc = clicer + inc;
            }
            else if (temp == 3)
            {
                exit = clicer + exit;
            }

            Console.WriteLine(exp);
            Console.WriteLine(inc);
            Console.WriteLine(exit);

            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            if (keyInfo.Key == ConsoleKey.S && temp < 3)
            {
                temp++;
            }
            else if (keyInfo.Key == ConsoleKey.W && temp > 1)
            {
                temp--;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                if (temp == 1)
                {
                    printChouses(fileExpenses);
                }
                else if (temp == 2)
                {
                    printChouses(fileIncome);
                }
                else if (temp == 3)
                {
                    break;
                }
            }
        }
    }

    private void printChouses(string file)
    {

        List<Dates> list = new List<Dates>();

        bool play = false;
        // Читання файлу витрат
        using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
        using (BinaryReader br = new BinaryReader(fs))
        {
            while (!play)
            {
                try
                {
                    int Fd = br.ReadInt32();
                    int fm = br.ReadInt32();
                    int fy = br.ReadInt32();

                    list.Add(new Dates(Fd, fm, fy));
                   
                    br.ReadInt32(); // Пропустити витрати
                    br.ReadString(); // Пропустити коментар
                    br.ReadString(); // Пропустити тип
                    
                }
                catch
                {
                    play = true; // Вихід з циклу у випадку помилки (досягли кінця файлу)
                }
            }
            //        list.Sort();
            list.Sort();
            Console.Clear();
            foreach (var date in list)
            {
                Console.WriteLine($"{date.Day}/{date.Month}/{date.Year}");
            }
            Console.ReadLine();

        }
    }

}

public class DeleteDay
{
    public void DeleteInf(string fileExpenses, string fileIncome)
    {
        int temp = 1; 
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Please choose what you want to see\n");

            string exp = "Delete expenses day";
            string inc = "Delete income day";
            string exit = "Exit";
            string clicer = "--->";

            if (temp == 1)
            {
                exp = clicer + exp;
            }
            else if (temp == 2)
            {
                inc = clicer + inc;
            }
            else if (temp == 3)
            {
                exit = clicer + exit;
            }

            Console.WriteLine(exp);
            Console.WriteLine(inc);
            Console.WriteLine(exit);

            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            if (keyInfo.Key == ConsoleKey.S && temp < 3)
            {
                temp++;
            }
            else if (keyInfo.Key == ConsoleKey.W && temp > 1)
            {
                temp--;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                if (temp == 1)
                {
                    startDelete(fileExpenses);
                }
                else if (temp == 2)
                {
                    startDelete(fileIncome);
                }
                else if (temp == 3)
                {
                    break;
                }
            }
        }
    }

    public void startDelete(string file)
    {
        Console.WriteLine("Writting day whith you want delete");
        Console.Write("Day:");
        int deleteDay = int.Parse(Console.ReadLine());
        Console.Write("Mounth:");
        int deleteMounth = int.Parse(Console.ReadLine());
        Console.Write("Years:");
        int deleteYears = int.Parse(Console.ReadLine());

        string filePath = "clon.bin";
        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        using (BinaryWriter writer = new BinaryWriter(fs))
        {

            bool play = true;
            using (FileStream fileOpen = new FileStream(file, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fileOpen))
            {
                while (play)
                {
                    try
                    {
                        int day = reader.ReadInt32();
                        int mounth = reader.ReadInt32();
                        int years = reader.ReadInt32();
                        int expenses = reader.ReadInt32();
                        string comment = reader.ReadString();
                        string type = reader.ReadString();
                        if(deleteDay == day && deleteMounth == mounth && deleteYears == years)
                            continue;

                        writer.Write(day);
                        writer.Write(mounth);
                        writer.Write(years);
                        writer.Write(expenses);
                        writer.Write(comment);
                        writer.Write(type);
                    }
                    catch
                    {
                        Console.WriteLine("File the end");
                        play = false;

                    }
                }
            }
        }
        try
        {
            if (File.Exists(file))
            {
                File.Delete(file);
                Console.WriteLine("File deleted successfully.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        try
        {
            if (File.Exists("clon.bin"))
            {
                File.Move("clon.bin", file);
                Console.WriteLine("File renamed successfully.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}






