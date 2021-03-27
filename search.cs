using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Laba28._03
{
    class search
    {
        public string directory;
        public string word;
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
                Console.WriteLine(files);
            }
        }
    }
}
