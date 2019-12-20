using System;
using System.IO;

namespace Kopiowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase db = new DataBase();
            db.CreatDataBase("stronaTest.txt");
            Console.WriteLine("gotowe");
            Console.Read();
        }
    }
}