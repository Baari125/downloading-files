using System.IO;

namespace Kopiowanie
{
    class Files
    {
        public static void DeleteFile()
        {
            var path = Directory.GetCurrentDirectory();
          
            DirectoryInfo di = new DirectoryInfo(Path.Combine(path, "Plik"));

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }
    }
}
