using System.Text;
using System;
using System.IO;
using Spire.Doc;
using Spire.Pdf;
using Spire.Xls;
using System.Net;


namespace Kopiowanie
{
    class Conversion
    {

        private static string DirectoryPath = Directory.GetCurrentDirectory();

        public Conversion() { }

        ~Conversion() { GC.Collect(); }

        public void ConvertFromDoc(string link, string path, string file)
        {
            Document document = new Document();
            WebClient Client = new WebClient();
            Client.DownloadFile(link, Path.Combine(DirectoryPath, "Plik\\DocFile.doc"));
            document.LoadFromFile(Path.Combine(DirectoryPath, "Plik\\DocFile.doc"));
            document.SaveToFile(Path.Combine(DirectoryPath, "Plik\\1.txt"), Spire.Doc.FileFormat.Txt);

            string content = File.ReadAllText(Path.Combine(DirectoryPath, "Plik\\1.txt"));

            JsonFile jf = new JsonFile();
            jf.CreatJson(link, content, Path.Combine(path, file));
        }

        public void ConvertFromPdf(string link, string path, string file)
        {
            PdfDocument pdfDocument = new PdfDocument();
            WebClient Client = new WebClient();
            Client.DownloadFile(link, Path.Combine(DirectoryPath, "Plik\\PdfFile.pdf"));
            pdfDocument.LoadFromFile(Path.Combine(DirectoryPath, "Plik\\PdfFile.pdf"));
            pdfDocument.SaveToFile(Path.Combine(DirectoryPath, "Plik\\DocFile.doc"), Spire.Pdf.FileFormat.DOC);

            Document document = new Document();
            document.LoadFromFile(Path.Combine(DirectoryPath, "Plik\\DocFile.doc"));
            document.SaveToFile(Path.Combine(DirectoryPath, "Plik\\1.txt"), Spire.Doc.FileFormat.Txt);

            string content = File.ReadAllText(Path.Combine(DirectoryPath, "Plik\\1.txt"));

            JsonFile jf = new JsonFile();
            jf.CreatJson(link, content, Path.Combine(path, file));
        }

        public void ConvertFromXls(string link, string path, string file)
        {
            Workbook workbook = new Workbook();
            WebClient Client = new WebClient();
            Client.DownloadFile(link, Path.Combine(DirectoryPath, "Plik\\XlsFile.xls"));
            workbook.LoadFromFile(Path.Combine(DirectoryPath, "Plik\\XlsFile.xls"));
            Worksheet sheet = workbook.Worksheets[0];
            sheet.SaveToFile(Path.Combine(DirectoryPath, "Plik\\1.txt"), " ", Encoding.UTF8);

            string content = File.ReadAllText(Path.Combine(DirectoryPath, "Plik\\1.txt"));

            JsonFile jf = new JsonFile();
            jf.CreatJson(link, content, Path.Combine(path, file));
        }
    }
}
