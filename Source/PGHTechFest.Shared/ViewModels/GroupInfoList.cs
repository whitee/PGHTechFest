using System.Collections.Generic;

namespace PGHTechFest.ViewModels
{
    public class GroupInfoList<T> : List<T>
    {
        public GroupInfoList(object key) { Key = key; }
        public GroupInfoList(object key, List<T> items) { 
            Key = key;
            this.AddRange(items);
        }

        public object Key { get; set; }

        public new IEnumerator<T> GetEnumerator()
        {
            return (System.Collections.Generic.IEnumerator<T>)base.GetEnumerator();
        }
    }
}
