using System;
using System.Linq;

namespace dz4kozubenko
{
     class Program
    {
        static int A = -2;
        static int B = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите часть задания (1/2):");
            int F = int.Parse(Console.ReadLine());
            
            if (F == 1)
            {
                double result = 0; 
                Random r = new Random();
                Console.Write("Размер массива N = ");
                int n = int.Parse(Console.ReadLine());
                double[] array = new double[n];
                int min = 0;

                Console.Write($"Массив[{n}] = ");

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = r.Next(A, B) + r.NextDouble();
                    Console.Write("{0,7:F2}", array[i]);
                    if (array[min] > array[i])
                        min = i;
                }

                Console.WriteLine();
                Console.Write("Минимальный элемент={0:F2}", array[min]);

                int first = -1, last = -1;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] > 0)
                    {
                        first = i;
                        break;
                    }
                }
                if (first == -1)
                {
                    Console.Write("\nНет положительных элементов");
                }
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] > 0)
                    {
                        last = i;
                        break;
                    }
                }
                if (first == last)
                {
                    Console.Write("\nНедостаточно положительных элементов");
                }
                for (int i = first + 1; i < last; i++)
                {
                    result += array[i];
                }
                Console.Write("\nСумма элементов, между первым и последним: ");
                Console.Write("{0:F2}", result);
                Console.WriteLine();


                int a = -1;
                int b = 1;
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if ((array[j] > a) && (array[j] < b))
                    {
                        count++;
                    }
                }
                double[] array1 = new double[count];
                int p = 0;
                for (int j = 0; j < n; j++)
                {
                    if ((array[j] > a) && (array[j] < b))
                    {
                        array1[p++] = array[j];
                    }
                }
                double[] array2 = new double[n - count];
                int l = 0;
                for (int k = 0; k < n; k++)
                {
                    if ((array[k] > A) && (array[k] <= a))
                    {
                        array2[l++] = array[k];
                    }
                    else if ((array[k] >= b) && (array[k] < B))
                    {
                        array2[l++] = array[k];
                    }
                }
                Console.Write($"Массив[{n}] = ");
                double[] summ = new double[array1.Length + array2.Length];
                array1.CopyTo(summ, 0);
                array2.CopyTo(summ, array1.Length);
                Console.Write("{0:00}", String.Join("  ", summ.Select(x => x.ToString("F2"))));
                Console.ReadLine();
            }

            if (F == 2)
            {
                int N;
                int M;
                do
                {
                    Console.Write("Введите количeство строк: ");
                    N = int.Parse(Console.ReadLine());
                    Console.Write("Введите количество столбцов: ");
                    M = int.Parse(Console.ReadLine());
                    if (N <= 0)
                    {
                        Console.WriteLine("Неверное значение строк :c");
                    }
                    if (M <= 0)
                    {
                        Console.WriteLine("Неверное значение столбцов :c");
                    }
                    if (N > 0 & M > 0)
                    {
                        break;
                    }
                } while (true);

                Random r = new Random();
                int[,] Arr = new int[N, M];
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        Arr[i, j] = r.Next(A, B);
                        Console.Write("{0,7:F0}", Arr[i, j]);
                    }
                    Console.WriteLine();
                }
                SummMinus(Arr);
                Console.WriteLine("--------------------------------");

                SearchSedl(Arr);
            }
        }

        static void SummMinus(int[,] Mas)
        {
            int[] sum = new int[Mas.GetLength(0)];
            bool withmin = false;
            for (int i = 0; i < Mas.GetLength(0); ++i)
            {
                for (int j = 0; j < Mas.GetLength(1); ++j)
                {
                    sum[i] += Mas[i, j];
                    if (Mas[i, j] < 0)
                    {
                        withmin = true;
                    }
                }
                if (withmin) 
                { 
                    Console.WriteLine("В строке № {0} сумма всех элементов= {1}", i + 1, sum[i]); 
                    withmin = false; 
                }
            }
        }


        static void SearchSedl(int[,] Mas)
        {
            int minInd;
            int maxInd;

            for (int i = 0; i < Mas.GetLength(0); i++)
            {
                minInd = 0;
                maxInd = 0;
                for (int j = 0; j < Mas.GetLength(1); j++)
                {
                    if (Mas[i, j] < Mas[i, minInd]) minInd = j;
                }

                for (int k = 0; k < Mas.GetLength(0); k++)
                {

                    if (Mas[k, minInd] > Mas[maxInd, minInd]) maxInd = k;
                }

                if (maxInd == i) Console.WriteLine("Седловая точка в элементе {0} : {1}", minInd + 1, maxInd + 1);
                else 
                {
                    Console.WriteLine("В строке № {0} нет седловых точек", i + 1);
                }
            }
        }
    }
}