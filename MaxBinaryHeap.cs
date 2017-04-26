using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class MaxBinaryHeap<T>
    {

        private List<T> list;

        public MaxBinaryHeap(List<T> listT)
        {
            for (int i = 0; i < listT.Count(); i++)
            {
                heapify(listT[i]);
            }
        }

        public int ListSize
        {
            get
            {
                return this.list.Count();
            }
        }

        public void Insert(T value)
        {
            list.Add(value);
            int i = ListSize - 1;
            int parent = (i - 1) / 2;

            while (i > 0 && list[parent] < list[i])
            {
                T temp = list[i];
                list[i] = list[parent];
                list[parent] = temp;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        public void heapify(T i) //упорядочивание
        {
            T leftChild;
            T rightChild;
            T largestChild;

            for (; ; )
            {
                leftChild = 2 * i + 1;
                rightChild = 2 * i + 2;
                largestChild = i;

                if (leftChild < ListSize && list[ToInt(leftChild)] > list[ToInt(largestChild)]) 
                {
                    largestChild = leftChild;
                }

                if (rightChild < ListSize && list[rightChild] > list[largestChild])
                {
                    largestChild = rightChild;
                }

                if (largestChild == i)
                {
                    break;
                }

                T temp = list[i];
                list[i] = list[largestChild];
                list[largestChild] = temp;
                i = largestChild;
            }
        }

        int extract(T value)
        {

            int res = list[value];
            list[value] = list[list.Count() - 1];

            for (int i = list.Count() / 2; i >= 0; i--)
            {
                heapify(i);
            }
            list.RemoveAt(list.Count()-1);

            return res;
        }

        public static Boolean operator <(T r1, T r2)
        {
            if (r1 < r2)
                return true;
            else
                return false;
        }
    }
}
