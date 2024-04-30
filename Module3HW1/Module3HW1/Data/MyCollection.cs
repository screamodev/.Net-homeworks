using System.Collections;

namespace Module3HW1.Data;

public class MyCollection<T> : IEnumerable<T>
{
    private T[] _items;

    public MyCollection()
   {
       _items = new T[0];
       Counter = 0;
   }

    public MyCollection(T[] items)
   {
       _items = items;
       Counter = items.Length;
   }

    private int Counter { get; set; }

    public int Count()
   {
       return Counter;
   }

    public void Sort(IComparer comparer)
   {
       Array.Sort(_items, comparer);
   }

    public void Add(T item)
   {
       Counter++;
       Array.Resize(ref _items, Counter);
       _items[Counter - 1] = item;
   }

    public void Add(T[] items)
   {
       Counter += items.Length;
       _items = _items.Concat(items).ToArray();
   }

    public void SetDefaultAt(int index)
   {
       _items[index] = default;
   }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyCollectionEnumerator<T>(_items);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class MyCollectionEnumerator<T> : IEnumerator<T>
{
    private T[] _data;
    private int _position = -1;

    public MyCollectionEnumerator(T[] items)
    {
        _data = items;
    }

    public T Current
    {
        get
        {
            try
            {
                if (_data[_position] == null)
                {
                    _position++;
                    return _data[_position];
                }

                return _data[_position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        _position++;
        return _position < _data.Length;
    }

    public void Reset()
    {
        _position = -1;
    }

    public void Dispose()
    {
        _data = null;
    }
}