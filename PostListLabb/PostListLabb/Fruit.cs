using System;
using System.Collections.Generic;
using System.Text;

namespace PostListLabb
{
    class Fruit
    {
        string _name;
        int _price;
        bool _exists;

        public Fruit(string name, int price, bool exists)
        {
            this._name = name;
            this._price = price;
            this._exists = exists;
        }
        public string Name { get { return this._name; } }
        public int Price { get { return this._price; } }
        public bool Exists { get { return this._exists; } }
    }
}
