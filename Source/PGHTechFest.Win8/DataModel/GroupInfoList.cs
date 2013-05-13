using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGHTechFest.DataModel
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
