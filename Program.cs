using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace Laba28._03
{
    class Program
    {
        static void Main(string[] args)
        {
            /*FileStream fs = new FileStream("D:\\FullNameSerialize.xml", FileMode.OpenOrCreate, FileAccess.Write);
            FullNameClass fnc = new FullNameClass("Ivan", "Ivanov", "Ivanovich");
            fnc.Print();
            fnc.Serialize(fs);
            fnc = new FullNameClass("Petr", "Petrov", "Petrovich");
            fnc.Print();
            fs = new FileStream("D:\\FullNameSerialize.xml", FileMode.OpenOrCreate, FileAccess.Read);
            fnc.Deserialize(fs);
            fnc.Print();
            string path = @"D:\laba28.03";
            search kw = new search("day", path);
            kw.result();
            */
            
            string choice;//переменная ввода
            string path;
            string keyword;

            while (true)//менюшка, ее логика
            {
                
                Console.WriteLine("\n=======================\n"); //выводы
                Console.Write("Меню: \n" +
                    "1) Сериализовать бинарно\n" +
                    "2) Десериализовать бинарно\n" +
                    "3) Сериализовать в XML\n" +
                    "4) Десериализовать XML\n" +
                    "5) Поиск по ключевым словам\n" +
                    "f - ВЫХОД ИЗ ПРОГРАММЫ \n " +
                    "Ввод: ");
                choice = Console.ReadLine();
                Console.Clear();

                //проверка на выход
                if (choice == "f")
                {
                    Console.WriteLine("\n\n\n\nВЫХОД\n\n\n\n");
                    break;
                }
                switch (choice)//действия по нажатию
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":
                        Console.WriteLine("Введите путь к файлу: ");
                        path = Console.ReadLine();
                        FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                        FullNameClass fnc = new FullNameClass("Ivan", "Ivanov", "Ivanovichsuka");
                        fnc.Print();
                        fnc.Serialize(fs);
                        Console.WriteLine("Сериализовано!");
                        break;
                    case "4":
                        Console.WriteLine("Введите путь к файлу: ");
                        path = Console.ReadLine();
                        fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
                        FullNameClass fnc1 = new FullNameClass();
                        fnc1.Deserialize(fs);
                        fnc1.Print();
                        break;
                    case "5":
                        Console.WriteLine("Введите директорию: ");
                        path = Console.ReadLine();
                        Console.WriteLine("Введите Ключевое слово: ");
                        keyword = Console.ReadLine();
                        Console.WriteLine("Файлы содержащие ключевое слово: ");
                        search kw = new search(keyword, path);
                        kw.result();
                        break;
                    default:
                        Console.WriteLine("Введено некорректное значение");
                        break;
                }
            }
        }
    }
}
