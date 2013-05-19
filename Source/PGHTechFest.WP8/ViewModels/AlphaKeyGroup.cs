using System.Collections.Generic;

public class Group<T> : List<T>
{
    public Group(object name, IEnumerable<T> items)
        : base(items)
    {
        this.Key = name;
    }

    public object Key
    {
        get;
        set;
    }
}