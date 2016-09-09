using System;
using System.Threading; 

namespace ConsoleInputOutput
{
    static class Input
    {
        static int number;

        public static int Number()
        {
            while (true)
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Нужно было ввести число, а не строку!");
                    continue;
                }
                catch (System.OverflowException)
                {
                    Console.WriteLine("Слишком больше число!");
                    continue;
                }
                break;
            }
            return number;
        }
    }
   
    class Tree
    {
        int row;
        int height;
        public Tree(int r, int h) { row = r; height = h;}
        public void Print(char symbol)
        {
            Console.Clear();
            int middle = (height * 2 - 1)/2 + row;
            int startX;
            int startY = Console.CursorTop;
            int length;

            
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < row; i++)
            {
                length = i * 2 + 1;
                startX = middle - i;
                for (int j= 0;  j < height; j++)
                {
                    Console.SetCursorPosition(startX,startY);
                    for (int z = 0; z < length; z++)
                    {
                        Console.Write(symbol);                        
                    }
                    length += 2;
                    startX--;
                    startY++;
                }
            }
            if (middle < 6)
            {
                startX = middle;
                length = 1;
            }
            else
            {
                startX = middle-1;
                length = 3;
            }       
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(startX, startY);
                for (int z = 0; z < length; z++)
                {
                    Console.Write('#');
                }
                startY++;
            }
            Console.WriteLine("");
            int semafore = 0;
            Console.CursorVisible = false;

            while (true)
            { 
                switch (semafore)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        semafore = 1;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        semafore = 2;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        semafore = 0;
                        break; 
                }
                Console.SetCursorPosition(middle, 0);
                Console.Write("@");
                Thread.Sleep(150);                
            }
        }

    }  


    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Happy New Year 2014!!!";
            int row, height; 
            do
            {
                Console.Write("Для того что бы нарисовать ёлочку укажите:\nколичество ярусов: "); 
                row = Input.Number();
                Console.Write("высоту яруса: "); 
                height = Input.Number();
                if (row <= 0)
                {
                    Console.WriteLine("Количество рядов не может быть меньше единицы");
                  
                }
                if (height <= 0)
                {
                    Console.WriteLine("Высота не может быть меньше единицы");
                    
                }
                Thread.Sleep(1000);
                Console.Clear();
   
            } while (row < 1 || height < 1);    

            Console.BufferHeight = Console.LargestWindowHeight;
            Console.BufferWidth = Console.BufferWidth;

            bool flag_row = false, flag_height = false;

            while ( row * height + 5 > Console.LargestWindowHeight || (height * 2 - 1) + row * 2 + 1 > Console.LargestWindowWidth)
            {
                if (row * height + 5 > Console.LargestWindowHeight)
                {
                    if (row > 1)
                     row--;
                    flag_row = true;
                }

                if ((height * 2 - 1) + row * 2 + 1 > Console.LargestWindowWidth)
                {
                    if (height > 1)
                        height--;
                    flag_height = true;
                }
            }
             
            if (flag_row)
            {
                Console.WriteLine("Высота ёлочки будет превышать размер экрана,\nпоэтому мы уменьшаем количество ярусов до {0}", row);
                Thread.Sleep(2000);
            }
            if (flag_height)
            {
                Console.WriteLine("Заданая ширина ёлочки будет превышать размер экрана,\nпоэтому мы уменьшаем высоту яруса до {0}", height);
                Thread.Sleep(2000);
            }

            Console.WindowHeight = row * height + 5;
            Console.WindowWidth = (height * 2 - 1) + row * 2 + 1;

            Tree Xmas = new Tree(row, height);
            Xmas.Print('»');
        }
    }
}
