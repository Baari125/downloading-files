using System;
using System.Collections.Generic;
using System.IO;

namespace Kopiowanie
{
    class DataBase
    {
        private static string DirectoryPath = Directory.GetCurrentDirectory();

        public DataBase() { }

        ~DataBase() { GC.Collect(); }
        
        private void CreatDirectoryForDataBase(string directoryName)
        {
            string directory = Path.Combine(DirectoryPath, "Baza", directoryName);

            Directory.CreateDirectory(directory);
            Directory.CreateDirectory(Path.Combine(directory, "Parser"));
            Directory.CreateDirectory(Path.Combine(directory, "Files"));
        }

        public void CreatDataBase(string website)
        {
            CreatDirectoryForDataBase(website);
            string line = File.ReadAllText(Path.Combine(DirectoryPath, "GENERATE_FILES", website));
            string content = (new Parser()).ToParser(line);
            string path = Path.Combine(DirectoryPath, "Baza", website);
            File.WriteAllText(Path.Combine(path, "Parser\\parser.txt"), content);
            GenerateFiles(website, Path.Combine(path, "Files"));
        }

        private void GenerateFiles(string website, string path)
        {
            string line;
            try
            {
                var linkList = new List<string>();
                StreamReader sr = new StreamReader(Path.Combine(DirectoryPath, "GENERATE_FILES", website));
                bool save = false;
                Console.WriteLine(website+".txt");
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("<li><a href="))
                    {
                        save = true;
                    }
                    if (save)
                    {
                        var tab = line.Split('"');
                        var link = tab[1];
                        string domena = "https://www.7szmw.pl";

                        linkList.Add(domena + link);
                    }
                    if (line.Contains("</li>"))
                        save = false;
                }
                ConvertToDataBase(linkList, path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void ConvertToDataBase(List<string> linkList, string path)
        {
            int FileCounter = 1;
            foreach (var link in linkList)
            {
                Conversion conversion = new Conversion();

                string file = FileCounter + ".json";
                if (link.Contains(".doc"))
                    conversion.ConvertFromDoc(link, path, file);

                if (link.Contains(".pdf"))
                    conversion.ConvertFromPdf(link, path, file);

                if (link.Contains(".xls"))
                    conversion.ConvertFromXls(link, path, file);

                FileCounter++;

                Files.DeleteFile();
            }
        }
    }
}
