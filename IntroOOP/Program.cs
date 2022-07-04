
using Utilities;

var list1 = new RefList<int>();

list1.AddFirst(1);
var node = list1.AddFirst(2);
list1.AddFirst(3);

list1.AddBefore(node, -100);
list1.AddAfter(node, 100);

var list2 = new RefList<int>();

list2.AddLast(3);
list2.AddLast(2);
list2.AddLast(1);

//var list_node = new RefList<int>.Node(5);

Console.WriteLine("Hello, World!");
