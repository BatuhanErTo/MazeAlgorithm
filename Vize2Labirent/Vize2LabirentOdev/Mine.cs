using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vize2LabirentOdev
{
    internal class Mine
    {
        public List<int> logRowMine = new List<int>();
        public List<int> logColumnMine = new List<int>();
        public void SetMines(char[,] elements)
        {
            Random rnd = new Random();
            int rowMine, columnMine;

            List<int> checkColumnMine = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                rowMine = rnd.Next(30);
                logRowMine.Add(rowMine);
                do
                {
                    if (i == 0)
                    {
                        columnMine = rnd.Next(30);
                        checkColumnMine.Add(columnMine);
                    }
                    else
                    {
                        do
                        {
                            columnMine = rnd.Next(30);
                        } while (checkColumnMine.Contains(columnMine));
                        checkColumnMine.Add(columnMine);
                    }
                } while (elements[rowMine, columnMine] == '1');
                logColumnMine.Add(columnMine);
            }
        }

        public void displayLocationOfMines(char[,] elements)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (i == logRowMine[0] && j == logRowMine[0])
                    {
                        elements[i, j] = 'B';
                    }
                    if (i == logRowMine[1] && j == logRowMine[1])
                    {
                        elements[i, j] = 'B';
                    }
                    if (i == logRowMine[2] && j == logRowMine[2])
                    {
                        elements[i, j] = 'B';
                    }
                }
            }
        }
    }
}
