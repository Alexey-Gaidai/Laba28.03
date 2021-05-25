using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Laba28._03
{
    public class search
    {
        public string directory;
        public string word;
        public string paths;
        public search(string keyword, string path)
        {
            this.directory = path;
            this.word = keyword;
        }
        public void result()
        {
            var keywords = from search in Directory.GetFiles(directory, "*", SearchOption.AllDirectories) where File.ReadAllLines(search).Contains(word) select search;

            foreach (var files in keywords)
            {
                paths += files;
                paths += "\n";
                Console.WriteLine(files);
            }

        }

    }
    class file
    {
        string keyword;
        string path;
        public string this[string propname]
        {
            get
            {
                switch (propname)
                {
                    case "keyword": 
                        return keyword;
                    case "path": 
                        return path;
                    default: 
                        return null;
                }
            }
            set
            {
                switch (propname)
                {
                    case "keyword":
                        keyword = value;
                        break;
                    case "path":
                       path = value;
                        break;
                }
            }
        }
    }
}
