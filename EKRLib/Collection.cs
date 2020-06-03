using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
    [DataContract, KnownType(typeof(Box))]
    public class Collection<T>: IEnumerable<T> where T: Item 
    {
        private List<T> items;

        public Collection()
        {
            Items = new List<T>();
        }

        [DataMember]
        public List<T> Items { get; set; }

        public void Add(T item)
        {
            Items.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CollectionEnumerator<T>(Items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CollectionEnumerator<T>(Items);
        }
    }
}
