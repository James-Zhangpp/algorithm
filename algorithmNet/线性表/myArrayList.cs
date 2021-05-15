using System;
using System.Collections.Generic;
using System.Text;

namespace 线性表
{
    public class myArrayList
    {
        //容量
        private const int _defaultCapacity = 4;
        //存放的数组元素
        private object[] _item;
        //数组大小
        private int _size;
        //创建一个个数为0的数组状态 
        private static readonly object[] emptyArray = new object[0];

        //构造一个为空的数组
        public myArrayList()
        {
            this._item = emptyArray;
        }

        //初始化数组容量
        public myArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("capacity", "arrayList数组不能为负数");
            }
            this._item = new object[capacity];
        }

        //索引器
        public virtual object this[int index]
        {
            get
            {
                if (index < 0 || index >= this._size)
                {
                    throw new ArgumentOutOfRangeException("index", "索引超出范围");
                }
                return this._item[index];

            }
            set
            {
                if (index < 0 || index >= this._size)
                {
                    throw new ArgumentOutOfRangeException("index", "索引超出范围");
                }
                this._item[index] = value;
            }
        }
        //获取当前元素个数
        public virtual int Count
        {
            get { return this._size; }
        }

        //数组容量
        public virtual int Capacity
        {
            get { return this._item.Length; }
            set
            {
                if (value != this._item.Length)
                {
                    if (value > 0)
                    {
                        //开辟新的内存空间存储容量
                        object[] dest = new object[value];
                        if (this._size > 0)
                        {
                            //搬动元素
                            Array.Copy(this._item, 0, dest, 0, this._size);
                        }
                        //赋值为新的数组
                        this._item = dest;
                    }
                    else
                    {
                        //数组最小为4
                        this._item = new object[_defaultCapacity];
                    }
                }
            }
        }

        //元素添加
        public virtual int Add(object obj)
        {
            //空间已满
            if (this._size == this._item.Length)
            {
                this.EnsureCapacity(this._size + 1);
            }
            this._item[this._size] = obj;
            return this._size++;
        }
        //扩容
        private void EnsureCapacity(int v)
        {
            if (this._item.Length < v)
            {
                //空间加倍
                int num = this._item.Length == 0 ? _defaultCapacity : this._item.Length * 2;
                if (num < v)
                {
                    num = v;
                }
                this.Capacity = num;
            }
        }
        //指定位置插入值
        public virtual void Insert(int index, object value)
        {
            if (index < 0 || index > this._size)
            {
                throw new ArgumentOutOfRangeException("Insert", "索引超出范围");
            }
            if (this._size == this._item.Length)
            {
                this.EnsureCapacity(this._size + 1);
            }
            if (index < this._size)
            {
                //对应位置插入值
                Array.Copy(this._item, index, this._item, index + 1, this._size - index);
            }
            this._item[index] = value;
            this._size++;
        }

        //移出指定位置索引的元素
        public virtual void Remove(int index)
        {
            if (index < 0 || index > this._size)
            {
                throw new ArgumentOutOfRangeException("Remove", "索引超出范围");
            }
            this._size--;
            if (index < this._size)
            {
                //拷贝数组
                Array.Copy(this._item, index + 1, this._item, index, this._size - index);
            }
            this._item[this._size] = null;
        }
        //裁剪空间
        public virtual void TrimToSize()
        {
            this.Capacity = this._size;
        }
    }
}
