using System;
using System.IO;
using System.Linq;

namespace Epam_Task1
{
    internal class ArrayLoader
    {
        public int[] array { get; private set; }

        private void ReadFromFile()
        {
            using (StreamReader stream = new StreamReader("input.txt"))
            {
                int n = 0;
                try
                {
                    Console.WriteLine("Введите размерность масcива");

                    if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
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
                        if (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
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
                    try
                    {
                        int[] tmparr = new int[n];
                        string[] _data = stream.ReadToEnd().Split(' ');
                        int count_of_items_in_file = _data.Count();
                        if (n > count_of_items_in_file)
                        {
                            Console.WriteLine("Введенная размерность больше чем колличество элементов в файле\n" +
                                $"Создан массив размерности {count_of_items_in_file}");
                            n = count_of_items_in_file;
                            Array.Resize(ref tmparr, n);
                        }
                        for (int i = 0; i < n; i++)
                        {
                            if (!int.TryParse(_data[i], out tmparr[i]))
                            {
                                throw new Exception("Ошибка при считывании файла");
                            }
                        }
                        array = tmparr;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e.Message}\nЗавершение работы приложения...");
                    }
                }
            }
        }

        private void ConsoleReader()
        {
            int n = 0;
            try
            {
                Console.WriteLine("Введите размерность масиива");

                if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
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
                    if (!int.TryParse(Console.ReadLine(), out number) || n <= 0)
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
                Console.WriteLine("Введите массив с клавиатуры");
                array = new int[n];
                int errorposition = 0;
                try
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("array[" + i + "]= ");
                        if (!int.TryParse(Console.ReadLine(), out array[i]))
                        {
                            array[i] = 0;
                            errorposition = i;
                            throw new Exception($"Введено некорректное значение в позиции ->{i}");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}\nВведите значения массива начиная с позиции ->{errorposition}");
                    for (int i = errorposition; i < n; i++)
                    {
                        int.TryParse(Console.ReadLine(), out array[i]);
                    }
                }
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