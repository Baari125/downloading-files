using System;
using System.Threading;
using System.Windows.Forms;

namespace Kopiowanie
{
    class Parser
    {
        public Parser() { }

        ~Parser() { GC.Collect(); }

        private string returnText;

        public string ToParser(string html)
        {
            Thread t = new Thread(TParseMain);
            t.ApartmentState = ApartmentState.STA;
            t.Start((object)html);
            t.Join();
            return returnText;
        }
        [STAThread]
        private void TParseMain(object html)
        {
            WebBrowser wbc = new WebBrowser();
            wbc.DocumentText = "aasaa";
            HtmlDocument doc = wbc.Document.OpenNew(true);
            doc.Write((string)html);
            this.returnText = doc.Body.InnerText;
            return;
        }
    }
}
