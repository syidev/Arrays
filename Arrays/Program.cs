using System;

namespace Program
{
    public class GenerateTwoDimArray
    {
        public int [,] GenArray(int a, int b)
        {
            Random ran = new Random();
            int[,] array = new int[a, b];
            for (int t = 0; t < a; t++)
            {
                for (int i = 0; i < b; i++)
                {
                    array[t, i] = ran.Next(10, 99);
                    Console.Write("\t{0}", array[t, i]);
                }
                Console.WriteLine("\n");
            }
            return array;
        }
    }

    public class TwoDimArrayToOneDimArray
    {
        public int [] ConvertArray( int [,] array, int a, int b)
        {
            int[] oneDimArray = new int[a * b];
            int x = 0;
            for (int t = 0; t < a; t++)
            {
                for (int i = 0; i < b; i++)
                {
                    oneDimArray[x] = array[t, i];
                    x++;
                }
            }
            return oneDimArray;
        }
    }

    public class SortArray
    {
        public int [] Sorting( int[] array, int first, int last)
        {
            int p = array[(last - first) / 2 + first];
            int temp;
            int i = first, j = last;
            while (i <= j)
            {
                while (array[i] < p && i <= last) ++i;
                while (array[j] > p && j >= first) --j;
                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    ++i; --j;
                }
            }
            if (j > first) Sorting(array, first, j);
            if (i < last) Sorting(array, i, last);
            return array;
        }
    }

    public class OneDimArrayToTwoDimArray
    {
        public void ConvertArray( int [] array, int a, int b)
        {
            int[,] twoDimArray = new int[a, b];
            int y = 0;
            for (int t = 0; t < a; t++)
            {
                for (int i = 0; i < b; i++)
                {
                    twoDimArray[t, i] = array[y];
                    Console.Write("\t{0}", twoDimArray[t, i]);
                    y++;
                }
                Console.WriteLine("\n");
            }
        }
    }

    public class OutputInConsole
    {
        public static void Main()
        {
            Console.Write("Введите количество строк массива: ");
            int childArrayLength = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество столбцов массива: ");
            int mainArrayLength = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nВаш массив(заполнен случайными числами от 10 до 99):\n");
            GenerateTwoDimArray generateTwoDimArray = new GenerateTwoDimArray();
            int [,] twoDimArray = generateTwoDimArray.GenArray(childArrayLength, mainArrayLength);
            TwoDimArrayToOneDimArray twoDimArrayToOneDimArray = new TwoDimArrayToOneDimArray();
            int[] oneDimArray = twoDimArrayToOneDimArray.ConvertArray(twoDimArray, childArrayLength, mainArrayLength);
            Console.Write("Чтобы отсортировать массив в порядке возрастания чисел нажмите ENTER");
            Console.ReadKey();
            SortArray sortArray = new SortArray();
            int [] sortOneDimArray = sortArray.Sorting(oneDimArray, 0, oneDimArray.Length - 1);
            Console.WriteLine("Отсортированный двумерный массив в порядке возрастания:             \n");
            OneDimArrayToTwoDimArray oneDimArrayToTwoDimArray = new OneDimArrayToTwoDimArray();
            oneDimArrayToTwoDimArray.ConvertArray(sortOneDimArray, childArrayLength, mainArrayLength);
            Console.ReadKey();
        }
    }
}