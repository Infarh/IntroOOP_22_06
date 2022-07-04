namespace Utilities;

public class RefList<T>
{
    public class Node
    {
        public T Value { get; set; }

        public Node? Prev { get; internal set; }

        public Node? Next { get; internal set; }

        internal Node(T value) => Value = value;
    }

    private int _Count;

    public Node? First { get; set; }

    public Node? Last { get; set; }

    public Node AddFirst(T value)
    {
        var node = new Node(value);

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
        var node = new Node(value);

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
        if (ReferenceEquals(Position, First))
            return AddFirst(value);

        var node = new Node(value);

        node.Next = Position;
        node.Prev = Position.Prev;

        _Count++;

        Position.Prev = node;
        node.Prev!.Next = node;

        return node;
    }

    public Node AddAfter(Node Position, T value)
    {
        if (ReferenceEquals(Position, Last))
            return AddLast(value);

        var node = new Node(value)
        {
            Prev = Position,
            Next = Position.Next,
        };

        _Count++;

        Position.Next = node;
        node.Next!.Prev = node;

        return node;
    }
}
