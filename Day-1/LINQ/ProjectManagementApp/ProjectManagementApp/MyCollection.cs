using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjectManagementApp
{
    public class MyCollection<T> : IEnumerable, IEnumerator, IEnumerable<T>, IEnumerator<T>
    {
        private ArrayList _list = new ArrayList();

        public int Count()
        {
            return _list.Count;
        }
        public void Add(T item)
        {
            _list.Add(item);
        }

        public T this[int index]
        {
            get { return (T) _list[index]; }
        }

        public T GetByIndex(int index)
        {
            return (T) _list[index];
        }

        private int _index = -1;
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            _index++;
            if (_index >= _list.Count)
            {
                Reset();
                return false;
            }
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        T IEnumerator<T>.Current { get { return (T) this.Current; } }

        public object Current { get { return (T) _list[_index]; } }

        public void Dispose()
        {
            _index = -1;
        }
    }
}