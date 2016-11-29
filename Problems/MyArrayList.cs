using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterDemo
{
    class MyArrayList<T>
    {
        public int DEFAULT_SIZE = 10;
        private T[] table;
        private int curr_size;
        private int max_size;

        public MyArrayList()
        {
            table = new T[DEFAULT_SIZE];
            max_size = DEFAULT_SIZE;
        }
        public MyArrayList(int size)
        {
            table = new T[size];
            max_size = size;
        }
        public void Add(T item)
        {
            if(curr_size == max_size)
            {
                table = Resize();
            }
            table[curr_size] = item;
            curr_size++;
        }

        public T[] Resize()
        {
            int new_size = 2 * curr_size + 1;
            T[] newTable = new T[new_size];
            for(int i = 0; i < curr_size; i++)
            {
                newTable[i] = table[i];
            }
            
            return newTable;

        }

        public T Get(int index)
        {
            if(index > curr_size - 1)
            {
                throw new Exception("Index out of Bound Exception");
                
            }
            return table[index];
        }

        public void Remove(T item)
        {

        }
    }
}
