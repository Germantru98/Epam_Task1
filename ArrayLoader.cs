using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task1
{
    class ArrayLoader
    {
        public int[] array { get; private set; }
        private void ReadFromFile()
        {
            using (StreamReader stream = new StreamReader("input.txt"))
            {
                int n = 0;
                try
                {
                    Console.WriteLine("Введите размерность масиива");
                    
                    if (int.TryParse(Console.ReadLine(), out n))
                    {
                        
                    }
                    else
                    {
                        throw new Exception("Размерность массива введена неверно");
                    }
                }
                catch (Exception e)
                {
                    int attempt = 3;
                    Console.WriteLine($"{e.Message}\nВведите корректное значение размерности массива");
                    while (attempt > 0)
                    {
                        int number;
                        if (!int.TryParse(Console.ReadLine(), out number))
                        {
                            attempt--;
                            Console.WriteLine($"Значение введено неверно\nПопыток осталось:{attempt}");
                        }
                        else
                        {
                            n = number;
                            break;
                        }

                        if (attempt == 0)
                        {
                            Console.WriteLine("Завершение работы с приложением...");
                            break;
                        }
                    }

                }
                finally
                {
                    array = new int[n];
                    string[] _data = stream.ReadToEnd().Split(' ');
                    for (int i = 0; i < n; i++)
                    {
                        int.TryParse(_data[i], out array[i]);
                    }
                }

            }
        }


        private void ConsoleReader()
        {
            Console.WriteLine("Введите размерность масиива");
            int n;
            int.TryParse(Console.ReadLine(), out n);
            Console.WriteLine("Введите массив с клавиатуры");
            array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("array[" + i + "]= ");
                array[i] = int.Parse(Console.ReadLine());
            }
        }
        public int[] GetArray(int readertype)
        {
            if (readertype == 1)
            {
                ReadFromFile();
                return array;
            }
            else
            {
                ConsoleReader();
                return array;
            }
        }
    }
}
