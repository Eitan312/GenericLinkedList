using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLinkedList
{
    public class MyList<T> : ICollection<T>
    {
        [AllowNull]
        private MyItem<T> _head;

        public MyList()
        {
            _head = null;
        }

        public MyList(MyItem<T> head)
        {
            this._head = head;
        }

        private int GetCount()
        {
            MyItem<T> pointer = _head;
            int count = 0;

            while(pointer != null)
            {
                count++;
                pointer = (MyItem<T>)pointer.NextItem;
            }

            return count;
        }

        public int Count => GetCount();

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            MyItem<T> pointer = _head;

            while (pointer.NextItem != null)
            {
                pointer = (MyItem<T>)pointer.NextItem;
            }

            pointer.NextItem = new MyItem<T>(item);
        }

        public void Clear()
        {
            _head = null;
        }

        public bool Contains(T item)
        {
            MyItem<T> pointer = _head;

            while (pointer.NextItem != null)
            {
                if (pointer.Content.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(T item)
        {
            if(item == null)
            {
                throw new ArgumentNullException();
            }

            MyItem<T> pointer = _head;

            if (_head.Content.Equals(item))
            {
                _head = (MyItem<T>)_head.NextItem;
                return true;
            }

            while (pointer != null && !pointer.NextItem.Content.Equals(item))
            {
                pointer = (MyItem<T>)pointer.NextItem;
            }

            if(pointer == null)
            {
                return false;
            }

            pointer.NextItem = pointer.NextItem.NextItem;
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
