// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;


/*Create a custom Stack class MyStack<T> that can be used with any data type which
has following methods:  int Count()       T pop()      Void Push() */

public class MyStack<T>
{
    private List<T> items = new List<T>();

    public int Count
    {
        get { return items.Count; }
    }

    public T Pop()
    {
        if (items.Count == 0)  //check if list is empty
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        T item = items[items.Count - 1];   //get the top item in the stack
        items.RemoveAt(items.Count - 1); //remove the top item
        return item;
    }

    public void Push(T item)
    {
        items.Add(item);
    }
}


/*Create a Generic List data structure MyList<T> that can store any data type.
Implement the following methods. 
void Add (T element) 
T Remove(int index)
bool Contains(T element)
void Clear()
void InsertAt(T element, int index)
void DeleteAt(int index)
T Find(int index) */


public class MyList<T>
{
    private List<T> items = new List<T>();

    public void Add(T element)
    {
        items.Add(element);
    }

    public T Remove(int index)
    {
        if (index < 0 || index >= items.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        T removed = items[index];
        items.RemoveAt(index);
        return removed;
    }

    public bool Contains(T element)
    {
        return items.Contains(element);
    }

    public void Clear()
    {
        items.Clear();
    }

    public void InsertAt(T element, int index)
    {
        if (index < 0 || index > items.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        items.Insert(index, element);
    }

    public void DeleteAt(int index)
    {
        if (index < 0 || index >= items.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        items.RemoveAt(index);
    }

    public T Find(int index)
    {
        if (index < 0 || index >= items.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        return items[index];
    }
}

/*Implement a GenericRepository<T> class that implements IRepository<T> interface
that will have common /CRUD/ operations so that it can work with any data source
such as SQL Server, Oracle, In-Memory Data etc. Make sure you have a type constraint on T were it should be of reference type and can be of type Entity which has one property called Id. IRepository<T> should have following methods:
void Add(T item)
void Remove(T item)
Void Save()
IEnumerable<T> GetAll()
T GetById(int id) */

public interface IEntity
{
    int Id { get; set; }
}

public interface IRepository<T> where T : class, IEntity
{
    void Add(T item);
    void Remove(T item);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}

public class GenericRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly List<T> _data = new List<T>();

    public void Add(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        if (item.Id != 0)
        {
            throw new ArgumentException("Cannot add an item with a non-zero Id.", nameof(item));
        }

        item.Id = _data.Count + 1;
        _data.Add(item);
    }

    public void Remove(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        if (item.Id == 0)
        {
            throw new ArgumentException("Cannot remove an item with a zero Id.", nameof(item));
        }

        _data.Remove(item);
    }

    public void Save()
    {
        // Save changes to data source
    }

    public IEnumerable<T> GetAll()
    {
        return _data;
    }

    public T GetById(int id)
    {
        return _data.FirstOrDefault(x => x.Id == id);
    }
}


