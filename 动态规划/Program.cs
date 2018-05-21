using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 动态规划
{

    class GoldM {
        public int Gold;
        public int People;
        public bool isVisited;

        public GoldM(int gold, int people) {
            Gold = gold;
            People = people;
            isVisited = false;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(GetNum(4));
            GoldM[] goldms = new GoldM[] {
                new GoldM(3000,5),
                new GoldM(5000,6),
                new GoldM(2000,2),
                new GoldM(6000,7),
                new GoldM(2000,3)
            };
            Console.WriteLine(GetMoreGold(5, 10, goldms));


            Console.ReadKey();
        }

        static int GetNum(int all) {
            if (all == 0) {
                return 0;
            }

            if (all == 1) {
                return 1;
            }

            if (all == 2) {
                return 2;
            }

            int Fi = 1;
            int Fj = 2;
            int temp = 0;

            for (int i = 2; i < all; i++) {
                temp = Fj;
                Fj = Fi + Fj;
                Fi = temp;
            }

            return Fj;
        }

        static int GetMoreGold(int n, int w, GoldM[] goldm) {

            int[] preResult = new int[w+1];
            int[] result = new int[w+1];

            //初始化第一行,i代表人数
            for (int i = 0; i <= w; i++) {
                if (i < goldm[0].People)
                {
                    preResult[i] = 0;
                }
                else {
                    preResult[i] = goldm[0].Gold;
                }
            }
            goldm[0].isVisited = true;

            for (int gg = 1; gg < n; gg++) {//金矿

                for (int pp = 0; pp <= w; pp++) {//人数
                    if (pp < goldm[gg].People)
                    {
                        result[pp] = preResult[pp];
                    }
                    else {
                        int newGold = preResult[pp - goldm[gg].People] + goldm[gg].Gold;
                        result[pp] = Math.Max(newGold, preResult[pp]);
                    }
                }
                result.CopyTo(preResult,0);
            }

            return result[w];
        }
    }
}
