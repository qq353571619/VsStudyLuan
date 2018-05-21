using System;
using System.Diagnostics;
using System.Linq;

namespace 八皇后_回溯算法
{
    class Program
    {

        private static int[,] geizi = new int[8, 8];
        private static int[] rowHas = Enumerable.Repeat(-1,8).ToArray();
        private static int resultNum = 0;

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Place(0);
            stopwatch.Stop();
            Console.WriteLine(resultNum  +  " 用时：" + stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }

        static void Place(int row) {

            if (row == -1) {
                return;
            }

            int i = 0;
            int col = -1;
            int isP = rowHas[row];
            
            if (isP != -1) {
                //取消先前放的
                geizi[row, isP] = 0;
                rowHas[row] = -1;
            }
            

            //回溯的处理从下一列开始放
            for (i = isP + 1; i < 8; i++)
            {
                if (col != -1)
                {
                    continue;
                }

                if (CheckPlace(row, i))
                {
                    col = i;
                    geizi[row, i] = 1;
                    rowHas[row] = i;
                }
            }


            if (col != -1)
            {
                if (row == 7)
                {
                    //出结果了，打印结果
                    //PrintAll();

                    resultNum++;
                    geizi[row, col] = 0;
                    rowHas[row] = -1;
                    Place(row - 1);
                }
                else
                {
                    Place(row + 1);
                }

            }
            else
            {
                Place(row - 1);
            }

        }

        //检测是否可以放置
        static bool CheckPlace(int row, int col) {
            //3个方向检测
            bool CanPlace = true;

            for (int i = 0; i < row; i++) {

                int tRow = row - i - 1;
                int lCol = col - i - 1;
                int rCol = col + i + 1;
                if (tRow < 0) {
                    continue;
                }

                //向上
                if (geizi[tRow, col] == 1) {
                    CanPlace = false;
                }

                //左上
                if (lCol >= 0) {
                    if (geizi[tRow, lCol] == 1)
                    {
                        CanPlace = false;
                    }
                }

                //右上
                if (rCol <= 7) {
                    if (geizi[tRow, rCol] == 1)
                    {
                        CanPlace = false;
                    }
                }
                
            }

            return CanPlace;
        }

        //输出结果
        static void PrintAll() {
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    Console.Write(geizi[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
