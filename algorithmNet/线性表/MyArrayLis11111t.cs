using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class MyArrayList
    {
        //容量
        private const int _defaultCapacity = 4;
        //存放数组元素
        private object[] _items;
        //数组大小
        private int _size;
        //元素个数为0的数组状态
        private static readonly object[] emptyArray = new object[0];

        public MyArrayList()
        {
            this._items = emptyArray;
        }

        public MyArrayList( int capacity)
        {
            if (capacity<0)
            {
                throw new ArgumentOutOfRangeException("capacity","ArrayList的容量不可为负数！");
            }
            this._items = new object[capacity];
        }

        //索引器
        public virtual object this[int index]
        {
            get 
            {
                if (index<0||index>=this._size)
                {
                    throw new ArgumentOutOfRangeException("index","索引超出范围！");
                }
                return this._items[index];
            }

            set 
            {
                if (index < 0 || index >= this._size)
                {
                    throw new ArgumentOutOfRangeException("index", "索引超出范围！");
                }
                this._items[index] = value;
            }

        }

        //当前数组元素个数
        public virtual int Count
        {
            get {return this._size ;}
        }

        //数组的容量
        public virtual int Capacity
        {
            get { return this._items.Length; }
            set 
            {
                if (value!=this._items.Length)
                {
                    if (value<this._size)
                    {
                        throw new ArgumentOutOfRangeException("value","容量太小");
                    }
                    if (value > 0)
                    {//开辟新内存空间存储元素
                        object[] dest = new object[value];
                        if (this._size > 0)
                        {//搬动元素
                            Array.Copy(this._items, 0, dest, 0, this._size);
                        }
                        this._items = dest;
                    }
                    else//数组最小的空间为4
                    {
                        this._items=new object[_defaultCapacity]; 
                    } 
                }
            }
        }

        //元素的添加
        public virtual int Add(object value)
        {//当空间已满
            if (this._size==this._items.Length)
            {
                this.EnsureCapacity(this._size+1);
            }
            this._items[this._size] = value;
            return this._size++;
        }

        //扩容
        private void EnsureCapacity(int p)
        {
            if (this._items.Length<p)
            {//空间加倍
                int num = (this._items.Length == 0) ? _defaultCapacity : (this._items.Length * 2);
                if (num < p)
                {
                    num = p;
                }
                this.Capacity = num;
            } 
        }

        //指定位置插入元素
        public virtual void Insert( int index,object value)
        {
            if (index<0||index>this._size)
            {
                throw new ArgumentOutOfRangeException("index","索引超出范围！");
            }
            if (this._size==this._items.Length)
            {
                this.EnsureCapacity(this._size + 1);
            }
            if (index<this._size)
            {
                Array.Copy(this._items, index, this._items, index + 1, this._size - index);
            }
            this._items[index] = value;
            this._size++;
        } 

        //移除指定索引的元素
        public virtual void Remove(int index)
        {
            if (index < 0 || index > this._size)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围！");
            }
            this._size--;
            if (index<this._size)
            {
                Array.Copy(this._items,index+1,this._items,index,this._size-index);
            }
            this._items[this._size]=null; 
        }
        
        //裁剪空间
        public virtual void TrimToSize()
        {
            this.Capacity = this._size;
        }
    }
}
