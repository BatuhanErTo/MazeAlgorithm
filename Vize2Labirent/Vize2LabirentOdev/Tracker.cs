using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vize2LabirentOdev
{
    internal class Tracker
    {
        public List<int> indexX;
        public List<int> indexY;
        public List<int> mineX;
        public List<int> mineY;
        public int kl;
        public void getIndexOfMines(List<int> mineX, List<int> mineY)
        {
            this.mineX = mineX;
            this.mineY = mineY;
        }

        public bool isCounterMine()// if  result == true
        {
            for (int i = 0; i < indexX.Count; i++)
            {
                if (indexX[i] == mineX[0] && indexY[i] == mineY[0])
                {
                    Console.WriteLine(indexX[i] + "," + indexY[i] + "'de mayına bastın");
                    return false;
                }
                else if (indexX[i] == mineX[1] && indexY[i] == mineY[1])
                {
                    Console.WriteLine(indexX[i] + "," + indexY[i] + "'de mayına bastın");
                    return false;
                }
                else if (indexX[i] == mineX[2] && indexY[i] == mineY[2])
                {
                    Console.WriteLine(indexX[i] + "," + indexY[i] + "'de mayına bastın");
                    return false;
                }
            }
            return true;
        }
        public void Solution(char[,] elements)
        {
            kl = 0;
            indexX = new List<int>();
            indexY = new List<int>();
            for (int j = 0; j < elements.GetLongLength(1); j++)
            {
                if (elements[0, j] == '0')
                {
                    bool result = Solve(0, j, elements);

                    if (result)
                    {
                        kl = 1;
                        if (!isCounterMine())
                        {
                            Console.Beep();
                            Console.WriteLine("Mayına bastığından dolayı oyun bitmiştir");
                            Environment.Exit(0);
                        }
                        Console.WriteLine("Çıkışa götüren yol => ");
                        Console.WriteLine("Satır|Sütun");
                        for (int i = indexX.Count - 1; i >= 0; i--)
                        {
                            Console.WriteLine(indexX[i] + "\t" + indexY[i]);
                        }
                        for (int l = 0; l < 30; l++)
                        {
                            for (int k = 0; k < 30; k++)
                            {
                                if (elements[l, k] == '|')
                                {
                                    // Başarısız giden yolların işaretini eski haline döndürür
                                    elements[l, k] = '0';
                                }
                            }
                        }
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            for (int k = 0; k < 30; k++)
                            {
                                if (elements[i, k] == '|')
                                {
                                    // Başarısız giden yolların işaretini eski haline döndürür
                                    elements[i, k] = '0';
                                }
                            }
                        }
                    }
                }
            }
            if (kl == 0)
            {
                Console.WriteLine("Labirentin çıkışı yok");
            }
        }
        public bool isValid(int i, int j, char[,] elements)
        {
            if (i >= 0 && i < 30 && j >= 0 && j < 30 && elements[i, j] == '0')
            {
                return true;
            }
            return false;
        }

        public bool Solve(int x, int y, char[,] elements)
        {
            if (Move(x, y, elements) == false)
            {
                return false;
            }
            return true;
        }

        public bool Move(int i, int j, char[,] elements)
        {
            if (i == 29 && elements[i, j] == '0')
            {
                elements[i, j] = 'X';
                indexX.Add(i);
                indexY.Add(j);
                return true;
            }

            if (isValid(i, j, elements) == true)
            {
                elements[i, j] = 'X';

                if (Move(i + 1, j, elements)) // aşağı
                {
                    indexX.Add(i);
                    indexY.Add(j);
                    return true;
                }
                if (Move(i, j + 1, elements)) // sağ
                {
                    indexX.Add(i);
                    indexY.Add(j);
                    return true;
                }
                if (Move(i, j - 1, elements)) // sol
                {
                    indexX.Add(i);
                    indexY.Add(j);
                    return true;
                }
                if (Move(i - 1, j, elements)) // yukarı
                {
                    indexX.Add(i);
                    indexY.Add(j);
                    return true;
                }

                elements[i, j] = '|';
                return false;

            }
            return false;
        }
    }
}
