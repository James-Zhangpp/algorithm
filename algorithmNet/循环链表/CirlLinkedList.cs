using System;
using System.Collections.Generic;
using System.Text;

namespace 循环链表
{
    public class CirlLinkedList
    {
        //个数
        private int count;

        public int Count
        {
            get { return this.count; }
        }
        //尾指针
        private Node tail;
        //当前节点的前节点
        private Node CurrPrev;

        //添加元素
        public void add(object val)
        {
            Node newNode = new Node(val);
            //链表为空
            if (tail == null)
            {
                //尾指针等于当前节点
                tail = newNode;
                //尾指针指向的是头节点
                tail.next = newNode;
                //当前节点前一个节点
                CurrPrev = newNode;
            }
            else
            {
                //新建节点next指向的尾节点next
                //这样就成了循环了
                newNode.next = tail.next;
                //尾节点的next指向当前节点
                tail.next = newNode;
                //判断当前节点前一个节点等于最后一个节点
                if (CurrPrev == tail)
                {
                    CurrPrev = newNode;
                }
                //把尾节点指向当前节点
                tail = newNode;
            }
            count++;
        }

        //删除当前元素
        public void RemoveCurrNode()
        {
            //为Null代表为空链表
            if (tail == null)
            {
                throw new NullReferenceException("集合中没有任何元素");
            }
            else if (count == 1)
            {
                //当前只有一个节点
                tail = null;
                CurrPrev = null;
            }
            else
            {
                //当前节点next等于尾节点
                if (CurrPrev.next == tail)
                {
                    tail = CurrPrev;
                }
                CurrPrev.next = CurrPrev.next.next;
            }
            count--;
        }

        //当前节点移动位置
        public void move(int step)
        {
            if (step < 0)
            {
                throw new ArgumentNullException("step 不可为负数");
            }
            //为Null代表为空链表
            if (tail == null)
            {
                throw new NullReferenceException("集合中没有任何元素");
            }
            for (int i = 0; i < step; i++)
            {
                CurrPrev = CurrPrev.next;
            }
        }

        public object CurrentObj
        {
            get { return this.CurrPrev.next.item; }
        }

        public override string ToString()
        {
            if (tail == null)
            {
                return string.Empty;
            }
            string s = "";
            //头节点
            Node node = tail.next;
            for (int i = 0; i < count; i++)
            {
                s += node.ToString() + " ";
                node = node.next;
            }
            return s;
        }
        //节点
        public class Node
        {
            public Node(object obj)
            {
                item = obj;
            }
            //放置数据
            public object item;
            //指针节点
            public CirlLinkedList.Node next;

            public override string ToString()
            {
                return item.ToString();
            }

        }
    }
}
