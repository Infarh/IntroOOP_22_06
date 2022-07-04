namespace Utilities;

public class RefList<T>
{
    public class Node
    {
        public T Value { get; set; }

        public Node? Prev { get; set; }

        public Node? Next { get; set; }

        internal Node(T value) => Value = value;
    }

    private int _Count;

    public Node? First { get; set; }

    public Node? Last { get; set; }

    public void AddFirst(T value)
    {
        var node = new Node(value);
    }
}
