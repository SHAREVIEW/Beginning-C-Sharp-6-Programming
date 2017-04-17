using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12Pr05
{
    public class ShortList<T> : IList<T>
    {
        protected IList<T> list;
        protected int maxSize;
        public ShortList(int maxsize)
        {
            list = new List<T>();
            maxSize = maxsize;
        }
        public ShortList(int maxsize,IEnumerable<T> members)
        {
            maxSize = maxsize;
            list = new List<T>(members);
            if (Count > maxSize) IndexOutOfRangeException();
        }
        public ShortList(IEnumerable<T> members) : this(10, members)
        { }
        public void IndexOutOfRangeException()
        {
            throw new IndexOutOfRangeException("超出容量限制!");
        }

        #region IList<T> members
        public T this[int index]
        {
            get
            {
                return list[index];
            }

            set
            {
                list[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return list.IsReadOnly;
            }
        }

        public void Add(T item)
        {
            if (list.Count >= maxSize) IndexOutOfRangeException();
            list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach(T member in list)
            {
                array[arrayIndex++] = member;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            if (Count >= maxSize) IndexOutOfRangeException();
            list.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
        #endregion
    }
}
