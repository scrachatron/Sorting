using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sorting_algorethims
{
    class Program
    {
        const int DataRandomness = 1;

        const int TimesToSort = 2048;
        const bool SaveFile = false;
        const int STARTARRAYSIZE = 128;
        const int MAXPOWER = 8;
        static string SAVEPATH = @"C:\Users\User\Desktop\1303821\";
        const bool Partial = true;

        static void Main(string[] args)
        {
            #region SavingCode
            if (SaveFile)
            {
                SAVEPATH.Replace(":", ";");
                SAVEPATH.Replace("/", ".");

                string[] paths;
                paths = new string[4]
                {
                    SAVEPATH + "RUD",SAVEPATH + "AOUD",SAVEPATH + "WCUD",SAVEPATH + "PD"
                };
                System.IO.Directory.CreateDirectory(SAVEPATH);
                for (int i = 0; i < paths.Length; i++)
                    System.IO.Directory.CreateDirectory(paths[i]);

                List<string> HelperString = new List<string>();
                HelperString.Add("This is the readme File for 1303821's coursework");
                HelperString.Add("");
                HelperString.Add("RUD : Random Unique Data");
                HelperString.Add("AOUD : Almost Ordered Unique Data");
                HelperString.Add("WCUD : Worst Case Unique Data");
                HelperString.Add("PD : Partitioned Data");

                System.IO.File.WriteAllLines(SAVEPATH + "ReadMe.txt", HelperString.ToArray());

            }
            #endregion

            Stopwatch sw = new Stopwatch();
            Random RNG = new Random();

            int ArraySize = STARTARRAYSIZE;

            
                Console.WriteLine("Testing array sizes of: ");

            if (Partial)
            {
                for (int i = 0; i < MAXPOWER; i++)
                {
                    ArraySize *= 2;
                    Console.Write(ArraySize + ",");
                }
                if (ArraySize >= 10000)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Warning you are planning to run this programme on an array size over 10000 this");
                    Console.WriteLine("programme will run insersion sort with worst case, random and partitioned data ");
                    Console.WriteLine(TimesToSort + " times which may Take up to an hour or more to finish");
                }


                ArraySize = STARTARRAYSIZE;

                Console.WriteLine("");


                for (int i = 0; i < MAXPOWER; i++)
                {
                    ArraySize *= 2;
                    Console.WriteLine(ArraySize + " items:");
                    int[] m_unsortedData = new int[ArraySize];

                    //This fills the array in the order seected
                    m_unsortedData.Fill(1);
                    SortUnit(sw, m_unsortedData, TimesToSort, 1);
                    m_unsortedData.Fill(3);
                    SortUnit(sw, m_unsortedData, TimesToSort, 3);
                    m_unsortedData.Fill(0);
                    SortUnit(sw, m_unsortedData, TimesToSort, 0);
                    m_unsortedData.Fill(2);
                    SortUnit(sw, m_unsortedData, TimesToSort, 2);
                }
            }
            else
            {
                for (int i = 0; i < MAXPOWER; i++)
                {
                    ArraySize *= 2;
                    Console.WriteLine(ArraySize + " items:");
                    int[] m_unsortedData = new int[ArraySize];
                    SortAll(sw, m_unsortedData, TimesToSort);
                }
            }


            Console.WriteLine("\n-----------");
            Console.WriteLine("PROGRAME FINISHED");
            
            Console.Read();

            
        }

        public static void drawTextProgressBar(int progress, int total, double currenttime)
        {
            //draw empty progress bar
            Console.CursorLeft = 0;
            Console.Write("["); //start
            Console.CursorLeft = 32;
            Console.Write("]"); //end
            Console.CursorLeft = 1;
            float onechunk = 30.0f / total;

            //draw filled part
            int position = 1;
            for (int i = 0; i <= onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = position; i <= 31; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorLeft = 35;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(progress.ToString() + " of " + total.ToString() + "    "); //blanks at the end remove any excess
            Console.Write(currenttime + "/ms");
        }

        public static void drawTextProgressBar(int progress, int total)
        {
            //draw empty progress bar
            Console.CursorLeft = 0;
            Console.Write("["); //start
            Console.CursorLeft = 32;
            Console.Write("]"); //end
            Console.CursorLeft = 1;
            float onechunk = 30.0f / total;

            //draw filled part
            int position = 1;
            for (int i = 0; i <= onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = position; i <= 31; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorLeft = 35;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(progress.ToString() + " of " + total.ToString() + "    "); //blanks at the end remove any excess
            //Console.Write(currenttime + "/ms");
        }

        private static void SortAll(Stopwatch sw, int[] m_unsortedData, double t)
        {
            double Times = t;
            int[] m_safecopy = new int[m_unsortedData.Length];
            List<string> m_lines = new List<string>();
            int Type = DataRandomness;
            //m_unsortedData.CopyTo(m_safecopy, 0);

            //for (int i = 0; i < m_unsortedData.Length; i++)
            //    m_safecopy[i] = m_unsortedData[i];



            m_lines.Add("Running algorethims on an array of size: " + m_unsortedData.Length);
            m_lines.Add("Running average over " + Times + " itteration(s)");
            m_lines.Add("Running with datatype randomness of " + Type + ": ");

            //Console.Write("Running with datatype randomness of: " + Type + ": ");

            if (Type == 0)
                m_lines[m_lines.Count - 1] += "Random unique data";
            else if (Type == 1)
                m_lines[m_lines.Count - 1] += "Ordered unique data";
            else if (Type == 2)
                m_lines[m_lines.Count - 1] += "Worst case unique data";
            else if (Type == 3)
                m_lines[m_lines.Count - 1] += "Ordered partitioned data";


            m_lines.Add("");
            m_lines.Add("");

            m_unsortedData.CopyTo(m_safecopy, 0);

            Console.WriteLine("Bubble Sort:");

            sw.Reset();
            sw.Start();
            for (int i = 0; i < Times; i++)
            {
                drawTextProgressBar(i+1, (int)Times);
                Sorts.SortArray(m_unsortedData, Sorts.SortType.bubble);
                sw.Stop();
                m_safecopy.CopyTo(m_unsortedData, 0);
                sw.Start();
            }
            sw.Stop();

            m_lines.Add("-----------");
            m_lines.Add("BubbleSort: " + GC.GetTotalMemory(true) / 1024 + "/KB");
            m_lines.Add(((double)sw.Elapsed.Ticks / Times) + "/Ticks");
            m_lines.Add((double)(sw.Elapsed.Milliseconds / Times) + "/ms");



            Console.WriteLine("\nCocktailSort:");

            sw.Reset();
            sw.Start();
            for (int i = 0; i < Times; i++)
            {
                drawTextProgressBar(i+1, (int)Times);
                Sorts.SortArray(m_unsortedData, Sorts.SortType.cocktail);
                sw.Stop();
                m_safecopy.CopyTo(m_unsortedData, 0);
                sw.Start();
            }
            sw.Stop();

            m_lines.Add("-----------");
            m_lines.Add("CocktailSort: " + GC.GetTotalMemory(true) / 1024 + "/KB");
            m_lines.Add(((double)sw.Elapsed.Ticks / Times) + "/Ticks");
            m_lines.Add((double)(sw.Elapsed.Milliseconds / Times) + "/ms");

            Console.WriteLine("\nCountingSort:");
            sw.Reset();
            sw.Start();
            for (int i = 0; i < Times; i++)
            {
                drawTextProgressBar(i+1, (int)Times);
                Sorts.SortArray(m_unsortedData, Sorts.SortType.counting);
                sw.Stop();
                m_safecopy.CopyTo(m_unsortedData, 0);
                sw.Start();
            }
            sw.Stop();

            m_lines.Add("-----------");
            m_lines.Add("CountingSort: " + GC.GetTotalMemory(true) / 1024 + "/KB");
            m_lines.Add(((double)sw.Elapsed.Ticks / Times) + "/Ticks");
            m_lines.Add((double)(sw.Elapsed.Milliseconds / Times) + "/ms");

            Console.WriteLine("\nDoubleSelectionSort:");
            sw.Reset();
            sw.Start();
            for (int i = 0; i < Times; i++)
            {
                drawTextProgressBar(i+1, (int)Times);
                Sorts.SortArray(m_unsortedData, Sorts.SortType.doubleselection);
                sw.Stop();
                m_safecopy.CopyTo(m_unsortedData, 0);
                sw.Start();
            }
            sw.Stop();

            m_lines.Add("-----------");
            m_lines.Add("DoubleSelectionSort: " + GC.GetTotalMemory(true) / 1024 + "/KB");
            m_lines.Add(((double)sw.Elapsed.Ticks / Times) + "/Ticks");
            m_lines.Add((double)(sw.Elapsed.Milliseconds / Times) + "/ms");


            Console.WriteLine("\nInsersionSort:");
            sw.Reset();
            sw.Start();
            for (int i = 0; i < Times; i++)
            {
                drawTextProgressBar(i+1, (int)Times);
                Sorts.SortArray(m_unsortedData, Sorts.SortType.insersion);
                sw.Stop();
                m_safecopy.CopyTo(m_unsortedData, 0);
                sw.Start();
            }
            sw.Stop();

            m_lines.Add("-----------");
            m_lines.Add("InsersionSort: " + GC.GetTotalMemory(true) / 1024 + "/KB");
            m_lines.Add(((double)sw.Elapsed.Ticks / Times) + "/Ticks");
            m_lines.Add((double)(sw.Elapsed.Milliseconds / Times) + "/ms");

            //m_unsortedData.DisplayGraphic();
            Console.WriteLine("\nQuickSort:");
            sw.Reset();
            sw.Start();
            for (int i = 0; i < Times; i++)
            {
                drawTextProgressBar(i+1, (int)Times);
                Sorts.SortArray(m_unsortedData, Sorts.SortType.quick);
                sw.Stop();
                m_safecopy.CopyTo(m_unsortedData, 0);
                sw.Start();
            }
            sw.Stop();

            m_lines.Add("-----------");
            m_lines.Add("QuickSort: " + GC.GetTotalMemory(true) / 1024 + "/KB");
            m_lines.Add(((double)sw.Elapsed.Ticks / Times) + "/Ticks");
            m_lines.Add((double)(sw.Elapsed.Milliseconds / Times) + "/ms");

            Console.WriteLine("\nSelectionSort:");
            sw.Reset();
            sw.Start();
            for (int i = 0; i < Times; i++)
            {
                drawTextProgressBar(i+1, (int)Times);
                Sorts.SortArray(m_unsortedData, Sorts.SortType.selection);
                sw.Stop();
                m_safecopy.CopyTo(m_unsortedData, 0);
                sw.Start();
            }
            sw.Stop();

            m_lines.Add("-----------");
            m_lines.Add("SelectionSort: " + GC.GetTotalMemory(true) / 1024 + "/KB");
            m_lines.Add(((double)sw.Elapsed.Ticks / Times) + "/Ticks");
            m_lines.Add((double)(sw.Elapsed.Milliseconds / Times) + "/ms");

            Console.WriteLine("\nMergeSort:");
            sw.Reset();
            sw.Start();
            for (int i = 0; i < Times; i++)
            {
                drawTextProgressBar(i+1, (int)Times);
                Sorts.SortArray(m_unsortedData, Sorts.SortType.merge);
                sw.Stop();
                m_safecopy.CopyTo(m_unsortedData, 0);
                sw.Start();
            }
            sw.Stop();

            m_lines.Add("-----------");
            m_lines.Add("MergeSort: " + GC.GetTotalMemory(true) / 1024 + "/KB");
            m_lines.Add(((double)sw.Elapsed.Ticks / Times) + "/Ticks");
            m_lines.Add((double)(sw.Elapsed.Milliseconds / Times) + "/ms");

            if (m_unsortedData.Length > 1000)
            {
                m_lines.Add("-----------");
                m_lines.Add("GravitySort: Not worth running on arrays over 1000 in length");
                m_lines.Add("NA/Ticks");
                m_lines.Add("NA/ms");
            }
            else
            {
                Console.WriteLine("\nGravitySort:");
                sw.Reset();
                sw.Start();
                for (int i = 0; i < Times; i++)
                {
                    drawTextProgressBar(i+1, (int)Times);
                    Sorts.SortArray(m_unsortedData, Sorts.SortType.gravity);
                    sw.Stop();
                    m_safecopy.CopyTo(m_unsortedData, 0);
                    sw.Start();
                }
                sw.Stop();



                m_lines.Add("-----------");
                m_lines.Add("GravitySort: " + GC.GetTotalMemory(true) / 1024 + "/KB");
                m_lines.Add(((double)sw.Elapsed.Ticks / Times) + "/Ticks");
                m_lines.Add((double)(sw.Elapsed.Milliseconds / Times) + "/ms");
            }

            Console.WriteLine("");
            Console.WriteLine("");

            for (int i = 0; i < m_lines.Count; i++)
            {
                Console.WriteLine(m_lines[i]);
            }
            if (SaveFile)
            {
                string[] temp = m_lines.ToArray();
                string filename = DateTime.Today.ToShortDateString() + "[" + DateTime.Now.ToLongTimeString() + "].txt";
                filename = filename.Replace(":", ";");
                filename = filename.Replace("/", ".");
                string path = @"C:\Users\User\Documents\Visual Studio 2015\Projects\Sorting algorethims\Sorting algorethims\results\" + filename;
                System.IO.File.WriteAllLines(path, temp);
            }
        }


        private static void SortUnit(Stopwatch sw, int[] m_unsortedData, double t)
        {
            double Times = t;
            int[] m_safecopy = new int[m_unsortedData.Length];
            List<string> m_lines = new List<string>();
            int Type = DataRandomness;
            //m_unsortedData.CopyTo(m_safecopy, 0);

            //for (int i = 0; i < m_unsortedData.Length; i++)
            //    m_safecopy[i] = m_unsortedData[i];



            m_lines.Add("Running algorethims on an array of size: " + m_unsortedData.Length);
            m_lines.Add("Running average over " + Times + " itteration(s)");
            m_lines.Add("Running with datatype randomness of " + Type + ": ");

            //Console.Write("Running with datatype randomness of: " + Type + ": ");

            if (Type == 0)
                m_lines[m_lines.Count - 1] += "Random unique data";
            else if (Type == 1)
                m_lines[m_lines.Count - 1] += "Almost ordered unique data";
            else if (Type == 2)
                m_lines[m_lines.Count - 1] += "Worst case unique data";
            else if (Type == 3)
                m_lines[m_lines.Count - 1] += "partitioned data";


            m_lines.Add("");
            m_lines.Add("");

            m_unsortedData.CopyTo(m_safecopy, 0);

            Console.WriteLine("\nCountingSort:");
            sw.Reset();
            sw.Start();
            for (int i = 0; i < Times; i++)
            {
                drawTextProgressBar(i + 1, (int)Times,(double)sw.ElapsedMilliseconds);
                Sorts.SortArray(m_unsortedData, Sorts.SortType.counting);
                sw.Stop();
                m_safecopy.CopyTo(m_unsortedData, 0);
                sw.Start();
            }
            sw.Stop();

            m_lines.Add("-----------");
            m_lines.Add("CountingSort: " + GC.GetTotalMemory(true) / 1024 + "/KB");
            m_lines.Add(((double)sw.Elapsed.Ticks / Times) + "/Ticks");
            m_lines.Add((double)(sw.Elapsed.TotalMilliseconds / Times) + "/ms");


            Console.WriteLine("\nQuickSort:");
            sw.Reset();
            sw.Start();
            for (int i = 0; i < Times; i++)
            {
                drawTextProgressBar(i + 1, (int)Times, (double)sw.ElapsedMilliseconds);
                Sorts.SortArray(m_unsortedData, Sorts.SortType.quick);
                sw.Stop();
                m_safecopy.CopyTo(m_unsortedData, 0);
                sw.Start();
            }
            sw.Stop();

            m_lines.Add("-----------");
            m_lines.Add("QuickSort: " + GC.GetTotalMemory(true) / 1024 + "/KB");
            m_lines.Add(((double)sw.Elapsed.Ticks / Times) + "/Ticks");
            m_lines.Add((double)(sw.Elapsed.TotalMilliseconds / Times) + "/ms");

            
            Console.WriteLine("");
            Console.WriteLine("");

            for (int i = 0; i < m_lines.Count; i++)
            {
                Console.WriteLine(m_lines[i]);
            }
            if (SaveFile)
            {
                string[] temp = m_lines.ToArray();
                string filename = DateTime.Today.ToShortDateString() + "[" + DateTime.Now.ToLongTimeString() + "].txt";
                filename = filename.Replace(":", ";");
                filename = filename.Replace("/", ".");
                string path = @"C:\Users\User\Documents\Visual Studio 2015\Projects\Sorting algorethims\Sorting algorethims\results\" + filename;
                System.IO.File.WriteAllLines(path, temp);
            }
        }

        private static void SortUnit(Stopwatch sw, int[] m_unsortedData, double t,int type)
        {
            double Times = t;
            int[] m_safecopy = new int[m_unsortedData.Length];
            List<string> m_lines = new List<string>();
            int Type = type;
            //m_unsortedData.CopyTo(m_safecopy, 0);

            //for (int i = 0; i < m_unsortedData.Length; i++)
            //    m_safecopy[i] = m_unsortedData[i];



            m_lines.Add("Running algorethims on an array of size: " + m_unsortedData.Length);
            m_lines.Add("Running average over " + Times + " itteration(s)");
            m_lines.Add("Running with datatype randomness of " + Type + ": ");

            //Console.Write("Running with datatype randomness of: " + Type + ": ");

            if (Type == 0)
                m_lines[m_lines.Count - 1] += "Random unique data";
            else if (Type == 1)
                m_lines[m_lines.Count - 1] += "Almost ordered unique data";
            else if (Type == 2)
                m_lines[m_lines.Count - 1] += "Worst case unique data";
            else if (Type == 3)
                m_lines[m_lines.Count - 1] += "partitioned data";


            m_lines.Add("");
            m_lines.Add("");

            m_unsortedData.CopyTo(m_safecopy, 0);

            Console.WriteLine("\nCountingSort:");
            sw.Reset();
            sw.Start();
            for (int i = 0; i < Times; i++)
            {
                drawTextProgressBar(i + 1, (int)Times, (double)sw.ElapsedMilliseconds);
                Sorts.SortArray(m_unsortedData, Sorts.SortType.counting);
                sw.Stop();
                m_safecopy.CopyTo(m_unsortedData, 0);
                sw.Start();
            }
            sw.Stop();

            m_lines.Add("-----------");
            m_lines.Add("CountingSort: " + GC.GetTotalMemory(true) / 1024 + "/KB");
            m_lines.Add(((double)sw.Elapsed.Ticks / Times) + "/Ticks");
            m_lines.Add((double)(sw.Elapsed.TotalMilliseconds / Times) + "/ms");


            Console.WriteLine("\nInsersionSort:");
            sw.Reset();
            sw.Start();
            for (int i = 0; i < Times; i++)
            {
                drawTextProgressBar(i + 1, (int)Times, (double)sw.ElapsedMilliseconds);
                Sorts.SortArray(m_unsortedData, Sorts.SortType.insersion);
                sw.Stop();
                m_safecopy.CopyTo(m_unsortedData, 0);
                sw.Start();
            }
            sw.Stop();

            m_lines.Add("-----------");
            m_lines.Add("InsersionSort: " + GC.GetTotalMemory(true) / 1024 + "/KB");
            m_lines.Add(((double)sw.Elapsed.Ticks / Times) + "/Ticks");
            m_lines.Add((double)(sw.Elapsed.TotalMilliseconds / Times) + "/ms");


            Console.WriteLine("");
            Console.WriteLine("");

            for (int i = 0; i < m_lines.Count; i++)
            {
                Console.WriteLine(m_lines[i]);
            }
            if (SaveFile)
            {

                string tmppath = SAVEPATH;

                string[] temp = m_lines.ToArray();
                string filename = m_unsortedData.Length + ".txt";

                if (Type == 0)
                    tmppath += @"RUD\ ";
                else if (Type == 1)
                    tmppath += @"AOUD\ ";
                else if (Type == 2)
                    tmppath += @"WCUD\ ";
                else if (Type == 3)
                    tmppath += @"PD\ ";
                else
                    filename = "errorDump";


               //filename = SAVEPATH.Replace(":", ";");
               //filename = SAVEPATH.Replace("/", ".");
                
                string path = tmppath + filename;
                System.IO.File.WriteAllLines(path, temp);
            }
        }



    }





}
