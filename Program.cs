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

            string choice;//переменная ввода
            string path;
            string keyword;
            Console.WriteLine("Введите текстовый файл для работы");
            string path2 = Console.ReadLine();
            Text text2 = new Text(path2);
            TextHistory texthistory = new TextHistory();



            while (true)//менюшка, ее логика
            {
                
                Console.WriteLine("\n=======================\n"); //выводы
                Console.Write("Меню: \n" +
                    "1) Сериализовать бинарно\n" +
                    "2) Десериализовать бинарно\n" +
                    "3) Сериализовать в XML\n" +
                    "4) Десериализовать XML\n" +
                    "5) Поиск по ключевым словам\n" +
                    "6) Прочесть файл\n" +
                    "7) Записать в файл\n" +
                    "8) Сохранить файл\n" +
                    "9) Вернуть сохранение\n" +
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
                        Console.WriteLine("Введите путь к файлу: ");
                        path = Console.ReadLine();
                        FileStream bin = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                        FullNameClass fnc2 = new FullNameClass("Grigory", "Grigoriev", 18);
                        fnc2.Print();
                        fnc2.SerializeBin(bin);
                        Console.WriteLine("Сериализовано!");
                        break;
                    case "2":
                        Console.WriteLine("Введите путь к файлу: ");
                        path = Console.ReadLine();
                        bin = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
                        FullNameClass fnc3 = new FullNameClass();
                        fnc3.DeserializeBin(bin);
                        fnc3.Print();
                        Console.WriteLine("Десериализовано!");
                        break;
                    case "3":
                        Console.WriteLine("Введите путь к файлу: ");
                        path = Console.ReadLine();
                        FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                        FullNameClass fnc = new FullNameClass("Ivan", "Ivanov", 20);
                        fnc.Print();
                        fnc.SerializeXML(fs);
                        Console.WriteLine("Сериализовано!");
                        break;
                    case "4":
                        Console.WriteLine("Введите путь к файлу: ");
                        path = Console.ReadLine();
                        fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
                        FullNameClass fnc1 = new FullNameClass();
                        fnc1.DeserializeXML(fs);
                        fnc1.Print();
                        Console.WriteLine("Десериализовано!");
                        break;
                    case "5"://
                        Console.WriteLine("Введите директорию: ");
                        path = Console.ReadLine();
                        Console.WriteLine("Введите Ключевое слово: ");
                        keyword = Console.ReadLine();
                        Console.WriteLine("Файлы содержащие ключевое слово: ");
                        search kw = new search(keyword, path);
                        kw.result();
                        break;
                    case "6":
                        using (FileStream fstream = File.OpenRead(path2))
                        {
                            // преобразуем строку в байты
                            byte[] array = new byte[fstream.Length];
                            // считываем данные
                            fstream.Read(array, 0, array.Length);
                            // декодируем байты в строку
                            string textFromFile = System.Text.Encoding.Default.GetString(array);
                            Console.WriteLine($"Текст из файла:\n{textFromFile}");
                        }
                        break;
                    case "7":
                        using (FileStream fstream = File.OpenRead(path2))
                        {
                            // преобразуем строку в байты
                            byte[] array = new byte[fstream.Length];
                            // считываем данные
                            fstream.Read(array, 0, array.Length);
                            // декодируем байты в строку
                            string textFromFile = System.Text.Encoding.Default.GetString(array);
                            Console.WriteLine($"Текст из файла:\n{textFromFile}");
                        }
                        Console.WriteLine("Введите что хотите дописать: ");
                        string text = Console.ReadLine();

                        // запись в файл
                        using (FileStream fstream = new FileStream(path2, FileMode.OpenOrCreate))
                        {
                            fstream.Seek(0, SeekOrigin.End);
                            byte[] array = System.Text.Encoding.Default.GetBytes(text);
                            fstream.Write(array);
                            Console.WriteLine("Текст записан в файл");
                        }
                        using (FileStream fstream = File.OpenRead(path2))
                        {
                            // преобразуем строку в байты
                            byte[] array = new byte[fstream.Length];
                            // считываем данные
                            fstream.Read(array, 0, array.Length);
                            // декодируем байты в строку
                            string textFromFile = System.Text.Encoding.Default.GetString(array);
                            Console.WriteLine($"Новый текст:\n{textFromFile}");
                        }
                        break;
                    case "8":
                        text2.ReadTxt();
                        texthistory.History.Push(text2.SaveText());
                        break;
                    case "9":
                        text2.RestoreState(texthistory.History.Pop());
                        break;
                    default:
                        Console.WriteLine("Введено некорректное значение");
                        break;
                }
            }
        }
    }
}
