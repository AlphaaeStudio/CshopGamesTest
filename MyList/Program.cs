using System;
using System.Collections.Generic;

namespace MyList {
    class Program : ProgramBase {
        static void Main(string[] args) {
            MyList<int> myList = new MyList<int>();
            myList.Add(1);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);
            myList.Add(6);
            myList.Insert(2, 100);
            myList.Insert(2, 101);
            myList.Insert(2, 100);
            myList.Insert(2, 100);
            myList.Insert(2, 100);
            myList.RemoveAt(1);

            for (int i = 0; i < myList.Length; i++) {
                Console.Write(myList[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine(myList.IndexOf(100));
            Console.WriteLine(myList.LastIndexOf(100));

            myList.Sort();
            for (int i = 0; i < myList.Length; i++) {
                Console.Write(myList[i] + " ");
            }
            Console.WriteLine();

        }
    }

    class MyList<T> {
        private T[] data = new T[0];
        public int Capacity { get => data.Length; }
        public int Length { get => length; }
        private int length = 0;

        public T this[int index] {
            get {
                if (index < 0 || index > length - 1)
                    throw new ArgumentOutOfRangeException();
                return data[index];
            }
        }

        public void Add(T item) {
            if (Capacity == 0) data = new T[4];
            else if (Capacity == Length) {
                T[] tempData = new T[Capacity * 2];
                for (int i = 0; i < length; i++) {
                    tempData[i] = data[i];
                }
                data = tempData;
            }
            data[length] = item;
            length++;
        }

        public void Insert(int index, T item) {
            if (Capacity == Length) {
                T[] tempData = new T[Capacity * 2];
                for (int i = 0; i < length; i++) {
                    tempData[i] = data[i];
                }
                data = tempData;
            }
            for (int i = Length - 1; i >= index; i--) {
                data[i + 1] = data[i];
            }
            data[index] = item;
            length++;
        }

        public void RemoveAt(int index) {
            for (int i = index; i < Length - 1; i++) {
                data[i] = data[i + 1];
            }
            length--;
        }

        public int IndexOf(T item) {
            for (int i = 0; i < Length; i++) {
                if (data[i].Equals(item)) return i;
            }
            return -1;
        }

        public int LastIndexOf(T item) {
            for (int i = Length - 1; i >= 0; i--) {
                if (data[i].Equals(item)) return i;
            }
            return -1;
        }

        public void Sort() {
            Array.Sort(data, 0, length);
        }

    }
}
