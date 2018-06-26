using System;

namespace 二叉排序树
{
    class Program
    {
        class Node
        {
            public int data;
            public Node cLeft;
            public Node cRight;
        }

        static void Main(string[] args)
        {
            int[] datas = { 1,2,3,4,5,6,7,8,9 };
            Node head = null;
            CreateOrderTree(ref head, datas);
            Delete(ref head, 6);
            PrintMid(head);//1 2 3 6 8 9 22 55 77
            Console.ReadKey();
        }

        static void CreateOrderTree(ref Node head, int[] datas)
        {
            if (datas.Length < 1) return;


            for (int i = 0; i < datas.Length; i++)
            {
                Insert(ref head, datas[i]);
            }

        }

        //插入
        static void Insert(ref Node head, int data)
        {
            if (head == null)
            {
                head = new Node();
                head.data = data;
                return;
            }

            Node temp = head;
            Node preTemp = temp;
            bool isLeft = false;

            while (temp != null)
            {
                preTemp = temp;
                if (data < temp.data)
                {
                    //左边
                    isLeft = true;
                    temp = temp.cLeft;
                }
                else if (data > temp.data)
                {
                    isLeft = false;
                    temp = temp.cRight;
                }
                else
                {
                    //重复的数据
                    return;
                }
            }

            Node node = new Node();
            node.data = data;
            if (isLeft)
            {
                preTemp.cLeft = node;
            }
            else
            {
                preTemp.cRight = node;
            }
        }

        static void Search(Node head,int data,ref Node targetNode, ref Node preNode)
        {
            targetNode = head;
            preNode = null;

            while (targetNode != null && targetNode.data != data)
            {
                preNode = targetNode;
                if (data < targetNode.data)
                {
                    targetNode = targetNode.cLeft;
                }
                else
                {
                    targetNode = targetNode.cRight;
                }
            }
        }

        //删除
        static void Delete(ref Node head, int data)
        {
            Node targetNode = null;
            Node preNode = null;

            Search(head, data, ref targetNode, ref preNode);
            
            if (targetNode == null) return;

            if (targetNode.cLeft == null || targetNode.cRight == null)
            {
                //有一边的结点为空或两边都空，直接删调
                Node tempTargetNode;
                if (targetNode.cLeft == null)
                {
                    tempTargetNode = targetNode.cRight;
                }
                else
                {
                    tempTargetNode = targetNode.cLeft;
                }

                if (preNode == null)
                {
                    head = tempTargetNode;
                    return;
                }

                if (preNode.cLeft == targetNode)//左边
                {
                    preNode.cLeft = tempTargetNode;
                }
                else
                {
                    preNode.cRight = tempTargetNode;
                }
            }
            else
            {
                //两边都有
                //在左边找一个最大的替换,就是目标的前驱。或则找后继，就是右边中最小的
                Node LeftBig = targetNode.cLeft;
                Node preBig = targetNode;
                while (LeftBig.cRight != null)
                {
                    preBig = LeftBig;
                    LeftBig = LeftBig.cRight;
                }
                

                preBig.cLeft = LeftBig.cLeft;//删除替换的节点
                if (LeftBig != targetNode.cLeft)//排除特殊情况
                {
                    LeftBig.cLeft = targetNode.cLeft;
                }
                LeftBig.cRight = targetNode.cRight;

                if (preNode == null)
                {
                    head = LeftBig;
                    return;
                }
                if (preNode.cLeft == targetNode)//左边
                {
                    preNode.cLeft = LeftBig;
                    
                }
                else
                {
                    preNode.cRight = LeftBig;
                }

            }
        }


        //中序遍历输出
        static void PrintMid(Node node)
        {
            if (node == null) return;

            PrintMid(node.cLeft);
            Console.Write(node.data + " ");
            PrintMid(node.cRight);

        }
    }
}
