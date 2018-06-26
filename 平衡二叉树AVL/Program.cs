using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{

    class Program
    {
        const int EH = 0;
        const int LH = 1;
        const int RH = -1;

        class Node
        {
            public int data;
            public int bf;
            public Node cLeft;
            public Node cRight;
        }

        static void Main(string[] args)
        {
            Node head = null;
            int[] datas = { 5, 9, 4, 1, 3, 10, 66, 2, 15, 33 };
            bool taller = false;
            for (int i = 0; i < datas.Length; i++)
            {
                InsertAVLTree(ref head, datas[i], ref taller);
            }

            bool lower = false;
            DeleteElement(ref head, 9, ref lower);
            PrintMid(head);
            Console.ReadKey();
        }

        static bool InsertAVLTree(ref Node node, int data, ref bool taller)
        {
            if (node == null)
            {
                node = new Node();
                node.bf = EH;
                node.data = data;
                taller = true;
                return true;
            }
            else
            {
                if (data == node.data)
                {
                    taller = false;
                    return false;
                }

                if (data < node.data)
                {
                    if (!InsertAVLTree(ref node.cLeft, data, ref taller))
                    {
                        return false;
                    }
                    if (taller)
                    {
                        switch (node.bf)
                        {
                            case EH:
                                node.bf = LH;
                                taller = true;
                                break;
                            case LH:
                                LeftBalance(ref node);
                                taller = false;
                                break;
                            case RH:
                                node.bf = EH;
                                taller = false;
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    if (!InsertAVLTree(ref node.cRight, data, ref taller))
                    {
                        return false;
                    }
                    if (taller)
                    {
                        switch (node.bf)
                        {
                            case EH:
                                node.bf = RH;
                                taller = true;
                                break;
                            case LH:
                                node.bf = EH;
                                taller = false;
                                break;
                            case RH:
                                RightBalance(ref node);
                                taller = false;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return true;
        }

        //右旋转
        static void R_Rotate(ref Node node)
        {
            Node temp;
            temp = node.cLeft;
            node.cLeft = temp.cRight;//原前驱，变左结点
            temp.cRight = node;
            node = temp;
        }

        //左旋转
        static void L_Rotate(ref Node node)
        {
            Node temp;
            temp = node.cRight;
            node.cRight = temp.cLeft;//原后继
            temp.cLeft = node;
            node = temp;
        }

        //右平衡,右边高了
        static void RightBalance(ref Node node)
        {
            Node R, r1;
            R = node.cRight;
            switch (R.bf)
            {
                case RH:
                    //右孩子和它一样的平衡因子，直接右旋转
                    node.bf = EH;
                    R.bf = EH;
                    L_Rotate(ref node);
                    break;
                case EH:
                    node.bf = RH;
                    R.bf = LH;
                    L_Rotate(ref node);
                    break;
                case LH:
                    r1 = R.cLeft;
                    switch (r1.bf)
                    {
                        case EH:
                            node.bf = EH;
                            R.bf = EH;
                            break;
                        case RH:
                            R.bf = EH;
                            node.bf = LH;
                            break;
                        case LH:
                            R.bf = RH;
                            node.bf = EH;
                            break;
                    }
                    r1.bf = EH;
                    R_Rotate(ref node.cRight);
                    L_Rotate(ref node);
                    break;
            }
        }

        static void LeftBalance(ref Node node)
        {
            Node L, lr;
            L = node.cLeft;
            switch (L.bf)
            {
                case EH:
                    L.bf = RH;
                    node.bf = LH;
                    R_Rotate(ref node);
                    break;
                case LH:
                    L.bf = node.bf = EH;
                    R_Rotate(ref node);
                    break;
                case RH:
                    lr = L.cRight;
                    switch (lr.bf)
                    {
                        case EH:
                            L.bf = L.bf = EH;
                            break;
                        case RH:
                            node.bf = EH;
                            L.bf = LH;
                            break;
                        case LH:
                            L.bf = EH;
                            node.bf = RH;
                            break;
                        default:
                            break;
                    }
                    lr.bf = EH;
                    L_Rotate(ref node.cLeft);
                    R_Rotate(ref node);
                    break;
            }
        }

        static bool DeleteElement(ref Node node, int data, ref bool lower)
        {
            bool L = false, R = false;
            if (node == null) return false;
            if (node.data == data)
            {
                Node p, s;
                p = node.cRight;
                s = p;
                lower = true;
                if (node.cRight == null)
                {
                    p = node;
                    node = node.cLeft;
                    lower = true;

                    return true;
                }
                else
                {
                    while (s != null)
                    {
                        p = s;
                        s = s.cLeft;
                    }

                    node.data = p.data;
                    DeleteElement(ref node.cRight, data, ref lower);
                    R = true;
                }
            }
            else if (data < node.data)
            {
                DeleteElement(ref node.cLeft, data, ref lower);
                L = true;
            }
            else
            {
                DeleteElement(ref node.cRight, data, ref lower);
                R = true;
            }

            if (lower)
            {
                if (L)
                {
                    switch (node.bf)
                    {
                        case LH:
                            node.bf = EH;
                            lower = true;
                            break;
                        case RH:
                            RightBalance(ref node);
                            lower = false;
                            break;
                        case EH:
                            node.bf = RH;
                            lower = false;
                            break;
                    }
                }
                else
                {
                    switch (node.bf)
                    {
                        case EH:
                            node.bf = LH;
                            lower = false;
                            break;
                        case RH:
                            node.bf = EH;
                            lower = true;
                            break;
                        case LH:
                            LeftBalance(ref node);
                            lower = false;
                            break;
                    }
                }
            }

            return true;
        }

        static void PrintMid(Node node)
        {
            if (node == null) return;

            PrintMid(node.cLeft);
            Console.Write(node.data + " ");
            if (node.cLeft != null) Console.Write("左结点：" + node.cLeft.data + " ");
            if (node.cRight != null) Console.Write("右结点：" + node.cRight.data);
            Console.WriteLine();
            PrintMid(node.cRight);
        }
    }
}
