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
        //Метод для заполнения массива целыми числами из файла input
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
                    try
                    {
                        array = new int[n];
                        string[] _data = stream.ReadToEnd().Split(' ');
                        for (int i = 0; i < n; i++)
                        {
                            if (!int.TryParse(_data[i], out array[i]))
                            {
                                throw new Exception("Ошибка при считывании файла");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e.Message}\nЗавершение работы приложения...");
                    }
                }

            }
        }
        //Метод для заполнения массива целыми числами при помощи клавиатуры
        private void ConsoleReader()
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
        //Метод для получения массива другими пользователями
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
