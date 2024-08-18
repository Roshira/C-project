using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryList
{



    public class InfoInFile
    {

        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int UAH { get; set; }
        public string Comment { get; set; }
        public string Type { get; set; }

        // Конструктор для ініціалізації змінних
        public InfoInFile(int day, int month, int year,int Uah,string comment, string type)
        {
            Day = day;
            Month = month;
            Year = year;
            UAH = Uah;
            Comment = comment;
            Type = type;

        }
    }
    public class MainSumUAH
    {
        public void MenuFORSum(string fileExpenses, string fileIncome)
        {
            int temp = 1;
            summer2 printSum = new summer2();
            InfoYears infoYears = new InfoYears();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please choose what you want to see\n");

                string exp = "Type sum";
                string inc = "all sum";
                string exit = "Exit";
                string InfoYears = "Only info about year";
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
                    InfoYears = clicer + InfoYears;
                }
                else if(temp == 4)
                    exit = clicer + exit;

                Console.WriteLine(exp);
                Console.WriteLine(inc);
                Console.WriteLine(InfoYears);
                Console.WriteLine(exit);

                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key == ConsoleKey.S && temp < 4)
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
                        printSum.printType(fileExpenses, fileIncome);
                    }
                    else if (temp == 2)
                    {
                        printSum.printAll(fileExpenses, fileIncome);
                    }
                    else if (temp == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Please writing years for information");
                        string input;
                        int years;

                        while (true)
                        {
                            input = Console.ReadLine();
                            if (int.TryParse(input, out years))
                            {
                                Console.WriteLine($"Expenses {infoYears.Search(fileExpenses, years)}");
                                Console.WriteLine($"Income {infoYears.Search(fileIncome, years)}");
                                Console.WriteLine($"Total result: {infoYears.Search(fileIncome, years) - infoYears.Search(fileExpenses, years)}");
                                Console.Read();
                                break; // Вихід з циклу після успішного введення
                            }
                            else
                            {
                                Console.WriteLine("Помилка: Введено неправильне значення. Введіть ціле число.");
                            }
                        }
                    }
                    else if (temp == 4)
                    {
                        break;
                    }
                }
            }

        }

    }

    internal class InfoYears
    {
        internal long Search(string file,int years)
        {
            bool play = true;
            long result = 0;
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                while (play)
                {
                    try
                    {

                        InfoInFile info = new InfoInFile(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadString(), reader.ReadString());
                        
                        if(info.Year != years)
                        {
                            continue;
                        }
                        result += info.UAH;
                    }
                    catch
                    {
                        play = false;

                    }
                }
            }
            return result;
        }
    }

    internal class summer2
    {
        internal void printAll(string fileExpenses, string fileIncome)
        {
            Console.Clear();
            Console.WriteLine($"All expenses: {openFile(fileExpenses, false, null)}");
            Console.WriteLine($"All income: {openFile(fileIncome, false, null)}");
            Console.WriteLine($"What we get: {openFile(fileIncome, false, null) - openFile(fileExpenses, false, null)}");
            Console.ReadLine();
        }

        internal void printType(string fileExpenses,string fileIncome)
        {
            
            Console.Clear();
            Console.Write("Please writing type: ");
            string typeUser = Console.ReadLine();
            Console.WriteLine($"All expenses: {openFile(fileExpenses, true, typeUser)}");
            Console.WriteLine($"All income: {openFile(fileIncome, true, typeUser)}");
            Console.WriteLine($"What we get: {openFile(fileIncome, true, typeUser) - openFile(fileExpenses, true, typeUser)}");
            Console.ReadLine();
        }

        internal long openFile(string file, bool type,string typeUser)
        {
            bool play = true;
            long result = 0;
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                while (play)
                {
                    try
                    {
                        
                        InfoInFile info = new InfoInFile(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadString(), reader.ReadString());
                        if (type)
                        {
                            if (typeUser != info.Type)
                                continue;
                        }
                        result += info.UAH;
                    }
                    catch
                    {
                        play = false;

                    }
                }
            }
            return result;
        }
    }
}
