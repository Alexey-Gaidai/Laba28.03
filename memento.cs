using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Laba28._03
{
    public class Memento
    {
        public string textfromfile { get; private set; }
        public Memento(string Text)
        {
            this.textfromfile = Text;
        }
    }
    public class TextHistory//caretracker
    {
        public Stack<Memento> History { get; private set; }
        public TextHistory()
        {
            History = new Stack<Memento>();
        }
    }
    
    class Text
    {
        public string path { get; set; }
        public string textfromfile;
        public Text(string Path)
        {
            this.path = Path;
        }

        public void ReadTxt()
        {
            FileStream fstream = File.OpenRead(path);
                    // преобразуем строку в байты
            byte[] array = new byte[fstream.Length];
                    // считываем данные
            fstream.Read(array, 0, array.Length);
                    // декодируем байты в строку
            textfromfile = System.Text.Encoding.Default.GetString(array);
            Console.WriteLine("ваш текст: {0}", textfromfile);
            fstream.Close();
        }
        public Memento SaveText()
        {
            Console.WriteLine("Сохранение текста: {0}", textfromfile);
            return new Memento(textfromfile);
        }
        public void RestoreState(Memento memento)
        {
            this.textfromfile = memento.textfromfile;
            File.WriteAllText(path, string.Empty);
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(this.textfromfile);
                fstream.Write(array);
            }
            Console.WriteLine("Восстановление текста: {0}", textfromfile);
        }
    }
    
}
