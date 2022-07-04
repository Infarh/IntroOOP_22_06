//#nullable disable

using System.Collections;

namespace Utilities;

public class RefList<T> : IEnumerable<T>
{
    public class Node
    {
        internal RefList<T> List { get; set; }

        public T Value { get; set; }

        public Node? Prev { get; internal set; }

        public Node? Next { get; internal set; }

        internal Node(RefList<T> List, T value)
        {
            Value = value;
            this.List = List;
        }
    }

    private int _Count;

    public Node? First { get; set; }

    public Node? Last { get; set; }

    public Node AddFirst(T value)
    {
        var node = new Node(this, value);

        _Count++;

        //if (ReferenceEquals(First, null))
        //if (Equals((object)First, null))
        //if (First is not { })
        if (First is null) // Если список был пуст
        {
            First = node;
            Last = node;

            return node;
        }

        // Если в списке что-то уже было, то надо изменить первый узел

        node.Next = First;
        First.Prev = node;
        First = node;

        return node;
    }

    public Node AddLast(T value)
    {
        var node = new Node(this, value);

        _Count++;

        if (Last is null)
        {
            Last = node;
            First = node;

            return node;
        }

        node.Prev = Last;
        Last.Next = node;
        Last = node;

        return node;
    }

    public Node AddBefore(Node Position, T value)
    {
        if (!ReferenceEquals(Position.List, this))
            throw new InvalidOperationException("Нельзя добавить узел до указанного узла потому, что указанный узел принадлежит другому списку");

        if (ReferenceEquals(Position, First))
            return AddFirst(value);

        var node = new Node(this, value);

        node.Next = Position;
        node.Prev = Position.Prev;

        _Count++;

        Position.Prev = node;
        node.Prev!.Next = node;

        return node;
    }

    public Node AddAfter(Node Position, T value)
    {
        if (!ReferenceEquals(Position.List, this))
            throw new InvalidOperationException("Нельзя добавить узел после указанного узла потому, что указанный узел принадлежит другому списку");

        if (ReferenceEquals(Position, Last))
            return AddLast(value);

        var node = new Node(this, value)
        {
            Prev = Position,
            Next = Position.Next,
        };

        _Count++;

        Position.Next = node;
        node.Next!.Prev = node;

        return node;
    }

    public T Remove(Node node)
    {
        if (ReferenceEquals(First, Last)) // в списке всего один узел
        {
            First = null;
            Last = null;
            _Count = 0;
            return node.Value;
        }

        if (ReferenceEquals(node, First))
        {
            First = node.Next;
            First!.Prev = null;
            _Count--;
            return node.Value;
        }

        if (ReferenceEquals(node, Last))
        {
            Last = node.Prev;
            Last!.Next = null;
            _Count--;
            return node.Value;
        }

        node.Prev!.Next = node.Next;
        node.Next!.Prev = node.Prev;

        node.Next = null;
        node.Prev = null;

        _Count--;
        return node.Value;
    }

    public void Clear()
    {
        var node = First;
        while (node is not null)
        {
            node.Prev = null;
            var tmp = node;
            node = node.Next;
            tmp.Next = null;
        }

        _Count = 0;
        First = Last = null;
    }

    public override string ToString() => string.Join(", ", this);


    #region IEnumerable<T>
    
    public IEnumerator<T> GetEnumerator()
    {
        var node = First;
        while (node is not null)
        {
            yield return node.Value;
            node = node.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); 

    #endregion
}
