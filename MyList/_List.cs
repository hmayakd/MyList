using System;

namespace MyList
{
    public class _List
    {
        private const int _defaultCapacity = 4;
        private int[] _items;
        static readonly int[] _emptyArray = new int[0];
        private int _size;
        private int _version;
        public _List()
        {
            _items = _emptyArray;
        }
        public int Count
        {
            get
            {
                return _size;
            }
        }
        public int Capacity
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value < _size)
                {
                    throw new ArgumentOutOfRangeException("Wrong capacity");
                }
                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        int[] newItems = new int[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, 0, newItems, 0, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = _emptyArray;
                    }
                }
            }
        }
        public void Add(int item)
        {
            if (_size == _items.Length)
                EnsureCapacity(_size + 1);
            _items[_size++] = item;
            _version++;
        }
        public void Insert(int index, int item)
        {
            if ((uint)index > (uint)_size)
                throw new ArgumentOutOfRangeException("Given index is out of range");
            if (_size == _items.Length)
                EnsureCapacity(_size + 1);
            if (index < _size)
            {
                int[] _itemsNew = new int[_items.Length];
                for (int i = _items.Length - 1; i > index; i--)
                {
                    _items[i] = _items[i - 1];
                }
            }
            _items[index] = item;
            _size++;
            _version++;
        }
        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity = _items.Length == 0 ? _defaultCapacity : _items.Length * 2;
                if ((uint)newCapacity > 0X7FEFFFFF) newCapacity = 0X7FEFFFFF;
                if (newCapacity < min) newCapacity = min;
                Capacity = newCapacity;
            }
        }
        public override string ToString()
        {
            return $"Count = {Count}";
        }
    }
}
