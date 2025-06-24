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
        private int _count;

        public MyList()
        {
            _head = null;
            _count = 0;
        }

        public MyList(MyItem<T> head)
        {
            this._head = head;
        }

        public int Count => _count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            // In case T is a nullable type
            if(item == null)
            {
                Console.WriteLine("Value Has To Exist!");
                return;
            }

            if(_head == null)
            {
                _head = new MyItem<T>(item);
                _count++;
                return;
            }

            MyItem<T> pointer = _head;

            while (pointer.NextItem != null)
            {
                pointer = (MyItem<T>)pointer.NextItem;
            }

            pointer.NextItem = new MyItem<T>(item);
            _count++;
        }

        public void Add(MyItem<T> node)
        {
            if (node == null)
            {
                Console.WriteLine("Cant Add Null To List!");
                return;
            }

            if (_head == null)
            {
                _head = new MyItem<T>(node);
                _count++;
                node = (MyItem<T>)node.NextItem;

                while(node != null)
                {
                    _count++;
                    node = (MyItem<T>)node.NextItem;
                }

                return;
            }

            MyItem<T> pointer = _head;

            while (pointer.NextItem != null)
            {
                pointer = (MyItem<T>)pointer.NextItem;
            }

            pointer.NextItem = node;

            while (node != null)
            {
                _count++;
                node = (MyItem<T>)node.NextItem;
            }
        }

        public void Clear()
        {
            _head = null;
            _count = 0;
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
                _count--;
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
            _count--;
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
