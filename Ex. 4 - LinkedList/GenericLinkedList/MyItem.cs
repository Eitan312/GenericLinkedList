using GenericLinkedList.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;

namespace GenericLinkedList
{
    public class MyItem<T> : IMyItem<T>
    {
        [NotNull]
        private T _content;
        [AllowNull]
        private MyItem<T> _nextItem;

        public IMyItem<T> NextItem { get => _nextItem; set => _nextItem = (MyItem<T>)value; }

        public T Content => _content;

        public MyItem(T content)
        {
            if (content == null) 
            { 
                throw new ArgumentNullException("content"); 
            }

            _content = content;
        }

        public MyItem(T content, MyItem<T> next) 
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            _content = content;
            _nextItem = next;
        }
    }
}
