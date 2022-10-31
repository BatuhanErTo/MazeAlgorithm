using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vize2LabirentOdev
{
    internal class ReadingText
    {
        public char[,] elements;
        public void Read(string fileName)
        {
            try
            {
                string[] xy = System.IO.File.ReadAllLines(fileName);
                elements = new char[xy.Length, 30];
                int firstIndex = 0;
                int secondIndex = 0;
                foreach (string x in xy)
                {
                    foreach (char y in x)
                    {

                        if (y == '0' || y == '1')
                        {
                            if (secondIndex == 30)
                            {
                                firstIndex++;
                                secondIndex = 0;
                            }
                            elements[firstIndex, secondIndex] = y;
                            secondIndex++;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Girilen dosya hatalıdır veyahut içerisinde içerik yoktur sistemi kapatıp tekrar deneyiniz.");
            }
            
        }
    }
}
