using System;
using System.Collections.Generic;

namespace MyList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _List _list = new _List();
            _list.Add(9);
            _list.Add(10);
            _list.Add(12);
            _list.Add(13);
            _list.Add(14);
            _list.Insert(2, 11);
        }
    }
}
