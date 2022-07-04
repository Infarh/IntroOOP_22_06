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
}
