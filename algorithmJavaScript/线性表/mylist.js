class MyList {
    //默认容量
    defaultCapacity = 4
    //定义一个容量为0的数组
     item;
    //数组大小
    _size = 0
    //定义一个为空的数组
    constructor() {
        this.item = new Array(0);
        //通过代理来实现索引器
        return new Proxy(this, {
            get: function (target, prop) {
                if (isNaN(prop)) {
                    return target[prop];
                }
                let index = Number(prop)
                if (index < 0 || index >= target._size) {
                    throw "索引超出范围";
                }
                return target.item[index];
            },
            set: (target, prop, value) => {
               if (prop == "Capacity" || prop=="_size") {
                    target[prop] = value;
                    return true;
                }
                if (target.hasOwnProperty(prop)) return true;
                if (isNaN(prop)) { throw "下标不能为字符串"; }
                if (Number(prop) < 0 || Number(prop) >= target._size) { throw "索引超出范围"; }
                target.item[prop] = value;
                return true
            }
        });

    }
    //获取数组个数
    get Count() {
        return this._size;
    }
    get Capacity() {
        return this.item.length
    }
    set Capacity(val) {
        if (val != this.item.length) {
            if (val > 0) {
                //开辟新的内存空间存储容量
                let dest = new Array(val);
                if (this._size > 0) {
                    //搬动元素
                    dest.splice(0,this._size,...this.item)
                    this.item = dest;
                  
                } else {
                    this.item = new Array(this.defaultCapacity)
                }

            } else {
                this.item = new Array[this.defaultCapacity];
            }
        }
    }
    Add(val) {
        //空间已满
        if (this._size === this.Count) {
            this.EnsureCapacity(Number(this._size) + 1)
        }
        this.item[this._size] = val;
        this._size++
        return this._size;
    }

    //扩容
    EnsureCapacity(v) {
        if (this.item.length < v) {
            //空间加倍
            let num = this.item.length == 0 ? this.defaultCapacity : this.item.length * 2;
            if (num < v) {
                num = v;
            }
            this.Capacity = num;
        }
    }

   Insert(index,value){

   }
   Remove(index){

   }
   TrimToSize(){
       this.Capacity=this._size;
   }

}

var arrlist = new MyList();
arrlist.Add(1)
arrlist.Add(2)
arrlist.Add(3)
arrlist.Add(4)
arrlist.Add(5)
console.log(arrlist[2]);
arrlist[1]=123;
console.log(arrlist[1]);
for(let i=0;i<arrlist.Count;i++){
    console.log(arrlist[i]);
} 
console.log(arrlist.Count);
console.log(arrlist.Capacity);
