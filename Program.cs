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
                FileStream fs = new FileStream("D:\\FullNameSerialize.xml",FileMode.OpenOrCreate, FileAccess.Write);
                FullNameClass fnc = new FullNameClass("Ivan", "Ivanov", "Ivanovich");
                fnc.Print();
                fnc.Serialize(fs);
                fnc = new FullNameClass("Petr", "Petrov", "Petrovich");
                fnc.Print();
                fs = new FileStream("D:\\FullNameSerialize.xml",FileMode.OpenOrCreate, FileAccess.Read);
                fnc.Deserialize(fs);
                fnc.Print();
        }
    }
}
