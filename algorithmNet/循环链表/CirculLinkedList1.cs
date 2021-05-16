using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    class CirculLinkedList1
    {
        //元素个数
        private int count;

        //尾指针
        private Node tail;

        //当前节点的前节点
        private Node CurrPrev;


        //增加元素
        public void Add(object value)
        {
            Node newNode = new Node(value);
            if (tail==null)
            {//链表为空
                tail = newNode;
                tail.next = newNode;
                CurrPrev = newNode;
            }
            else
            {//链表不为空，把元素增加到链表结尾
                newNode.next = tail.next;
                tail.next = newNode;

                if (CurrPrev==tail)
                {
                    CurrPrev = newNode;
                }
                tail = newNode;
            }
            count++;
        }

        //删除当前元素
        public void RemoveCurrNode()
        {
            //为null代表为空表
            if (tail == null) 
            {
                throw new NullReferenceException("集合中没有任何元素！");
            }
            else if (count==1)
            {
                tail = null;
                CurrPrev = null;
            }
            else
            {
                if (CurrPrev.next==tail)
                {
                    tail = CurrPrev;
                }
                CurrPrev.next = CurrPrev.next.next;
            }
            count--;
        }

        //当前节点移动步数
        public void Move(int step)
        {
            if (step<0)
            {
                throw new ArgumentOutOfRangeException("step", "移动步数不可为负数！");
            }
            if (tail==null)
            {
                throw new NullReferenceException("链表为空！");
            }
            for (int i = 0; i < step; i++)
            {
                CurrPrev = CurrPrev.next;
            }
        }

        //获得当前节点
        public object Current
        {
            get {return CurrPrev.next.item ;}
        }

        public override string ToString()
        {
            if (tail==null)
            {
                return string.Empty;
            }
            string s = "";
            Node temp = tail.next;
            for (int i = 0; i < count; i++)
            {
                s += temp.ToString() + "    ";
                temp = temp.next;
            }
            return s;
        }


        public int Count
        {
            get {return count ;}
        }

        private   class Node
        {
            public Node(object  value)
            {
                item = value;
            }
            //放置数据
            public object item;
            public CirculLinkedList1.Node next;
            public override string ToString()
            {
                return item.ToString();
            }
        }
    }
}
