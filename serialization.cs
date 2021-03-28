using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace Laba28._03
{
  
        [Serializable]
        public class FullNameClass : Originator
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Age { get; set; }

            public FullNameClass()
            { }
            public FullNameClass(string name, string surname, int age)
            {
                Name = name; Surname = surname; Age = age;
            }

            public void SerializeBin(FileStream fs)
            {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Flush();
            fs.Close();
            }
            public void DeserializeBin(FileStream fs)
            {
            BinaryFormatter bf = new BinaryFormatter();
            FullNameClass deserialized = (FullNameClass)bf.Deserialize(fs);
            Name = deserialized.Name;
            Surname = deserialized.Surname;
            Age = deserialized.Age;
            fs.Close();
            }

            public void SerializeXML(FileStream fs)
            {
                XmlSerializer bf = new XmlSerializer(typeof(FullNameClass));
                bf.Serialize(fs, this);
                fs.Flush();
                fs.Close();
            }
            public void DeserializeXML(FileStream fs)
            {
                XmlSerializer bf = new XmlSerializer(typeof(FullNameClass));
                FullNameClass deserialized = (FullNameClass)bf.Deserialize(fs);
                Name = deserialized.Name;
                Surname = deserialized.Surname;
                Age = deserialized.Age;
                fs.Close();
            }
            public void Print()
            {
                Console.WriteLine("Name={0} Surname={1} Middle={2}", Name, Surname, Age);
            }
        }
}
