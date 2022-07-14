using System.Collections;

using IntroOOP.Students.Base;

namespace IntroOOP.Students;

public class StudentsGroup : NamedItem, IEnumerable<Student>, IList<Student>, IDictionary<int, Student>
{
    public List<Student> Students { get; set; } = new();

    #region IEnumerable<Student>

    public IEnumerator<Student> GetEnumerator() => Students.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    #endregion

    #region IList<Student>

    public Student this[int index] { get => Students[index]; set => Students[index] = value; }

    public ICollection<int> Keys { get; }

    public ICollection<Student> Values { get; }

    public int Count => Students.Count;

    public bool IsReadOnly => false;

    public void Add(Student item) => Students.Add(item);

    private void Clear() => Students.Clear();
    void ICollection<KeyValuePair<int, Student>>.Clear() => throw new NotSupportedException();

    void ICollection<Student>.Clear() { Clear(); }

    public bool Contains(Student item) => Students.Contains(item);

    public void CopyTo(Student[] array, int arrayIndex) => Students.CopyTo(array, arrayIndex);

    public int IndexOf(Student item) => Students.IndexOf(item);

    public void Insert(int index, Student item) => Students.Insert(index, item);

    public bool Remove(Student item) => Students.Remove(item);

    public void RemoveAt(int index) => Students.RemoveAt(index);

    #endregion

    Student IDictionary<int, Student>.this[int key]
    {
        get
        {
            if (TryGetValue(key, out var stud))
                return stud;
            throw new InvalidOperationException("Студент с указанным идентификатором отсутствует");
        }
        set
        {
            if (TryGetValue(key, out var stud))
                Remove(stud);

            Add(key, value);
        }
    }

    public void Add(int key, Student value)
    {
        if (Students.Any(s => s.Id == key))
            throw new InvalidOperationException("Студент с указанным идентификатором уже присутствует");
    }

    public bool ContainsKey(int key)
    {
        return Students.Any(s => s.Id == key);
    }

    public bool Remove(int key)
    {
        return Students.RemoveAll(s => s.Id == key) > 0;
    }

    public bool TryGetValue(int key, out Student value)
    {
        value = Students.FirstOrDefault(s => s.Id == key)!;
        return value is not null;
    }

    public bool Remove(KeyValuePair<int, Student> item)
    {
        return Remove(item.Key);
    }

    public void Add(KeyValuePair<int, Student> item)
    {
        if (ContainsKey(item.Key))
            throw new InvalidOperationException("Студент с указанным ключом уже существует");

        item.Value.Id = item.Key;
        Students.Add(item.Value);
    }

    public void CopyTo(KeyValuePair<int, Student>[] array, int arrayIndex) => throw new NotSupportedException();

    public bool Contains(KeyValuePair<int, Student> item) => ContainsKey(item.Key);

    IEnumerator<KeyValuePair<int, Student>> IEnumerable<KeyValuePair<int, Student>>.GetEnumerator()
    {
        foreach (var student in Students)
            yield return new(student.Id, student);
    }
}
