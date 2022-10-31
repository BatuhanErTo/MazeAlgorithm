using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vize2LabirentOdev
{
    internal class Game
    {
        public void Start()
        {
            Console.Write("Menüye Hoşgeldiniz ==>\n\tPress 1 : Kullanma Kılavuzu\n\tPress 2: Labirent Üretme\n\tPress 3: Labirent Çözme\n\tPress 4 : Çıkış ==>");
            int tus = Convert.ToInt32(Console.ReadLine());
            while (tus != 4)
            {
                if (tus == 1)
                {
                    Console.WriteLine("*Tuş 2'ye basarsanız sistem bir txt dosyasına bir labirent üreticektir");
                    Console.WriteLine("*Tuş 3'e basarsanız sistem girilen dosyayı okuyup labirenti çözecektir\n\t**X tuşuna basarsanız size labirenti, B tuşuna basarsanız size mayınların yerini, L tuşuna basarsanız size labirentin orjinal halini gösterecektir.");
                }
                else if (tus == 2)
                {
                    CreateMaze createMaze = new CreateMaze();
                    createMaze.findPath();
                    Console.WriteLine("Labirent Üretme kısmına hoşgeldin, yazılması istenilen dosya uzantısını 'C:\\Users\\batuh\\Desktop\\Vize2Labirent\\LabirentUret.txt' şeklinde giriniz ve dosya yolunda bulunan txt dosyasının boş bir dosya olması gerekmektedir ==> ");
                    string dosyaUzantısı = Console.ReadLine();
                    string dosyaYolu = "" + dosyaUzantısı;
                    createMaze.sendFile(dosyaYolu);
                    Console.WriteLine("Labirent Dosyaya aktarıldı.");
                }
                else if (tus == 3)
                {
                    Console.Write("Labirent çözme kısmına hoşgeldin,okunması istenilen dosyanın uzantısını 'C:\\Users\\batuh\\Desktop\\Vize2Labirent\\Lab2Yol0.txt' şeklinde giriniz ==> ");
                    string dosya_uzantısı = Console.ReadLine();
                    string dosya_yolu = "" + dosya_uzantısı;
                    ReadingText readingText = new ReadingText();
                    readingText.Read(dosya_yolu);
                    // Okuma işlem sonu
                    Mine mine = new Mine();
                    mine.SetMines(readingText.elements);
                    // Mayın yerleştirme işlem sonu
                    Tracker tracker = new Tracker();
                    tracker.getIndexOfMines(mine.logRowMine, mine.logColumnMine);
                    char[,] fakeElements = arrayCopy(readingText.elements);
                    tracker.Solution(fakeElements);
                    // Labiren çözme işlemi sonu
                    Console.Write("X tuşu : Yol koordinatları\nB tuşu : Bomba koordinatları\nL tuşu : Labirentin orjinal hali\nE tuşu : Menü ==> ");
                    char press = Convert.ToChar(Console.ReadLine().ToUpper());
                    while (press != 'E')
                    {
                        if (press == 'X')
                        {
                            if (tracker.kl == 0)
                            {
                                Console.WriteLine("Labirentin çıkışı yoktur...");
                            }
                            else
                            {
                                DisplayMaze(fakeElements);
                            }
                        }
                        else if (press == 'B')
                        {
                            char[,] fakeElementsForMine = arrayCopy(readingText.elements);
                            mine.displayLocationOfMines(fakeElementsForMine);
                            DisplayMaze(fakeElementsForMine);
                        }
                        else if (press == 'L')
                        {
                            DisplayMaze(readingText.elements);
                        }
                        press = Convert.ToChar(Console.ReadLine().ToUpper());
                    }
                }
                tus = Convert.ToInt32(Console.ReadLine());
            }
        }
        public char[,] arrayCopy(char[,] input)
        {
            char[,] copy = new char[input.GetLength(0), input.GetLength(1)];
            for (int x = 0; x < input.GetLength(0); x++)
            {
                for (int y = 0; y < input.GetLength(1); y++)
                {
                    copy[x, y] = input[x, y];
                }
            }
            return copy;
        }
        public void DisplayMaze(char[,] elements)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.Write(elements[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
