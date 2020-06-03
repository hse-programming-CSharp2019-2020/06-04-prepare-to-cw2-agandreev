using System.Collections;
using System.Collections.Generic;

namespace EKRLib
{
    public class CollectionEnumerator<T> : IEnumerator<T> where T : Item
    {
        private int index = -1;
        private List<T> items;

        public CollectionEnumerator(List<T> items)
        {
            this.items = items;
        }

        public T Current => items[index];

        object IEnumerator.Current => items[index];

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (items.Count <= ++index)
            {
                Reset();
                return false;
            }
            return true;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
