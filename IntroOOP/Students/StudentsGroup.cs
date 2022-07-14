using System.Collections;

using IntroOOP.Students.Base;

namespace IntroOOP.Students;

public class StudentsGroup : NamedItem, IEnumerable<Student>, IList<Student>
{
    public List<Student> Students { get; set; } = new();

    #region IEnumerable<Student>

    public IEnumerator<Student> GetEnumerator() => Students.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    #endregion

    #region IList<Student>

    public Student this[int index] { get => Students[index]; set => Students[index] = value; }

    public int Count => Students.Count;

    public bool IsReadOnly => false;

    public void Add(Student item) => Students.Add(item);

    public void Clear() => Students.Clear();

    public bool Contains(Student item) => Students.Contains(item);

    public void CopyTo(Student[] array, int arrayIndex) => Students.CopyTo(array, arrayIndex);

    public int IndexOf(Student item) => Students.IndexOf(item);

    public void Insert(int index, Student item) => Students.Insert(index, item);

    public bool Remove(Student item) => Students.Remove(item);

    public void RemoveAt(int index) => Students.RemoveAt(index);

    #endregion

}
