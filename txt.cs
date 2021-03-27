﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace Laba28._03
{
  
        [Serializable]
        public class FullNameClass
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string MiddleName { get; set; }

            public FullNameClass()
            { }
            public FullNameClass(string name, string surname, string middle)
            {
                Name = name; Surname = surname; MiddleName = middle;
            }
            public void Serialize(FileStream fs)
            {
                XmlSerializer bf = new XmlSerializer(typeof(FullNameClass));
                bf.Serialize(fs, this);
                fs.Flush();
                fs.Close();
            }
            public void Deserialize(FileStream fs)
            {
                XmlSerializer bf = new XmlSerializer(typeof(FullNameClass));
                FullNameClass deserialized = (FullNameClass)bf.Deserialize(fs);
                Name = deserialized.Name;
                Surname = deserialized.Surname;
                MiddleName = deserialized.MiddleName;
                fs.Close();
            }
            public void Print()
            {
                Console.WriteLine("Name={0} Surname={1} Middle={2}", Name, Surname, MiddleName);
            }
        }
    }
