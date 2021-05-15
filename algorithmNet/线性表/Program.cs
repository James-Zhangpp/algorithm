using System;

namespace 线性表
{
    class Program
    {
        static void Main(string[] args)
        {
            myArrayList mylist = new myArrayList();
            Console.WriteLine($"mylist 当前的容量为： {mylist.Capacity} 长度为：{mylist.Count}");

            mylist.Add(1);
            Console.WriteLine($"mylist 当前的容量为： {mylist.Capacity} 长度为：{mylist.Count}");

            for (int i = 2; i < 6; i++)
            {
                mylist.Add(i);
            }
            for (int i = 0; i < mylist.Count; i++)
            {
                Console.WriteLine($"第{i} 元素为 {mylist[i].ToString()}");
            }

            Console.WriteLine($"mylist 当前的容量为： {mylist.Capacity} 长度为：{mylist.Count}");

            mylist.Remove(mylist.Count - 1);
            Console.WriteLine($"mylist 当前的容量为： {mylist.Capacity} 长度为：{mylist.Count}");

            mylist.TrimToSize();
            Console.WriteLine($"mylist 当前的容量为： {mylist.Capacity} 长度为：{mylist.Count}");

            Console.ReadLine();
        }
    }
}
