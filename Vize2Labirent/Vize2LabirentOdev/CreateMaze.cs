using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vize2LabirentOdev
{
    internal class CreateMaze
    {
        public char[,] maze;
        public List<int> startPoints;
        public void generateMaze()
        {
            maze = new char[30, 30];
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    maze[i, j] = '#';
                }
            }
        }
        public void findStartPoints()
        {
            Random random = new Random();
            int sizeOfStartPoint = random.Next(4, 10);
            startPoints = new List<int>();
            int point;
            for (int i = 0; i < sizeOfStartPoint; i++)
            {
                do
                {
                    point = random.Next(30);
                } while (startPoints.Contains(point));
                startPoints.Add(point);
            }
        }

        public void findPath()
        {
            generateMaze();
            findStartPoints();
            Random random = new Random();
            for (int i = 0; i < startPoints.Count; i++)
            {
                int x = 0;
                int y = startPoints[i];
                while (true)
                {
                    if (x == 29)
                    {
                        break;
                    }
                    int move = random.Next(1, 5);
                    maze[x, y] = '0';
                    if (move == 1 && y - 1 >= 0)
                    {
                        y--;
                        maze[x, y] = '0';
                    }

                    if (move == 2 && y + 1 < 30)
                    {
                        y++;
                        maze[x, y] = '0';
                    }

                    if (move == 3 && x + 1 < 30)
                    {
                        x++;
                        maze[x, y] = '0';
                    }
                }
            }

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (maze[i, j] == '#')
                    {
                        maze[i, j] = '1';
                    }
                }
            }
            pathKiller();
            pathFiller();
        }

        public void pathFiller()
        {
            for (int i = 1; i < 29; i++)
            {
                int counter = 0;
                for (int j = 0; j < 30; j++)
                {
                    if (maze[i, j] == '1')
                    {
                        counter++;
                    }
                    else if (maze[i, j] == '0')
                    {
                        counter = 0;
                    }

                    if (counter == 5)
                    {
                        maze[i, j - 1] = '0';
                        maze[i, j - 2] = '0';
                        counter = 0;
                    }
                }
            }
        }


        public void pathKiller()
        {
            Random random = new Random();
            int quantity = startPoints.Count / 2;
            int counter = 0;
            for (int i = 0; i < 30; i++)
            {
                if (counter == quantity)
                {
                    break;
                }
                if (maze[29, i] == '0')
                {
                    int tos = random.Next(3);
                    if (tos != 0)
                    {
                        maze[29, i] = '1';
                        counter++;
                    }
                }
            }

        }
        public void sendFile(string fileName)
        {
            StreamWriter yaz = new StreamWriter(fileName);

            for (int i = 0; i < 30; i++)
            {
                if (i == 0)
                    yaz.Write("{");
                for (int j = 0; j < 30; j++)
                {
                    if (j == 0)
                        yaz.Write("{");
                    yaz.Write(maze[i, j] + ",");
                    if (j == 29 && i != 29)
                        yaz.Write("},");
                }
                if (i == 29)
                    yaz.Write("}");
                yaz.Write("\n");
            }
            yaz.Close();
        }
    }
}
