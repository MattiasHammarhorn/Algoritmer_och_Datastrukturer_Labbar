using System;
using System.Collections;
using System.Collections.Generic;

namespace PostListLabb
{
    class Program
    {
        public class FruitShopList<T> : IEnumerable where T: Fruit
        {
            private static List<Fruit> fruitList; public FruitShopList(int size)
            {
                fruitList = new List<Fruit>(size);
            }

            public static void addItems()
            {
                fruitList.Add(new Fruit("Strawberry", 100, true));
                fruitList.Add(new Fruit("Fruitbasket", 30, true));
                fruitList.Add(new Fruit("Orange", 35, false));
            }

            private IEnumerator<Fruit> GetEnumerator()
            {
                foreach(Fruit fruit in fruitList)
                {
                    yield return fruit;
                }
            }

             IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            FruitShopList<Fruit> fruits = new FruitShopList<Fruit>(1);
            FruitShopList<Fruit>.addItems();

            foreach (Fruit fruit in fruits)
            {
                Console.WriteLine("\nFruit: " + fruit.Name + " \tPrice: " + fruit.Price + " \tExists: " + fruit.Exists);
            }
        }
    }
}
