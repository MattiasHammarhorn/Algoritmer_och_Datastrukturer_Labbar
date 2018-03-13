using System;
using System.Collections.Generic;

namespace GenericsCodeAlong
{
    class Program
    {
        public class MyGenericArray<T> //
        {
            private T[] array; public MyGenericArray(int size)
            {
                array = new T[size + 1];
            }
            public T getItem(int index)
            {
                return array[index];
            }
            public void setItem(int index, T value)
            {
                array[index] = value;
            }
        }
        static void Main(string[] args) // T är den ersättningsvariabel som betecknar typen som kan lä
        {
            MyGenericArray<int> intArray = new MyGenericArray<int>(5);
            for (int i = 0; i <= 5; i++)
            {
                intArray.setItem(i, i * 5); // Skapar arrayen för typen T och med size (+1 eftersom dess )
            }

            for (int i = 0; i <= 5; i++)
            {
                Console.Write(intArray.getItem(i) + " ");
            }

            MyGenericArray<char> charArray = new MyGenericArray<char>(5);
            for (int i = 0; i <= 5; i++)
            {
                charArray.setItem(i, (char)(i + 97));
            }

            for (int i = 0; i <= 5; i++)
            {
                Console.Write(charArray.getItem(i) + " ");
            }
        }
    }
}
