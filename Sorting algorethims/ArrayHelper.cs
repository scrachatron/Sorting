using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_algorethims
{
    static class ArrayHelper
    {
        public static void Fill(this int[] data,int way)
        {
            switch (way)
            {
                case 0:
                    for (int i = 0; i < data.Length; i++)
                        data[i] = i;
                    data.Shuffle();
                    break;

                case 1:
                    for (int i = 0; i < data.Length; i++)
                        data[i] = i;
                    data[0] = data.Length - 1;
                    data[data.Length - 1] = 0;
                    break;
                case 2:
                    data.Fill(1);
                    Array.Reverse(data);
                    break;
                case 3:
                    //Console.WriteLine("No value given for number of partitions 4 shall be assumed");
                    data.Fill(3, 4);
                    break;
            }
        } 
        public static void Fill(this int[] data, int way,int partitions)
        {
            switch(way)
            {
                case 3:
                    int temp = data.Length / partitions;
                    int number = 1;
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (number * temp < i)
                            number++;
                        data[i] = number;
                    }
                    Array.Reverse(data);
                    break;
            }
        }
        public static void Shuffle(this int[] data)
        {
            Random RNG = new Random(DateTime.Now.TimeOfDay.Milliseconds);
            for (int i = 0; i < data.Length; i++)
            {
                int random1 = i;
                int random2 = RNG.Next(0, data.Length);
                int temp = data[random1];

                data[random1] = data[random2];
                data[random2] = temp;
            }
        }
        public static void Shuffle(this int[] data,int seed)
        {
            Random RNG = new Random(seed);
            for (int i = 0; i < data.Length; i++)
            {
                int random1 = i;
                int random2 = RNG.Next(0, data.Length);
                int temp = data[random1];

                data[random1] = data[random2];
                data[random2] = temp;
            }

        }
        public static void Display(this int[] array)
        {
            int characters = array.Length.ToString().Remove(array.Length.ToString().Length -1).Length;
            int tmp = (int)Math.Round(Math.Pow((double)array.Length, (double)1 / (double)characters));

            for (int i = 0; i < array.Length; i++)
                Console.WriteLine("Data[" + i + "]=" + array[i]);
        }
        public static void DisplayGraphic(this int[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Data[" + i + "]=");
                if (i < 10 )
                    Console.Write(" ");

                for (int j = 0; j < array[i]; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(array[i] + "\n");
            } 
        }
        public static void Swap(this int[] array, int position1, int position2)
        {
            int temp = array[position1];

            array[position1] = array[position2];
            array[position2] = temp;
        }
    }
}
